using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathData : MonoBehaviour {

    public int[] PathDataReturn(int finitem)
    {
        switch (finitem)
        {
            case 1:
                return new int[4] { 1, 2, 3, 4 };
            case 2:
                return new int[3] { 1, 3, 4 };
            case 3:
                return new int[2] { 1, 4 };
            case 4:
                return new int[3] { 1, 2, 3 };
            default:
                return new int[4] { 1, 2, 3, 4 };
        }
    }
}
