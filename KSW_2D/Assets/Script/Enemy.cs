using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 1.0f;




    void Start()
    {
        /*  활성화 되면// 온에이블로 바꾸자 
         *  
        int rand = Random.Range(0, 8); //랜덤 변수 선언

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            collision.gameObject.SetActive(false);      // 임시로 닿으면 제거
            Debug.Log("충돌");
        }

        this.gameObject.SetActive(false);
        EnemyManager em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        em._enemyObjectPool.Add(this.gameObject);

    }






}
