using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _bulletSource;

    public Transform _firePosition;

    public int _poolSize = 10;
    public List<GameObject> _bulletObjectPool;

    void Start()
    {
        _bulletObjectPool = new List<GameObject>();

        for(int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletSource);
            _bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }


    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDAL //pc

        if (Input.GetButtonDown("Fire1"))
        {
            if(_bulletObjectPool.Count > 0)
            {
                GameObject bullet = _bulletObjectPool[0];
                bullet.SetActive(true);
                _bulletObjectPool.Remove(bullet);
                bullet.transform.position = _firePosition.position;
            }
        }
# endif
    }

    public void OnClick_Fire()
    {
            if (_bulletObjectPool.Count > 0)
            {
                GameObject bullet = _bulletObjectPool[0];
                bullet.SetActive(true);
                _bulletObjectPool.Remove(bullet);
                bullet.transform.position = _firePosition.position;
            }

    }
}
