using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ImageTargetManager : Singleton<ImageTargetManager>
{
    public List<GameObject> ITList = new List<GameObject>();
    public GameObject[] ITOnScreen;

    // Update is called once per frame
    void Update()
    {
        if (ITOnScreen.Length != ITList.Count)
        {
            ITOnScreen = ITList.ToArray();
        }
    }

    /// <summary>
    /// Search Target from the targets showed on screen by target name
    /// </summary>
    /// <param name="targetName">Target's GameObject name</param>
    /// <returns>Image Target GameObject</returns>
    public GameObject GetTargetByName(string targetName)
    {
        GameObject findTarget = null;
        ITList.ForEach(target =>
        {
            if (target.name == targetName)
            {
                findTarget = target;
            }
        });
        return findTarget;
    }
}