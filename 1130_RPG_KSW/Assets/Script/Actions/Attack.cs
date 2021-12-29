using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour , IEnd
{
    // 버튼이 공격대상일떄 - 공격범위 판단 - 범위내로 이동 - 범위내면 공격 실행 

    //데미지
    [SerializeField]
    [Range(1.0f, 20.0f)]
    float _weoponDamage = 5.0f;


    //공격범위
    [SerializeField]
    [Range(1.0f, 3.0f)]
    float _range = 2.0f;

    //딜레이
    [SerializeField]
    [Range(1.0f, 3.0f)]
    float _attackDelay = 2.0f;
    float _lastAttack = 0.0f;   


    HealthPoint _target = null;
    Movement _movement = null;
    ActionManger _actionManger = null;
    Animator _animator = null;
    HealthPoint _healthPoint = null;

    private void Awake()
    {
        _movement = this.GetComponent<Movement>();
        _actionManger = this.GetComponent<ActionManger>();
        _animator = this.GetComponentInChildren<Animator>();
        _healthPoint = this.GetComponent<HealthPoint>();
    }

    void Start()
    {
        _lastAttack = _attackDelay;
    }

    void Update()
    {


        _lastAttack += Time.deltaTime;

        if (_target == null) return;    // 타겟이 없으면 여기서 반환

        if (_target.IsDead == true)  // 타겟이 죽으면 여기서 반환
        {
            _animator.ResetTrigger("Attack");
            return;
        }


        if (_healthPoint.IsDead) return;

        if (IsinRange() == false)   //타겟범위가 아닐경우, 타겟으로 이동해라
        {
            _movement.To(_target.transform.position);

        }
        else // 타겟범위이내일 경우, 이동을 멈추고 애니메이션 실행해라
        {
            _movement.End();

            PlayAnimation();
        }
    }

    //타겟설정해라
    public void Begin(GameObject target)
    {
        _actionManger.StartAction(this);

        _target = target.GetComponent<HealthPoint>();
    }

    // 공격멈춰라
    public void End()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");


        _target = null;
    }

    //공격범위
    private bool IsinRange()
    {
        Vector2 targetPoint = new Vector2(_target.transform.position.x, _target.transform.position.z);
        Vector2 Point = new Vector2(this.transform.position.x, this.transform.position.z);

        return Vector2.Distance(targetPoint, Point) < _range;

    }

    // 공격모션호출
    private void PlayAnimation()
    {
        this.transform.LookAt(_target.transform);   // 적을 바라보도록

       // FollowTarget();// 적이 나를 바라보도록


        //_target.transform.LookAt(this.transform);   // 적이 나를 보도록


        if (_lastAttack < _attackDelay) return; //마지막 공격후 2초(딜레이)가 지나면 실행, 아니면 반환

        _animator.SetTrigger("Attack"); // 공격 트리거 set

        _lastAttack = 0.0f;     // 다시 마지막 공격 0초로 초기화
    }

    // 공격데미지
    public void Hit()
    {
        Debug.Log("공격이벤트 발생");

        if (_target == null) return;
        if (IsinRange() == false) return;       

        _target.Damage(_weoponDamage, this.transform);      //타겟에게 데미지 입힘
    }

    public bool CanAttack(GameObject target)
    {
        if (target == null) return false;

        HealthPoint hp = target.GetComponent<HealthPoint>();
        return hp != null && hp.IsDead == false;
    }





    // 적이 나를 바라보는 함수
    /*
    public void FollowTarget()
     {
        // 방향백터구하기
        Vector3 dir = this.transform.position - _target.transform.position; 
        //적 회전 시키기 (회전 보간)
         _target.transform.rotation = Quaternion.Lerp(_target.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
     } 

        public void FollowTarget()  // 타겟이 내쪽으로 서서히 위치를 바꿈 
        {
            _target.transform.position = Vector3.Lerp(_target.transform.position, this.transform.position, Time.deltaTime);

        }
     */

}


