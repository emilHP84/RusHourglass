using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlayer : MonoBehaviour
{
    public bool possibleRightMove;
    public bool possibleLeftMove;
    public void Update() {
        if (gameObject.transform.position.x == 1) {
            possibleRightMove = false;
        }
        else possibleRightMove = true;

        if (gameObject.transform.position.x == -1) {
            possibleLeftMove = false;
        }
        else possibleLeftMove = true;
        
        if (Input.GetKeyDown(KeyCode.D) && possibleRightMove == true) {
            gameObject.transform.position += new Vector3(1, 0, 0) ;
        }
        if (Input.GetKeyDown(KeyCode.Q) && possibleLeftMove == true) {
            gameObject.transform.position += new Vector3(-1, 0, 0) ;
        }
    }
}
