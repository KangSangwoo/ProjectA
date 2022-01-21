using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float _rotSpeed = 200.0f;

    float mx = 0;
    float my = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.GM._gState != GameManager.GameState.Run) return;

        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * _rotSpeed * Time.deltaTime;
        my += mouse_Y * _rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90.0f, 90.0f);

        this.transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
