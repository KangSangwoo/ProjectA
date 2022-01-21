using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    EnemyState _state;

    public float _findDistance = 10.0f;
    Transform _player;

    public float _attackDistance = 2.0f;
    public float _moveSpeed = 5.0f;

    CharacterController _cc;

    float _currentTime = 0;
    public float _attackDelay = 2.0f;

    public int _attackPower = 5;

    Vector3 _originPos;
    Quaternion _originRot;
    public float _moveDistance = 20.0f;

    public int _maxHp = 20;
    int _hp;

    public Slider _hpBar;

    Animator _animator = null;
    NavMeshAgent _agent = null;

    void Start()
    {
        _state = EnemyState.Idle;
        _player = GameObject.Find("Player").transform;
        _cc = this.GetComponent<CharacterController>();
        _originPos = this.transform.position;
        _originRot = this.transform.rotation;
        _hp = _maxHp;
        _animator = this.GetComponentInChildren<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _hpBar.value = (float)_hp / (float)_maxHp;

        switch (_state)
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
        if(Vector3.Distance(this.transform.position, _player.position) < _findDistance)
        {
            _state = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");

            _animator.SetTrigger("IdleToMove");
        }
    }

    void Move()
    {
        if(Vector3.Distance(this.transform.position, _originPos) > _moveDistance)
        {
            _state = EnemyState.Return;
            Debug.Log("상태 전환 : Move -> Return");
        }
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
        else
        {
            _state = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
            _currentTime = _attackDelay;

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
