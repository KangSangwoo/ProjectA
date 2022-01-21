using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float _moveSpeed = 10.0f;
    CharacterController _cc;

    float _gravity = -20.0f;
    float _yVelocity = 0;

    public float _jumpPower = 10.0f;

    bool _isJumping = false;

    public int _maxHp = 20;
    public int _hp;

    public Slider _hpBar;

    public GameObject _hitEffect;

    Animator _animator = null;

    void Start()
    {
        _cc = this.GetComponent<CharacterController>();
        _hp = _maxHp;
        _animator = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (GameManager.GM._gState != GameManager.GameState.Run) return;

        _hpBar.value = (float)_hp / (float)_maxHp;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        _animator.SetFloat("MoveSpeed", dir.magnitude);

        dir = Camera.main.transform.TransformDirection(dir);

        if(_cc.collisionFlags == CollisionFlags.Below)
        {
            if(_isJumping)
            {
                _isJumping = false;
            }

            _yVelocity = 0;
        }

        if(Input.GetButtonDown("Jump") && _isJumping == false)
        {
            _yVelocity = _jumpPower;
            _isJumping = true;
        }

        _yVelocity += _gravity * Time.deltaTime;
        dir.y = _yVelocity;

        _cc.Move(dir * _moveSpeed * Time.deltaTime);
    }

    public void DamageAction(int damage)
    {
        _hp -= damage;

        if(_hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        _hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        _hitEffect.SetActive(false);
    }
}
