using UnityEngine;

public class DestroyModule : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        ModuleManager moduleManager = other.gameObject.GetComponent<ModuleManager>();
        if (moduleManager == null) return;
        moduleManager.Destroy();
    }
    
}