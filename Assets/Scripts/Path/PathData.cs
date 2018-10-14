using System.Collections;
using UnityEngine;

public class PathData : MonoBehaviour
{
    public int[] PathDataReturn(int finitem)
    {
        switch (finitem)
        {
            case 1:
                return new[] {1, 2, 3, 4, 5, 7, 8, 9};
            case 2:
                return new[] {1, 2, 3, 4, 5, 7, 8, 9, 10, 11};
            case 3:
                return new[] {1, 2, 3, 4, 5, 6, 12, 13, 14};
            case 4:
                return new[] {1, 2, 3, 4, 5, 6, 12, 13, 14, 15, 16};
            default:
                return new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        }
    }
}