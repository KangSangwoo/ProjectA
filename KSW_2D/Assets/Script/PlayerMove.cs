﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _speed = 1.0f;

    void Start()
    {
        this.transform.position = new Vector3(-6, 2, 0);    // 윗줄생산

    }

    void Update()
    {

        this.transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }
}
