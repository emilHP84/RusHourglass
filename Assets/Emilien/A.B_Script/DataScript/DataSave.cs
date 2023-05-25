using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public ScriptableObject inventoryPlayer;

    public void Awake() {
        LoadJsonSave();
    }

    public void SaveToJson() {
        string coinsData = JsonUtility.ToJson(inventoryPlayer);
        string filePath = Application.persistentDataPath + "/CoinsData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, coinsData);
        Debug.Log("Sauvegarde Effectuée");
    }

    public void LoadJsonSave() {
        string filePath = Application.persistentDataPath + "/CoinsData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        JsonUtility.FromJsonOverwrite(inventoryData, inventoryPlayer);
        //inventoryPlayer = JsonUtility.FromJson<InventoryPlayer>(inventoryData);
        Debug.Log("Sauvegarde Chargé");
    }
}
