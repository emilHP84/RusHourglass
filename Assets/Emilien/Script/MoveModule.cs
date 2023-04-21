using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModule : MonoBehaviour
{
    [Header("Gameobject")]
    public int _speed = 10;
    
    private float time;
    
    public void Start() {
        time = 0;
    }

    public void FixedUpdate() {
        transform.parent = null;
        Moving();
    }
    
    void Moving() {
        transform.position += Vector3.back * _speed * Time.deltaTime;
    }
}

