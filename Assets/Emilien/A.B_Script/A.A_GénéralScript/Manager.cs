using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public InventoryPlayer _InventoryPlayer;
    void Start() {
        _InventoryPlayer.pointNumber = 0;
    }
    
    void Update() {}
}
