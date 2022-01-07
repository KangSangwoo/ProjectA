using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material _bgMat;
    public float _scrollSpeed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = Vector2.up;
        _bgMat.mainTextureOffset += dir * _scrollSpeed * Time.deltaTime;
    }
}
