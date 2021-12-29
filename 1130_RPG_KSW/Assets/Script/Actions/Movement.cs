using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // 네비게이터 


public class Movement : MonoBehaviour, IEnd
{
    [SerializeField]
    Transform _Target;

    NavMeshAgent _agent;

    Ray _ray;

    Animator _animator = null;
    ActionManger _actionManger = null;
    HealthPoint _healthPoint = null;


    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        //자식의 애니메이터 찾아서 넣어줌
        _animator = this.GetComponentInChildren<Animator>();
        _actionManger = this.GetComponent<ActionManger>();
        _healthPoint = this.GetComponent<HealthPoint>();
    }

    void Update()
    {
        if (_agent != null)
        {
            _agent.enabled = !_healthPoint.IsDead;           //enabled: 컴포넌트를 on / off    ,  !: T->F
        }


    }

    private void FixedUpdate()    //프래임고정

    {
        UpdateAnimatior();
    }


    private void UpdateAnimatior()
    {

        Vector3 velocity = _agent.velocity;             // velocity: 속도
        Vector3 local = this.transform.InverseTransformDirection(velocity); // InverseTransformDirection : [월드 좌표계]를 기준으로 정의된 것을 [로컬 좌표계] 기준으로 바꾸는 것


        if (Input.GetKey(KeyCode.LeftShift))        // 쉬프트 누르면 느리게 걷도록

        {
            _animator.SetFloat("MoveSpeed", local.z / 10);   //느리게 걷기
        }
        else
        {
            _animator.SetFloat("MoveSpeed", local.z);   //바로 달림

        }

    }

    public void Begin(Vector3 dest)
    {


        _actionManger.StartAction(this);

        To(dest);
    }

    public void To(Vector3 dest)
    {
        if (_agent != null && _agent.enabled)
        {
            _agent.destination = dest;
            _agent.isStopped = false;
        }
    }

    public void End()
    {
        if (_agent != null && _agent.enabled)
        {
           _agent.isStopped = true;
        }
    }





}
