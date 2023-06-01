using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Emilien.A.B_Script.Utils {
    public static class ModulePool {

        private static List<GameObject> _pool = new List<GameObject>();

        public static GameObject Pool(GameObject source, Transform parent) {
            _pool.RemoveAll(go => go == null);
            GameObject pulledGo = _pool.FirstOrDefault(go => go.name == source.name 
                                                             && go.activeSelf == false);
            if (pulledGo == null) {
                Debug.Log("Instantiate !");
                pulledGo = Object.Instantiate(source, parent);
                pulledGo.name = source.name;
                _pool.Add(pulledGo);
            }
            else {
                Debug.Log("Match !");
                pulledGo.SetActive(true);
                pulledGo.transform.parent = parent;
                pulledGo.transform.localPosition = Vector3.zero;
                pulledGo.transform.localRotation = Quaternion.identity;
                _pool.Remove(pulledGo);
            }

            return pulledGo;
        }
    
    }
}