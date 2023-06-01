using System.Collections.Generic;
using Emilien.A.B_Script.Utils;
using UnityEngine;
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

    private void Start() {
        moduleChoose = Random.Range(0,16);
        ModulePool.Pool(modernModule[moduleChoose], TransformInstanceOne.transform);
        ModulePool.Pool(industrialModule[moduleChoose], TransformInstanceTwo.transform);

        if (moduleChoose == 0) {
            ModulePool.Pool(roadModernModule[0], TransformInstanceOne.transform);
            ModulePool.Pool(roadIndustrialModule[0], TransformInstanceTwo.transform);
        }
        else if (moduleChoose == 1) {
            ModulePool.Pool(roadModernModule[1], TransformInstanceOne.transform); 
            ModulePool.Pool(roadIndustrialModule[1], TransformInstanceTwo.transform);
        }
        else if (moduleChoose >= 2) {
            ModulePool.Pool(roadModernModule[2], TransformInstanceOne.transform); 
            ModulePool.Pool(roadIndustrialModule[2], TransformInstanceTwo.transform);
            
            for (int i = 0; i < 6; i++) {
                houseChoose = Random.Range(0, 7);
                ModulePool.Pool(ModernHouse[houseChoose],transformHouseModern[i].transform );
                ModulePool.Pool(IndustrialHouse[houseChoose],transformHouseIndustrial[i].transform );
            }
        }
    }

    public void Destroy() {
        TransformInstanceOne.transform.GetChild(0).gameObject.SetActive(false);
        TransformInstanceOne.transform.GetChild(0).parent = Spawnner.Pool;

        TransformInstanceTwo.transform.GetChild(0).gameObject.SetActive(false);
        TransformInstanceTwo.transform.GetChild(0).parent = Spawnner.Pool;
        for (int i = 0; i < 6; i++) {
            if (transformHouseModern[i].transform.childCount > 0) {
                transformHouseModern[i].transform.GetChild(0).gameObject.SetActive(false);
                transformHouseModern[i].transform.GetChild(0).parent = Spawnner.Pool;
            }
            if (transformHouseIndustrial[i].transform.childCount > 0) {
                transformHouseIndustrial[i].transform.GetChild(0).gameObject.SetActive(false);
                transformHouseIndustrial[i].transform.GetChild(0).parent = Spawnner.Pool;
            }
        }
        Destroy(gameObject);
    }
    
}
