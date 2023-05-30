using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private InventoryPlayer inventoryPlayer;
    [SerializeField] private ParticleSystem _particleSystem;
    
    public void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            inventoryPlayer.pieceNumber += 1;
            _particleSystem.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
