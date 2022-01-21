using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    EnemyController _ec;

    void Start()
    {
        _ec = this.GetComponentInParent<EnemyController>();
    }

    public void Hit()
    {
        _ec.AttackAction();
    }
}
