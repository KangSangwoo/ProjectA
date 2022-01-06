using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 1.0f;

    void Start()
    {
        /*
        int rand = Random.Range(0, 10); //랜덤 변수 선언

        if (rand < 5)
        {

            // 몬스터 윗쪽 줄에서 생성
            this.transform.position = new Vector3( );
        }
        else
        {
            // 몬스터 아랫쪽 줄에서 생성
            this.transform.position = new Vector3();
        }

    */
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
