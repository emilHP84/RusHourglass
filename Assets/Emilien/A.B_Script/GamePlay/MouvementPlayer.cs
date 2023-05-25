using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.Serialization;

public class MouvementPlayer : MonoBehaviour
{
    [Header("Special")]
    public Camera cam;
    public InventoryPlayer _InventoryPlayer;
    public GameObject CameraOne;
    public GameObject CameraTwo;
    
    private Vector3 camPosition;

    private Vector2 StartTouch;
    private Vector2 EndTouch;

    public bool _asTp;
    
    [Header("possible to move? :")]
    public bool possibleRightMove;
    public bool possibleLeftMove;
    
    [Header("speed")] 
    public float duringDash;
    public float AddPointsTime;

    [Header("Valeur fluctuante")] 
    public float ValueXNormal;
    public float ValueXLimitLeft;
    public float ValueXLimitRight;
    private float actualValue;
    
    public void Awake() {
        _asTp = false;
    }

    public void Start() {
        AddPointsTime = 0;
        camPosition = cam.transform.position;
        _InventoryPlayer.pointNumber += 1;

        ValueXNormal = 0;
        ValueXLimitRight = 1;
        ValueXLimitLeft = -1;
    }

    public void Update() {
        AddPointsTime += Time.deltaTime;
        
        if (gameObject.activeSelf == false) {
            _InventoryPlayer.pointNumber += 0;
        } 
        else if (AddPointsTime >= 0.2) {
            _InventoryPlayer.pointNumber += 1;
            AddPointsTime = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (_asTp == false) {
               _asTp = true;
               CameraOne.SetActive(false);
               CameraTwo.SetActive(true);
               
               ValueXNormal += 30;
               ValueXLimitRight += 30;
               ValueXLimitLeft += 30;
               actualValue += 30;
                
                gameObject.transform.DOMove(new Vector3(actualValue, 0.75f, 0), 0);
                return;
            }
            if (_asTp == true) {
                _asTp = false;
                CameraOne.SetActive(true);
                CameraTwo.SetActive(false);

                ValueXNormal -= 30;
                ValueXLimitRight -= 30;
                ValueXLimitLeft -= 30;
                actualValue -= 30;
                
                gameObject.transform.DOMove(new Vector3(actualValue, 0.75f, 0), 0);
                return;
            }
            return;
        }
        Mouvement();
    }

    public void Swipe() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            StartTouch = Input.GetTouch(0).position;
            if (EndTouch.y > StartTouch.y) {
                Left();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            EndTouch = Input.GetTouch(0).position;

            if (EndTouch.x < StartTouch.x) {
                Left();
            }
            if (EndTouch.x > StartTouch.x) {
                Right();
            }
            if (EndTouch.y <= StartTouch.y) {
                Right();
            }
        }
    }

    public void Right() {
        if (possibleLeftMove == false && possibleRightMove == true) {
            actualValue = ValueXNormal;
            gameObject.transform.DOMove(new Vector3(ValueXNormal, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
        if (possibleRightMove == true && possibleLeftMove == true) {
            actualValue = ValueXLimitRight;
            gameObject.transform.DOMove(new Vector3(ValueXLimitRight, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
    }
    
    public void Left() {
        if (possibleLeftMove == true && possibleRightMove == false) {
            actualValue = ValueXNormal;
            gameObject.transform.DOMove(new Vector3(ValueXNormal, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);
        }
        if (possibleLeftMove == true && possibleRightMove == true) {
            actualValue = ValueXLimitLeft;
            gameObject.transform.DOMove(new Vector3(ValueXLimitLeft, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
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
