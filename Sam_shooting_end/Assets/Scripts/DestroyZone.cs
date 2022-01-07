using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
                pf._bulletObjectPool.Add(other.gameObject);
            }
            if (other.gameObject.name.Contains("Enemy"))
            {
                EnemyManager em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
                em._enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
