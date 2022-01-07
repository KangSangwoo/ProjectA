using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float _speed = 5.0f;

    Vector3 dir;

    public GameObject _explosionSource;

    void OnEnable()
    {
        int rand = Random.Range(0, 10);

        if(rand < 3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - this.transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        this.transform.position += dir * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(_explosionSource);
        explosion.transform.position = this.transform.position;

        ScoreManager.Instance.Score++;

        if (collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf._bulletObjectPool.Add(collision.gameObject);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");

            Destroy(collision.gameObject);
        }

        this.gameObject.SetActive(false);
        EnemyManager em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        em._enemyObjectPool.Add(this.gameObject);
    }







    //=======================================================

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("트리거 " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
