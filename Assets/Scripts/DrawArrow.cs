using DigitalRuby.AnimatedLineRenderer;
using UnityEngine;

public class DrawArrow : MonoBehaviour
{
    private PhasorScript phasorScript;

    private void Start()
    {
        phasorScript = GetComponent<PhasorScript>();
    }

    void Update()
    {
        GameObject[] array = ImageTargetManager.Instance.ITOnScreen;
        foreach (GameObject target in array)
        {
            GameObject nextTarget = PathManager.Instance.GetNextTarget(target);
            if (nextTarget != null)
            {
                phasorScript.Source = target;
                phasorScript.Fire(nextTarget.transform.position);
            }
        }
    }
}