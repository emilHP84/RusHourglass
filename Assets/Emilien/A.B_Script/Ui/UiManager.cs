using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject CreditPage;
    private bool isactive = false;
    
    public void starting() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Credit() {
        CreditPage.SetActive(true);
        isactive = true;
    }

    public void Quitting() {
        Application.Quit();
    }


    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && isactive == true) {
            CreditPage.SetActive(true);
            isactive = false;
        }
    }
}
