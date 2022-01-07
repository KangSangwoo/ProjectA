using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed = 5.0f;

    void Start()
    {
        
    }

    void Update()

    {
        Vector3 dir = Vector3.up;
        this.transform.position += dir * _speed * Time.deltaTime;
    }
}
