using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouvementPlayer : MonoBehaviour
{
    [Header("Special")]
    public Camera cam;
    private Vector3 camPosition;
    
    [Header("possible to move? :")]
    public bool possibleRightMove;
    public bool possibleLeftMove;

    [Header("speed")] 
    public float duringDash;
    public float dashDelay;
    
    public void Start() {
        dashDelay = 0;
        camPosition = cam.transform.position;
    }

    public void Update() {
        dashDelay -= Time.deltaTime;

        if (gameObject.transform.position.x == 1) {
            possibleRightMove = false;
        }
        else possibleRightMove = true;

        if (gameObject.transform.position.x == -1) {
            possibleLeftMove = false;
        }
        else possibleLeftMove = true;
        
            if (possibleLeftMove == true && possibleRightMove == false) {
                if (Input.GetKeyDown(KeyCode.Q)) {
                    gameObject.transform.DOMove(new Vector3(0, 0.75f, 0), duringDash);
                    cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);
                }
            }
            if (possibleLeftMove == false && possibleRightMove == true) {
                if (Input.GetKeyDown(KeyCode.D)) {
                    gameObject.transform.DOMove(new Vector3(0, 0.75f, 0), duringDash);
                    cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.D) && possibleRightMove == true && possibleLeftMove == true) {
                gameObject.transform.DOMove(new Vector3(1, 0.75f, 0), duringDash);
                cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
            }
            if (Input.GetKeyDown(KeyCode.Q) && possibleLeftMove == true && possibleRightMove == true) {
                gameObject.transform.DOMove(new Vector3(-1, 0.75f, 0), duringDash);
                cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
            }
    }
}
