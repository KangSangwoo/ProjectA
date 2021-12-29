using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyController : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10.0f)]
    float _searchRange = 5.0f;

    GameObject _player = null;


    Attack _attack = null;
    HealthPoint _healthPoint = null;
    Movement _movement = null;
    ActionManger _actionManger = null;


    Vector3 _initPosition;       //최초위치

    [SerializeField]
    float _waitTime = 3.0f;                         //대기3초
    float _playerLastTime = Mathf.Infinity;        // 마지막으로 쫒아간 시간 => 처음에 무한으로 초기화

    [SerializeField]
    WayPoint _wayPoint = null;
    int _currwaypointindex = 0;

    [SerializeField]
    float _waypointDistance = 1.0f;


    private void Awake()
    {
        _attack = this.GetComponent<Attack>();
        _healthPoint = this.GetComponent<HealthPoint>();
        _movement = this.GetComponent<Movement>();
        _actionManger = this.GetComponent<ActionManger>();
    }


    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _initPosition = this.transform.position;
    }


    void Update()
    {
        if (_healthPoint.IsDead) return;

        if (IsinRange() && _attack.CanAttack(_player))
        {
            Attack();
        }
        else if (_playerLastTime < _waitTime)       // 마지막으로 쫒아간 시간이 3초이내면 멈춤
        {

            _actionManger.StopAction();
        }
        else
        {
         Patrol();
        }

        _playerLastTime += Time.deltaTime; 

    }

    private void Attack()
    {
        _attack.Begin(_player);     //액션 실행
        _playerLastTime = 0.0f;
    }

    private void StopAction()
    {
        _actionManger.StopAction();
    }

    //순찰
    private void Patrol()
    {
        Vector3 next = _initPosition;

        if (_wayPoint != null)
        {
            if (IsNearWaypoint())
            {
                _currwaypointindex = _wayPoint.GetNextIndex(_currwaypointindex);
            }
            next = GetCurrWaypoint();
        }

        _movement.Begin(next);
    }

    private bool IsNearWaypoint()       
    {
        Vector2 point = new Vector2(this.transform.position.x, this.transform.position.z);      
        Vector2 waypoint = new Vector2(GetCurrWaypoint().x, GetCurrWaypoint().z);

        return Vector2.Distance(point, waypoint) < _waypointDistance;
    }

    private Vector3 GetCurrWaypoint()
    {
        return _wayPoint.GetWayPoint(_currwaypointindex);
    }

    private bool IsinRange()
    {
        Vector2 targetPoint = new Vector2(_player.transform.position.x, _player.transform.position.z);  // 플레이어의 위치 
        Vector2 Point = new Vector2(this.transform.position.x, this.transform.position.z);              // 적의 위치
                
      //  _dis = Vector2.Distance(targetPoint, Point);
        return Vector2.Distance(targetPoint, Point) < _searchRange;     // 적과 플레이어의 거리 < 수색범위 ===> 참

    }

    float _dis = 0.0f;
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 20), _dis.ToString());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, _searchRange);   //중앙값, 스케일값
    }

}
