using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _firePosition;
    public GameObject _bombSource;

    public float _throwPower = 15.0f;

    public GameObject _bulletEffect;
    ParticleSystem _ps;

    public int _WeaponPower = 5;

    Animator _animator = null;

    enum WeaponMode
    {
        Normal,
        Sniper
    }
    WeaponMode _weaponMode;

    bool _zoomMode = false;

    void Start()
    {
        _ps = _bulletEffect.GetComponent<ParticleSystem>();
        _animator = this.GetComponentInChildren<Animator>();
        _weaponMode = WeaponMode.Normal;
    }

    void Update()
    {
        if (GameManager.GM._gState != GameManager.GameState.Run) return;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60.0f;
            _zoomMode = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponMode = WeaponMode.Sniper;
        }

        if (Input.GetMouseButtonDown(1))
        {
            switch(_weaponMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(_bombSource);
                    bomb.transform.position = _firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * _throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper:
                    if(_zoomMode == false)
                    {
                        Camera.main.fieldOfView = 15.0f;
                        _zoomMode = true;
                    }
                    else
                    {
                        Camera.main.fieldOfView = 60.0f;
                        _zoomMode = false;
                    }
                    break;
            }

            
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(_animator.GetFloat("MoveSpeed") == 0)
            {
                _animator.SetTrigger("Attack");
            }

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyController ec = hit.transform.GetComponent<EnemyController>();
                    ec.HitEnemy(_WeaponPower);
                }
                else
                {
                    _bulletEffect.transform.position = hit.point;
                    _bulletEffect.transform.forward = hit.normal;
                    _ps.Play();
                }
            }
        }
    }
}
