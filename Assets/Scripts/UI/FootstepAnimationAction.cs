using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAnimationAction : MonoBehaviour {

    public void BeginAnotherAnimation()
    {
        this.transform.parent.GetComponent<CreateFootstep>().AnimationFinish();
    }
    public void OnAnimationEnd()
    {
        Object.Destroy(this.gameObject);
    }
}
