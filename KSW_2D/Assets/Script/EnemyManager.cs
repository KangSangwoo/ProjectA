using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    public GameObject _enemy1;
    public GameObject _enemy2;
    public GameObject _enemy3;
    public GameObject _enemy4;


    //생성시간
    float _currentTime;
    public float _createTime = 1.0f;
    float _minTime = 2.0f;      // 생성시간 랜덤범위
    float _maxTime = 3.0f;

    //에너미 풀
    public int _poolSize = 10;                      // 적의 총 갯수
    public List<GameObject> _enemyObjectPool;       // 적 리스트
    public int Monster_Number;                      // 적 갯수
    public Text Monster_Number_txt;           // 적 갯수 텍스트

    public Transform _CreatePosition1;     //생성 위치1
    public Transform _CreatePosition2;     //생성 위치2
    public Transform _CreatePosition3;     //생성 위치3


    /*
 * 몬스터 리스폰 => 100을 4분할해서 랜덤확률로 몬스터가 소환됨
 * 확률은 강함에 따라 차등을 둠 => 1~50 약 / 51~70 중 / 71~90 중 / 91~100강 
*/

    void Start()
    {
        _createTime = Random.Range(_minTime, _maxTime);

        GameObject enemy;

        _enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)     // 10까지 반복해서 생성
        {
            int rand = Random.Range(1, 100);          // 랜덤확률에서 생성

            if (rand <= 30)
            {
                enemy = Instantiate(_enemy1);
            }
            else if (rand <= 60)
            {
                enemy = Instantiate(_enemy2);
            }
            else if (rand <= 80)
            {
                enemy = Instantiate(_enemy3);
            }
            else
            {
                enemy = Instantiate(_enemy4);

            }
            _enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }

        // 남은몹 갯수 표시
        //Monster_Number_txt.text = Monster_Number;

    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _createTime)     // 만약 N초가 지나면 (start에서 랜덤화)
        {
            if (_enemyObjectPool.Count > 0)
            {
                GameObject enemy = _enemyObjectPool[0];  // 리스트 처음으로 넣음
                _enemyObjectPool.Remove(enemy);          // 오브젝트풀에서 제거

                int rand = Random.Range(1,3);          // 랜덤라인에서 생성
                if (rand == 1)
                {
                    enemy.transform.position = _CreatePosition1.position;
                }
                else if (rand == 2)
                {
                    enemy.transform.position = _CreatePosition2.position;
                }
                else if (rand == 3)
                {
                    enemy.transform.position = _CreatePosition3.position;
                }
                enemy.SetActive(true);  // 활성화 시킴
            }
            _currentTime = 0;

            _createTime = Random.Range(_minTime, _maxTime);



        }

    }
}
