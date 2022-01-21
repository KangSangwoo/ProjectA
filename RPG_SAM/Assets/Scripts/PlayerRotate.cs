using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float _rotSpeed = 200.0f;

    float mx = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.GM._gState != GameManager.GameState.Run) return;

        float mouse_X = Input.GetAxis("Mouse X");
        mx += mouse_X * _rotSpeed * Time.deltaTime;
        this.transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
