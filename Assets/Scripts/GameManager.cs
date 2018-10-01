using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject footStep;
    private GameObject _footStep;
    void Start()
    {
        
    }
    void Update()
    {
        GameObject[] array = ImageTargetManager.Instance.ITOnScreen;
        foreach (GameObject target in array)
        {
            GameObject nextTarget = PathManager.Instance.GetNextTarget(target);
            if (nextTarget != null)
            {
                //GameObject canvas = GameObject.Find("Canvas");
                //_footStep = Instantiate(footStep, canvas.transform) as GameObject;
                //_footStep.transform.parent = canvas.transform;
                //_footStep.transform.position = target.transform.position;
                //Transform footstep = canvas.transform.Find("Footstep");
                //footstep.gameObject.SetActive(true);
                //Debug.Log(_footStep.transform.position) ;
                target.GetComponent<ImageTargetProperty>().DrawLine(nextTarget.transform.position);
            }
        }
    }
}