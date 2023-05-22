using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureManager : MonoBehaviour
{
    private void Awake()
    {
        var tex = new RenderTexture(Screen.width, Screen.height, 8);
    }
}
