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

    public void Awake() {
        ThisUI = gameObject.GetComponent<RectTransform>();
    }
    public void Start() {
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0,false);
    }

    public void Continue() {
        if (_InventoryPlayer.pieceNumber >= 50)
        {
            _InventoryPlayer.pieceNumber -= 50;
            Player.SetActive(true);
            ThisUI.DOAnchorPos(new Vector2(0, 2436), 0.2f, false);
        }
        else return;
    }
    
    public void Retry() {
        SceneManager.LoadScene("SampleScene");
        ThisUI.DOAnchorPos(new Vector2(0,2436 ),0.2f,false);
    }
    public void Quit() {
        // retour au menu de base
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0.2f,false);
        
    }
}
