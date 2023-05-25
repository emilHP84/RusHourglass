using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class ModuleManager : MonoBehaviour
{ 
    public GameObject TransformInstanceOne;
    public GameObject TransformInstanceTwo;

    [Header("Liste Transform:")] 
    public List<GameObject> transformHouseModern = new List<GameObject>();
    public List<GameObject> transformHouseIndustrial = new List<GameObject>();

    [Header("Liste module Difficulty:")] 
    public List<GameObject> modernModule = new List<GameObject>();
    public List<GameObject> industrialModule = new List<GameObject>();
    
    [Header("Liste module House:")] 
    public List<GameObject> ModernHouse = new List<GameObject>();
    public List<GameObject> IndustrialHouse = new List<GameObject>();

    private int moduleChoose;
    private int houseChoose;

    private void OnEnable() {
        moduleChoose = Random.Range(0, 9);
        Instantiate(modernModule[moduleChoose], TransformInstanceOne.transform);
        Instantiate(industrialModule[moduleChoose], TransformInstanceTwo.transform);
        
        for (int i = 0; i < 6; i++) {
            houseChoose = Random.Range(0, 5);
            Instantiate(ModernHouse[houseChoose],transformHouseModern[i].transform );
            Instantiate(IndustrialHouse[houseChoose],transformHouseIndustrial[i].transform );
        }
    }
}
