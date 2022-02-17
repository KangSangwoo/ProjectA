using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // 상태를 열거형으로 나열함 
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    // 변수 선언
    EnemyState _state;


    //찾는 범위
    public float _findDistance = 10.0f;
    Transform _player;

    //공격 범위, 이동속도
    public float _attackDistance = 2.0f;
    public float _moveSpeed = 5.0f;

    CharacterController _cc;

    // 현재시간 , 공격 지연시간
    float _currentTime = 0;
    public float _attackDelay = 2.0f;

    // 공격력
    public int _attackPower = 5;

    //기본위치, 기본각도? , 이동 최대범위
    Vector3 _originPos;
    Quaternion _originRot;
    public float _moveDistance = 20.0f;

    // 체력
    public int _maxHp = 20;
    int _hp;

    // 체력바
    public Slider _hpBar;

    Animator _animator = null;
    NavMeshAgent _agent = null;

    void Start()
    {
        _state = EnemyState.Idle;                                   // 일단 Idle상태로 
        _player = GameObject.Find("Player").transform;              // 플레이어의 위치값을 찾는다
        _cc = this.GetComponent<CharacterController>();             // <케릭터 컨트롤러> 컴포넌트를 가져온다
        _originPos = this.transform.position;                       // 기본 위치
        _originRot = this.transform.rotation;                       // 기본 각도
        _hp = _maxHp;                                               // 기본 HP
        _animator = this.GetComponentInChildren<Animator>();        // 자식의 <에니메이터>컴포넌트 가져옴
        _agent = this.GetComponent<NavMeshAgent>();                 // <네비메쉬에이젼트> 컴포넌트 가져옴
    }

    void Update()
    {
        _hpBar.value = (float)_hp / (float)_maxHp;      // HP바의 수치값 변화

        switch (_state)     //스위치문으로 함수실행 상태구분
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
    }

    void Idle()
    {
        // 탐지범위 이내로 들어왔을시, 상태 전환 : Idle -> Move
        if (Vector3.Distance(this.transform.position, _player.position) < _findDistance)
        {
            _state = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");

            // 에니메이터 트리거 발동!
            _animator.SetTrigger("IdleToMove");
        }
    }

    void Move()
    {   //이동범위보다 멀리 떨어졌을시, 상태전환 : Move -> Return
        if (Vector3.Distance(this.transform.position, _originPos) > _moveDistance)
        {
            _state = EnemyState.Return;
            Debug.Log("상태 전환 : Move -> Return");
        }

        //공격범위보다 멀리 떨어졌을시,  플레이어에게 움직임
        else if (Vector3.Distance(this.transform.position, _player.position) > _attackDistance)
        {
            //Vector3 dir = (_player.position - this.transform.position).normalized;
            //_cc.Move(dir * _moveSpeed * Time.deltaTime);
            //this.transform.forward = dir;

            _agent.isStopped = true;
            _agent.ResetPath();

            _agent.stoppingDistance = _attackDistance;
            _agent.destination = _player.position;
        }

        // 공격범위 이내로 들어오면, 상태전환 : Move -> Attack
        else
        {
            _state = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
            _currentTime = _attackDelay;        // 바로공격하도록 

            _animator.SetTrigger("MoveToAttackDelay");
        }
    }

    void Attack()
    {
        if(Vector3.Distance(this.transform.position, _player.position) < _attackDistance)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime > _attackDelay)
            {
                //_player.GetComponent<PlayerMove>().DamageAction(_attackPower);
                Debug.Log("공격!");
                _currentTime = 0;

                _animator.SetTrigger("StartAttack");
            }
        }
        else
        {
            _state = EnemyState.Move;
            Debug.Log("상태 전환 : Attack -> Move");
            _currentTime = 0;

            _animator.SetTrigger("AttackToMove");
        }
    }

    void Return()
    {
        if(Vector3.Distance(this.transform.position, _originPos) > 0.1f)
        {
            //Vector3 dir = (_originPos - this.transform.position).normalized;
            //_cc.Move(dir * _moveSpeed * Time.deltaTime);
            //this.transform.forward = dir;

            _agent.stoppingDistance = 0;
            _agent.destination = _originPos;
        }
        else
        {
            _agent.isStopped = true;
            _agent.ResetPath();

            this.transform.position = _originPos;
            this.transform.rotation = _originRot;
            _hp = _maxHp;
            _state = EnemyState.Idle;
            Debug.Log("상태 전환 : Return -> Idle");

            _animator.SetTrigger("MoveToIdle");
        }
    }

    public void HitEnemy(int damage)
    {
        if (_state == EnemyState.Damaged || 
            _state == EnemyState.Die || 
            _state == EnemyState.Return) return;

        _hp -= damage;

        _agent.isStopped = true;
        _agent.ResetPath();

        if (_hp > 0)
        {
            _state = EnemyState.Damaged;
            Debug.Log("상태 전환 : AnyState -> Damaged");

            _animator.SetTrigger("Damaged");

            Damaged();
        }
        else
        {
            _state = EnemyState.Die;
            Debug.Log("상태 전환 : AnyState -> Die");

            _animator.SetTrigger("Die");

            Die();
        }
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1.0f);

        _state = EnemyState.Move;
        Debug.Log("상태 전환 : Damaged -> Move");
    }

    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        _cc.enabled = false;

        yield return new WaitForSeconds(2.0f);

        Debug.Log("소멸");
        Destroy(this.gameObject);
    }

    public void AttackAction()
    {
        _player.GetComponent<PlayerMove>().DamageAction(_attackPower);
    }
}
