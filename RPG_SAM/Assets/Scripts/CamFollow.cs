using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform _target;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = _target.position;
    }
}
