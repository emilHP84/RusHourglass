using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class MouvementPlayer : MonoBehaviour
{
    [Header("Special")]
    public Camera cam;
    public GameObject CameraOne;
    public GameObject CameraTwo;
    
    private Vector3 camPosition;

    public bool _asTp;
    
    [Header("possible to move? :")]
    public bool possibleRightMove;
    public bool possibleLeftMove;
    
    [Header("speed")] 
    public float duringDash;
    public float dashDelay;

    [Header("Valeur fluctuante")] 
    public float ValueXNormal;
    public float ValueXLimitLeft;
    public float ValueXLimitRight;
    private float actualValue;

    public void Awake() {
        _asTp = false;
    }

    public void Start() {
        dashDelay = 0;
        camPosition = cam.transform.position;

        ValueXNormal = 0;
        ValueXLimitRight = 1;
        ValueXLimitLeft = -1;
    }

    public void Update() {
        dashDelay -= Time.deltaTime;
        
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (_asTp == false) {
               _asTp = true;
               CameraOne.SetActive(false);
               CameraTwo.SetActive(true);
               
               ValueXNormal += 25;
               ValueXLimitRight += 25;
               ValueXLimitLeft += 25;
               actualValue += 25;
                
                gameObject.transform.DOMove(new Vector3(actualValue, 0.75f, 0), 0);
                return;
            }
            if (_asTp == true) {
                _asTp = false;
                CameraOne.SetActive(true);
                CameraTwo.SetActive(false);

                ValueXNormal -= 25;
                ValueXLimitRight -= 25;
                ValueXLimitLeft -= 25;
                actualValue -= 25;
                
                gameObject.transform.DOMove(new Vector3(actualValue, 0.75f, 0), 0);
                return;
            }
            return;
        }
        Mouvement();
    }

    public void Mouvement() {
        
        if (gameObject.transform.position.x == ValueXLimitRight) {
            possibleRightMove = false;
        }
        else possibleRightMove = true;

        if (gameObject.transform.position.x == ValueXLimitLeft) {
            possibleLeftMove = false;
        }
        else possibleLeftMove = true;
        
        if (possibleLeftMove == true && possibleRightMove == false) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                actualValue = ValueXNormal;
                gameObject.transform.DOMove(new Vector3(ValueXNormal, 0.75f, 0), duringDash);
                cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);
            }
        }
        if (possibleLeftMove == false && possibleRightMove == true) {
            if (Input.GetKeyDown(KeyCode.D)) {
                actualValue = ValueXNormal;
                gameObject.transform.DOMove(new Vector3(ValueXNormal, 0.75f, 0), duringDash);
                cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
            }
        }
            
        if (Input.GetKeyDown(KeyCode.D) && possibleRightMove == true && possibleLeftMove == true) {
            actualValue = ValueXLimitRight;
            gameObject.transform.DOMove(new Vector3(ValueXLimitRight, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
        if (Input.GetKeyDown(KeyCode.Q) && possibleLeftMove == true && possibleRightMove == true) {
            actualValue = ValueXLimitLeft;
            gameObject.transform.DOMove(new Vector3(ValueXLimitLeft, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
    }
}
