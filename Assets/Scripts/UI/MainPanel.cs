using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainPanel : MonoBehaviour
    {
        private List<string[]> paths;

        private void Start()
        {
            int proId = PlayerPrefs.GetInt("productId", 1);
            initPaths();
            SetPath(proId-1);
        }

        private void initPaths()
        {
            paths = new List<string[]>();
            paths.Add(PathManager.path1);
            paths.Add(PathManager.path2);
            paths.Add(PathManager.path3);
            paths.Add(PathManager.path4);
        }

        public void SetPath(int pathIndex)
        {
            Debug.Log(string.Format("You select option[{0}]", pathIndex));
            string[] path = paths[pathIndex];
            PathManager.Instance.SetPath(path);
        }
    }
}