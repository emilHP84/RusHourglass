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
    public List<GameObject> roadModernModule = new List<GameObject>();
    public List<GameObject> roadIndustrialModule = new List<GameObject>();
    
    [Header("Liste module House:")] 
    public List<GameObject> ModernHouse = new List<GameObject>();
    public List<GameObject> IndustrialHouse = new List<GameObject>();

    private int moduleChoose;
    private int houseChoose;

    private void OnEnable() {
        moduleChoose = Random.Range(0, 14);
        Instantiate(modernModule[moduleChoose], TransformInstanceOne.transform);
        Instantiate(industrialModule[moduleChoose], TransformInstanceTwo.transform);

        if (moduleChoose == 0) {
            Instantiate(roadModernModule[0], TransformInstanceOne.transform);
            Instantiate(roadIndustrialModule[0], TransformInstanceTwo.transform);
        }
        else if (moduleChoose == 1) {
            Instantiate(roadModernModule[1], TransformInstanceOne.transform); 
            Instantiate(roadIndustrialModule[1], TransformInstanceTwo.transform);
        }
        else if (moduleChoose >= 2) {
            Instantiate(roadModernModule[2], TransformInstanceOne.transform); 
            Instantiate(roadIndustrialModule[2], TransformInstanceTwo.transform);
            
            for (int i = 0; i < 6; i++) {
                houseChoose = Random.Range(0, 5);
                Instantiate(ModernHouse[houseChoose],transformHouseModern[i].transform );
                Instantiate(IndustrialHouse[houseChoose],transformHouseIndustrial[i].transform );
            }
        }
    }
}
