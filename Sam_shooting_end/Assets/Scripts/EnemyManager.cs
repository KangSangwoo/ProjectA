using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject _enemySource;

    float _currentTime;
    public float _createTime = 1.0f;

    float _minTime = 0.1f;
    float _maxTime = 1.5f;

    public Transform[] _spawnPoints;
    public int _poolSize = 10;
    public List<GameObject> _enemyObjectPool;

    void Start()
    {
        _createTime = Random.Range(_minTime, _maxTime);

        _enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject enemy = Instantiate(_enemySource);
            _enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime > _createTime)
        {
            if (_enemyObjectPool.Count > 0)
            {
                GameObject enemy = _enemyObjectPool[0];
                _enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, _spawnPoints.Length);
                enemy.transform.position = _spawnPoints[index].position;
                enemy.SetActive(true);
            }

            _currentTime = 0;

            _createTime = Random.Range(_minTime, _maxTime);
        }

    }
}
