using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float _speed = 1.0f;

    void Start()
    {
    }

    void Update()
    {        
        this.transform.Translate(Vector3.right * _speed * Time.deltaTime);  // 유닛이동
    }

    //몬스터와 부딪히면, 정지하고 공격모션

    //유닛과 부딪히면, 정지하고 대기모션


    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("Enemy"))
        {
            Debug.Log("몬스터와 충돌");
            Destroy(collision.gameObject);  //몬스터 파괴
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("플레이어와 충돌");
            this.transform.Translate(Vector3.right * 0);  //정지
        }



        //		if (other.gameObject.tag == "Candy") 
        //    private void OnTriggerEnter2D(Collider2D other)


    }

    // 적타워 도달하면 승리
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("E_Tower"))
        {
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            Debug.Log("적타워 도달");
            GM.Win();
        }
    }
}

