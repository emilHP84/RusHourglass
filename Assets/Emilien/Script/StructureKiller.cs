using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureKiller : MonoBehaviour
{
    private GameObject Player;
    public void Awake() {
        Player = GameObject.Find("Player");
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Destroy(Player);
        }
        
    }
}
