using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public ScriptableObject inventoryPlayer;
    
    public void SaveToJson() {
        string coinsData = JsonUtility.ToJson(inventoryPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
