using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement _movement = null;
    Attack _Attack = null;

    private void Awake()
    {
        _movement = this.GetComponent<Movement>();
        _Attack = this.GetComponent<Attack>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Attacking() == true) return;
        if (Moving() == true) return;
    }

    private bool Moving()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetMouseRay(), out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _movement.Begin(hit.point);
            }

            return true;
        }
        return false;
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private bool Attacking()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

        foreach (RaycastHit hit in hits)
        {
            HealthPoint target = hit.transform.GetComponent<HealthPoint>();
            if (target == null) continue;

            if (_Attack.CanAttack(target.gameObject) == false) continue;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("타겟팅!");
                _Attack.Begin(target.gameObject);
            }

            return true;
        }

        return false;

    }


   
}
