using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureKiller : MonoBehaviour
{
    private GameObject Player;
    public GameObject UI;

    public void Awake() {
        Player = GameObject.Find("Player");
        UI = GameObject.Find("PanelDeadOfPlayer");
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Player.SetActive(false);
            UI.SetActive(true);
        }
        
    }
}
