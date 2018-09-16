using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainPanel : MonoBehaviour
    {
        [SerializeField] public Dropdown itemDropDown;

        private List<string> options;

//        private Dictionary<int, string[]> paths;
        private List<string[]> paths;
        public Sprite[] Sprites;
        public Image image;

        private void Start()
        {
            initPaths();
            initOptions();
            initFirstOption();
        }

        private void initPaths()
        {
//            paths = new Dictionary<int, string[]>();
//            paths.Add(0, PathManager.path1);
//            paths.Add(1, PathManager.path2);
            paths = new List<string[]>();
            paths.Add(PathManager.path1);
            paths.Add(PathManager.path2);
            paths.Add(PathManager.path3);
            paths.Add(PathManager.path4);
        }

        private void initOptions()
        {
            options = new List<string>();
            options.Add("Mouse");
            options.Add("Cola");
            options.Add("Hat");
            options.Add("Tide");
            itemDropDown.AddOptions(options);
        }

        private void initFirstOption()
        {
            PathManager.Instance.SetPath(paths[0]);
            image.sprite = Sprites[0];
        }

        public void SetPath(int pathIndex)
        {
            Debug.Log(string.Format("You select option[{0}] : {1}", pathIndex, options[pathIndex]));
            string[] path = paths[pathIndex];
            PathManager.Instance.SetPath(path);
            Sprite sprite = Sprites[pathIndex];
            image.sprite = sprite;
        }
    }
}