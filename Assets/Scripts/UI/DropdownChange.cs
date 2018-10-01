using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownChange : MonoBehaviour {

    public void onDropDownChange(int value)
    {
        this.GetComponent<CreateFootstep>().icon = value;
    }
}
