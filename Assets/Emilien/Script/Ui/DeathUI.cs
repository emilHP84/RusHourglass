using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public GameObject Player;

    public void Start() {
        gameObject.SetActive(false);
    }

    public void Continue() { 
        Player.SetActive(true);  
        gameObject.SetActive(false);
    }

    public void Retry() {
        SceneManager.LoadScene("emilienTest");
        gameObject.SetActive(false);
    }

    public void Quit() {
        // retour au menu de base
        gameObject.SetActive(false);
    }

}
