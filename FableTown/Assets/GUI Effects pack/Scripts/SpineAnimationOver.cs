using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimationOver : MonoBehaviour {
    SkeletonAnimation sa;
    // Use this for initialization
    void Start() {
       sa=  GetComponent<SkeletonAnimation>();
        sa.AnimationState.Complete += AnimationState_Complete; ;

    }

    private void AnimationState_Complete(Spine.TrackEntry trackEntry)
    {
        Destroy(gameObject);
    }
    
	
}
