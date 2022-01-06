using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public float _speed = 1.0f;

    public GameObject _Unit1Source = null;        // 유닛1 리소스

    public Transform _CreatePosition;     //생성 위치

    public GameObject _UnitButton;      // 유닛버튼


    void Start()
    {
        //this.transform.position = new Vector3(-6, 2, 0);    // 윗줄생산

    }

    void Update()
    {
        // (Input.GetButtonDown("Fire1"))
        
            this.transform.Translate(Vector3.right * _speed * Time.deltaTime);
        
    }
}

