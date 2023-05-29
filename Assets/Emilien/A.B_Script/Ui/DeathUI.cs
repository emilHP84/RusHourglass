using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    
    public GameObject Player;
    public RectTransform ThisUI;
    public InventoryPlayer _InventoryPlayer;
    public DataSave _DataSave;

    public bool isShieldActive = false;

    public void Awake() {
        ThisUI = gameObject.GetComponent<RectTransform>();
    }
    public void Start() {
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0,false);
    }

    public void Continue() {
        if (_InventoryPlayer.pieceNumber >= 50) {
            _InventoryPlayer.pieceNumber -= 50;
            Player.SetActive(true);
            ThisUI.DOAnchorPos(new Vector2(0, 2436), 0.2f, false);
            isShieldActive = true;
        }
        else return;
    }
    
    public void Retry() {
        SceneManager.LoadScene("SampleScene");
        ThisUI.DOAnchorPos(new Vector2(0,2436 ),0.2f,false);
    }
    public void Quit() {
        _DataSave.SaveToJson();
        SceneManager.LoadScene("");
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0.2f,false);
    }
}
