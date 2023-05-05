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

    public void Awake() {
        ThisUI = gameObject.GetComponent<RectTransform>();
    }
    public void Start() {
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0,false);
    }

    public void Continue() { 
        Player.SetActive(true);
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0.2f,false);
    }
    public void Retry() {
        SceneManager.LoadScene("emilienTest");
        ThisUI.DOAnchorPos(new Vector2(0,2436 ),0.2f,false);
    }
    public void Quit() {
        // retour au menu de base
        ThisUI.DOAnchorPos(new Vector2(0, 2436),0.2f,false);
        
    }
}
