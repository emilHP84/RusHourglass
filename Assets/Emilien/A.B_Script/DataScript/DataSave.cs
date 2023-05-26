using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using File = OpenCover.Framework.Model.File;

public class DataSave : MonoBehaviour
{
    public ScriptableObject inventoryPlayer;
    
    
    public void Awake() {
        string filePathData = Application.persistentDataPath + "/CoinsData.json";
        if (UnityEngine.Windows.File.Exists(filePathData) == false) {
            Debug.Log("test");
            SaveToJson();
        }
        
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

        JsonUtility.FromJsonOverwrite(inventoryData, inventoryPlayer); // (pour scriptableObject)
        //inventoryPlayer = JsonUtility.FromJson<InventoryPlayer>(inventoryData); (pour script basique)
        Debug.Log("Sauvegarde Chargé");
    }
}
