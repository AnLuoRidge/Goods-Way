using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    void Update()
    {
        GameObject[] array = ImageTargetManager.Instance.ITOnScreen;
        foreach (GameObject target in array)
        {
            GameObject nextTarget = PathManager.Instance.GetNextTarget(target);
            if (nextTarget != null)
            {
                target.GetComponent<ImageTargetProperty>().DrawLine(nextTarget.transform.position);
            }
        }
    }
}