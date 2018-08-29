using System;
using System.Linq;
using UnityEngine;
using Utils;

public class PathManager : Singleton<PathManager>
{
    private string[] path1 = {"ImageTarget1", "ImageTarget2", "ImageTarget3", "ImageTarget4"};
    private string[] path2 = {"ImageTarget1", "ImageTarget3"};
    public string[] CurrentPath;

    protected override void Awake()
    {
        base.Awake();
        CurrentPath = path1;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 50), "Path 1"))
        {
            CurrentPath = path1;
            Debug.Log("Show Path 1");
        }

        if (GUI.Button(new Rect(10, 70, 50, 50), "Path 2"))
        {
            CurrentPath = path2;
            Debug.Log("Show Path 2");
        }
    }

    /// <summary>
    /// Get next target name according to CurrentPath and current target name
    /// </summary>
    /// <param name="targetName">Target name you want to search</param>
    /// <returns>Next Target name, return empty string if cannot found</returns>
    public string GetNextTargetName(string targetName)
    {
        if (!CurrentPath.Contains(targetName))
        {
            return String.Empty;
        }

        int index = Array.IndexOf(CurrentPath, targetName);
        if (index == CurrentPath.Length - 1)
        {
            // target is at the last target of current path
            return String.Empty;
        }

        return CurrentPath[index + 1];
    }

    /// <summary>
    /// Get next target GameObject according to CurrentPath and current target GameObject
    /// </summary>
    /// <param name="target">Target name you want to search</param>
    /// <returns>Next Target name, return null if cannot found</returns>
    public GameObject GetNextTarget(GameObject target)
    {
        if (!CurrentPath.Contains(target.name))
        {
            return null;
        }

        int index = Array.IndexOf(CurrentPath, target.name);
        if (index == CurrentPath.Length - 1)
        {
            // target is at the last target of current path
            return null;
        }

        string nextTargetName = CurrentPath[index + 1];

        return ImageTargetManager.Instance.GetTargetByName(nextTargetName);
    }
}