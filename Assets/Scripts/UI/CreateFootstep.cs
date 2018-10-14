using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreateFootstep : MonoBehaviour {

    private GameObject _Icon;
    private List<RegisteredImageTarget> RegisteredImageTargets;
    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject Footstep;
    [SerializeField] private GameObject Navigator;
    [SerializeField] private Camera ARcamera;
    [SerializeField] private Dropdown m_Dropdown;

    [SerializeField] private GameObject FinalText;
    private bool ani = true;
    public int InnerCount = 0;
    private int InnerStep = 0;
    private int[] Path;
    public int icon = 0;
    // Use this for initialization
    void Start () {
        RegisteredImageTargets = new List<RegisteredImageTarget>();
        int proId = PlayerPrefs.GetInt("productId", 1);
        Path = this.GetComponent<PathData>().PathDataReturn(proId);
    }

    // Update is called once per frame
    void Update () {
        icon = m_Dropdown.value;
        if (RegisteredImageTargets.Count >=2 )
        {
            if (InnerStep > RegisteredImageTargets.Count-2) { InnerStep = 0; };
            Vector2 startIn = ARcamera.WorldToScreenPoint(RegisteredImageTargets[InnerStep].Imagetarget.position);
            Vector2 endIn = ARcamera.WorldToScreenPoint(RegisteredImageTargets[InnerStep+1].Imagetarget.position);
            float distance = Vector2.Distance(startIn, endIn);
            Vector3 diff = endIn - startIn;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            int x = (int)(distance / 100) + 1;
            if (InnerCount <= x && ani)
            {
                ani = false;
                float colorH = (float)(InnerCount * 0.05);
                _Icon = Instantiate(ChooseIcon(icon), this.gameObject.transform) as GameObject;
                _Icon.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                _Icon.transform.position = Vector2.Lerp(startIn, endIn, ((float)InnerCount / (float)x));
                if(icon == 1)
                {
                    _Icon.transform.Find("footstepRight").GetComponent<Image>().color = Color.HSVToRGB(colorH, 1, 1);
                    _Icon.transform.Find("footstepLeft").GetComponent<Image>().color = Color.HSVToRGB(colorH, 1, 1);
                }else
                {
                    _Icon.transform.Find("Image").GetComponent<Image>().color = Color.HSVToRGB(colorH, 1, 1);
                }
                InnerCount = InnerCount + 1;
                if (InnerCount > x)
                {
                    InnerCount = 0;
                    if (InnerStep < RegisteredImageTargets.Count-2)
                    {
                        InnerStep += 1;
                    } else { InnerStep = 0; }
                }   
            } 
        }
        if(RegisteredImageTargets[RegisteredImageTargets.Count-1].Index.Equals(Path[Path.Length-1]) && !FinalText.activeSelf){
            FinalText.SetActive(true); 
            StartCoroutine("textDestory");           
        }
    }

    public void RegisterImageTarget(Transform transform, int index)
    {
        if (Path.Contains(index))
        {
            transform.gameObject.GetComponent<DefaultTrackableEventHandler>().WasRegisted = true;
            RegisteredImageTargets.Add(new RegisteredImageTarget() { Index = index, Imagetarget = transform });
            RegisteredImageTargets = RegisteredImageTargets.OrderBy(o => o.Index).ToList();
        }
    }

    public void DeRegisterImageTarget(int input)
    {
        RegisteredImageTargets.Remove(RegisteredImageTargets.Find(p => p.Index == input));
    }

    public void AnimationFinish()
    {
        ani = true;
    }

    public void UpdateImageTarget(Transform transform, int index)
    {
        var obj =RegisteredImageTargets.Find(p => p.Index == index) ;
        obj.Imagetarget = transform;
    }

    public GameObject ChooseIcon(int input)
    {
        switch (input)
        {
            case 0:
                return Icon;
            case 1:
                return Footstep;
            case 2:
                return Navigator;
            default:
                return Icon;
        }
    }
    IEnumerator textDestory()
    {
        yield return new WaitForSeconds(2f);
        FinalText.SetActive(false);
    }
}

public class RegisteredImageTarget
{
    public int Index { get; set; }

    public Transform Imagetarget { get; set; }
}


