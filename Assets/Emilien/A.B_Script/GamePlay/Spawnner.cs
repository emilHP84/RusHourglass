using UnityEngine;

public class Spawnner : MonoBehaviour
{

    [Header("Instanciate object")]
    public GameObject Module;
    public GameObject TransformInstance;
    
    public static Transform Pool;

    public float spawnTime;
    
    private float time;
    private bool canInstance;

    public void Start() {
        time = 0;
        canInstance = true;
        Pool = GameObject.FindWithTag("Pool").transform;
    }
    
    public void Update() {
        time += Time.deltaTime;

        if (time >= spawnTime && canInstance) {
            Instantiate(Module, TransformInstance.transform.position, Module.transform.rotation);
            time = 0;
        }
    }

}
