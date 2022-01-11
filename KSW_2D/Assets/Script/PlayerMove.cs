using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float _cost;
    public float _atk;
    public float _def;
    public float _MaxHp;
    public float _speed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {        
      this.transform.Translate(Vector3.right * _speed * Time.deltaTime);  // 유닛이동
    }

    public void Set_Uint_1()    // Defender
    {
        _cost = 50;
        _atk = 50;
        _def =60;
        _MaxHp = 250;
       _speed = 1.0f;
    }

    public void Set_Uint_2()
    {

    }

}

