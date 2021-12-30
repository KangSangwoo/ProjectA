using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        this.transform.position = transform.Translate(Vector3.right * Time.deltaTime);
            
            
    }
}
