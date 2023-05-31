using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderer : MonoBehaviour {
    public GameObject renderScreenNew;
    public GameObject renderScreenOld;

    public void Awake() {
        renderScreenNew.GetComponent<Animation>().Play("TransitionCameraNewToNew");
    }

    public void ScreenfadeOne() {
        renderScreenNew.GetComponent<Animation>().Play("TransitionCameraNewToOld");
        renderScreenOld.GetComponent<Animation>().Play("TransitionCameraOldToOld");
    }
    
    public void ScreenfadeTwo() {
        renderScreenNew.GetComponent<Animation>().Play("TransitionCameraNewToNew");
        renderScreenOld.GetComponent<Animation>().Play("TransitionCameraOldToNew");
    }
    
}
