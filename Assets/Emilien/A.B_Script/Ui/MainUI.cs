using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
   public TextMeshProUGUI textPiece;
   public TextMeshProUGUI textPoint;
   public InventoryPlayer _InventoryPlayer;

   public void Start() {
   }

   public void Update() {
      textPiece.text = ":" + _InventoryPlayer.pieceNumber;
      textPoint.text = ":" + _InventoryPlayer.pointNumber;
   }
}
