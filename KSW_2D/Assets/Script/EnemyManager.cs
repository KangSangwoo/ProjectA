using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    public GameObject _enemy1_Source;
    public GameObject _enemy2_Source;
    public GameObject _enemy3_Source;
    public GameObject _enemy4_Source;

    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject enemy4;


    //생성시간
    float _currentTime;
    public float _createTime = 1.0f;
    float _minTime = 2.0f;      // 생성시간 랜덤범위
    float _maxTime = 3.0f;

    //에너미 풀
    public int _poolSize = 10;                      // 적의 총 갯수
    public List<GameObject> _enemyObjectPool;       // 적 리스트
    public int Monster_Number = 0;                      // 적 갯수
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

        _enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)     // 10까지 반복해서 생성
        {
            int rand = Random.Range(1, 100);          // 랜덤확률에서 생성

            if (rand <= 30)
            {
                enemy1 = Instantiate(_enemy1_Source);
            }
            else if (rand <= 60)
            {
                enemy1 = Instantiate(_enemy2_Source);
            }
            else if (rand <= 80)
            {
                enemy1 = Instantiate(_enemy3_Source);
            }
            else
            {
                enemy1 = Instantiate(_enemy4_Source);
            }
            _enemyObjectPool.Add(enemy1);
            enemy1.SetActive(false);
        }

        //몬스터 스텟 정보
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _createTime)     // 만약 N초가 지나면 (start에서 랜덤화)
        {
            if (_enemyObjectPool.Count > 0)
            {
                GameObject enemy1 = _enemyObjectPool[0];  // 리스트 처음으로 넣음
                _enemyObjectPool.Remove(enemy1);          // 오브젝트풀에서 제거

                int rand = Random.Range(1,3);          // 랜덤라인에서 생성
                if (rand == 1)
                {
                    enemy1.transform.position = _CreatePosition1.position;
                }
                else if (rand == 2)
                {
                    enemy1.transform.position = _CreatePosition2.position;
                }
                else if (rand == 3)
                {
                    enemy1.transform.position = _CreatePosition3.position;
                }
                enemy1.SetActive(true);  // 활성화 시킴

                Monster_Number++;
                Monster_Number_txt.text = string.Format("{0}/{1}",_poolSize - Monster_Number, _poolSize);   // 남은몹 갯수표시

            }
            _currentTime = 0;

            _createTime = Random.Range(_minTime, _maxTime);



        }

    }
}
