using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawnner : MonoBehaviour
{
    [Header("Liste module:")] 
    public List<GameObject> ModernModule = new List<GameObject>();
    public List<GameObject> IndustrialModule = new List<GameObject>();

    [FormerlySerializedAs("IndustrialTransformInstanee")] [Header("Instanciate object")] 
    public GameObject IndustrialTransformInstance;
    public GameObject ModernTransformInstance;
    
    private GameObject InstantiateObject;
    private GameObject InstantiateObjectVariant;
    
    public float spawnTime;
    
    
    private float time;
    private bool canInstance;

    public void Start() {
        time = 0;
        canInstance = true;
    }
    
    public void RandomizeModule() {
        int moduleChoose = Random.Range(0, 9);
        InstantiateObject = ModernModule[moduleChoose];
        InstantiateObjectVariant = IndustrialModule[moduleChoose];
    }
    
    public void FixedUpdate() {
        time += Time.deltaTime;
        transform.parent = null;
        
        if (time >= spawnTime && canInstance == true) { 
            RandomizeModule();
            Instantiate(InstantiateObject, ModernTransformInstance.transform);
            Instantiate(InstantiateObjectVariant, IndustrialTransformInstance.transform);
            time = 0;
        }
    }

    
}
