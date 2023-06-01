using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Serialization;

public class MouvementPlayer : MonoBehaviour
{
    [Header("Special")] 
    public CameraRenderer _CameraRenderer;
    public InventoryPlayer _InventoryPlayer;
    public AnimationManager _AnimationManager;
    public SoundManager _SoundManager;

    [Header("Special Locale")] 
    public BoxCollider _box;
    public Camera cam;
    public GameObject shield;
    
    private Vector3 camPosition;

    private Vector2 StartTouch;
    private Vector2 EndTouch;

    public bool _asTp;
    
    [Header("possible to move? :")]
    public bool possibleRightMove;
    public bool possibleLeftMove;
    
    public bool isShieldActive = false;

    [Header("speed")] 
    public float duringDash;
    public float AddPointsTime;
    public float shieldTime;

    [Header("Valeur fluctuante")] 
    public float ValueXNormal;
    public float ValueXLimitLeft;
    public float ValueXLimitRight;
    private float actualValue;
    
    public void Awake() {
        _asTp = false;
        _box = _box.GetComponent<BoxCollider>();
    }

    public void Start() {
        AddPointsTime = 0;
        camPosition = cam.transform.position;
        _InventoryPlayer.pointNumber += 1;

        ValueXNormal = 0;
        ValueXLimitRight = 1;
        ValueXLimitLeft = -1;
        shield.SetActive(false);
    }

    public void Update() {
        Swipe();
        AddPointsTime += Time.deltaTime;

        if (isShieldActive == true) {
           Shield(); 
        }
        
        if (gameObject.activeSelf == false) {
            _InventoryPlayer.pointNumber += 0;
        } 
        else if (AddPointsTime >= 0.2) {
            _InventoryPlayer.pointNumber += 1;
            AddPointsTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
           Up();
        }
        Mouvement();
    }

    public void Swipe() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            StartTouch = Input.GetTouch(0).position;
            if (EndTouch.y > StartTouch.y) {
                
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            EndTouch = Input.GetTouch(0).position;
            Vector2 translation = EndTouch - StartTouch;

            if (Mathf.Abs(translation.x) > Mathf.Abs(translation.y)) {
                if (translation.x > 0) {
                    Right();
                }
                else {
                    Left();
                }
            }
            else {
                if (translation.y > 0) {
                    Up();
                }
            }
            
            /*if (EndTouch.x < StartTouch.x + 0.1f && EndTouch.x < translation.y + 0.1f) {
                Left();
            }
            if (EndTouch.x > StartTouch.x + 0.1f && EndTouch.x > EndTouch.y + 0.1f) {
                Right();
            }
            if (EndTouch.y > StartTouch.y + 0.1f && EndTouch.y > EndTouch.x + 0.1f) {
                Up();
            } 
            if (EndTouch.y < StartTouch.y + 0.1f && EndTouch.y > translation.x + 0.1f) {
                Up();
            }*/
        }
    }
    public void Right() {
        if (possibleLeftMove == false && possibleRightMove == true) {
            actualValue = ValueXNormal;
            _AnimationManager.RightAnim();
            gameObject.transform.DOMove(new Vector3(ValueXNormal, 0.75f, 0), duringDash);
            cam.DOShakePosition(0.2f, 0.06f).OnComplete(() => cam.transform.position = camPosition);;
        }
        if (possibleRightMove == true && possibleLeftMove == true) {
            _AnimationManager.RightAnim();
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
    public void Up() {
        if (_asTp == false) {
            _asTp = true;
            _CameraRenderer.ScreenfadeOne();
            _SoundManager.Fpriority();
               
            ValueXNormal += 30;
            ValueXLimitRight += 30;
            ValueXLimitLeft += 30;
            actualValue += 30;
            gameObject.transform.position = new Vector3(actualValue, 0.75f, 0);
            return;
        }
        if (_asTp == true) {
            _asTp = false;
            _CameraRenderer.ScreenfadeTwo();
            _SoundManager.Ppriority();

            ValueXNormal -= 30;
            ValueXLimitRight -= 30;
            ValueXLimitLeft -= 30;
            actualValue -= 30;
            gameObject.transform.position = new Vector3(actualValue, 0.75f, 0);
            return;
        }
    }
    
    public void Shield() {
        shield.SetActive(true);
        _box.enabled = false;
        
        shieldTime += Time.deltaTime;
        if (shieldTime >= 5 && _box.enabled == false) {
            shield.SetActive(false); 
            _box.enabled = true;
            shieldTime = 0f;
            isShieldActive = false;
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
                Left();
            }
        }
        if (possibleLeftMove == false && possibleRightMove == true) {
            if (Input.GetKeyDown(KeyCode.D)) {
                Right();
            }
        }
            
        if (Input.GetKeyDown(KeyCode.D) && possibleRightMove == true && possibleLeftMove == true) {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.Q) && possibleLeftMove == true && possibleRightMove == true) {
            Left();
        }
    }
}
