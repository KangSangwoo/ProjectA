using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject _bombEffect;

    public int _attackPower = 10;

    public float _radius = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, _radius, 1 << 10);

        for(int i = 0; i < cols.Length; i++)
        {
            cols[i].GetComponent<EnemyController>().HitEnemy(_attackPower);
        }

        GameObject eff = Instantiate(_bombEffect);
        eff.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }
}
