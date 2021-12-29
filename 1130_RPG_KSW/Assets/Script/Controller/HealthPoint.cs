using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// HP표기
public class HealthPoint : MonoBehaviour
{

    [SerializeField]
    [Range(5, 1000)]
    float _value = 20;

    Animator _animator = null;

    //내가 죽으면 호출안되게

    bool _isDead = false;
    public bool IsDead { get { return _isDead; } }

    Transform _trans = null;

    SkinnedMeshRenderer[] _renderers = null;    // 여러개니 배열로


    ActionManger _actionManger = null;


    // 게임오브젝트의 애니메이터 컴포넌트 호출
    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _renderers = this.GetComponentsInChildren<SkinnedMeshRenderer>();       //여러개s
        _actionManger = this.GetComponent<ActionManger>();
    }

    private void Update()
    {
        /*
        if (_trans == null) return;

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation,
            Quaternion.LookRotation(_trans.transform.position - this.transform.position),
            Time.deltaTime * 10.0f);
        */

    }


    public void Damage(float damage, Transform trans)
    {
        //this.transform.LookAt(trans);

        _trans = trans;

        _value = Mathf.Max(_value - damage, 0);    // 공격하면 HP -damage 

        Debug.Log("HP감소");

        if (_value > 0.0f)  // 피격시, 빨강색으로 
        {
            foreach (SkinnedMeshRenderer rendr in _renderers)
            {
                rendr.material.color = new Color(10, 0, 0);
            }

            Invoke("ResetColor", 0.2f);
           
        }
        else
        {
            Dead();     // 0이하면 죽는모션 트리거 발동
        }
    }


    private void Dead()
    {
        if (_isDead == true) return;

        _isDead = true;
        _animator.SetTrigger("Dead");
        _actionManger.StopAction();

    }

    private void ResetColor()
    {
        foreach (SkinnedMeshRenderer rendr in _renderers)
        {
            rendr.material.color = Color.white;
        }
    }
}
