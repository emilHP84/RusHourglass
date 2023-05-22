using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawnner : MonoBehaviour
{

    [Header("Instanciate object")]
    public GameObject Module;
    public GameObject TransformInstance;

    public float spawnTime;
    
    private float time;
    private bool canInstance;

    public void Start() {
        time = 0;
        canInstance = true;
    }
    
    public void FixedUpdate() {
        time += Time.deltaTime;

        if (time >= spawnTime && canInstance) {
            Instantiate(Module, TransformInstance.transform.position, Module.transform.rotation);
            time = 0;
        }
    }
}
