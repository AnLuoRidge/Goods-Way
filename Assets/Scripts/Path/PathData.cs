using System.Collections;
using UnityEngine;

public class PathData : MonoBehaviour
{
    public int[] PathDataReturn(int finitem)
    {
        switch (finitem)
        {
            case 1:
                return new[] {1, 2, 3, 4, 5, 8, 9, 1003};
            case 2:
                return new[] {1, 2, 3, 4, 5, 8, 1002};
            case 3:
                return new[] {1, 2, 3, 6, 1000};
            case 4:
                return new[] {1, 2, 3, 6, 7, 1001};
            default:
                return new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        }
    }
}