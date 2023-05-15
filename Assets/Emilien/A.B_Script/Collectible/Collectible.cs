using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private InventoryPlayer inventoryPlayer;
    
    public void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            inventoryPlayer.pieceNumber += 1;
            Destroy(gameObject);
        }
    }
}
