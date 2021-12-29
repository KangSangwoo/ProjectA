using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 이동 => 카메라도 이동
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    Transform _player = null;

    [SerializeField]
    [Range(2.0f, 10.0f)]        // 수치조절하는 바가 생긴다
    float _lerpSpeed = 5.0f;

    [SerializeField]
    [Range(3.0f, 10.0f)]
    float _distance = 5.0f;

    Transform _maincamera = null;



    void Start()
    {
        _maincamera = this.transform.GetChild(0);   // 메인카메라를 0번쨰 자식으로 넣어라
    }

    void Update()
    {
        if (_player != null)
        {
            //this.transform.position = _player.position; // 플레이어 따라이동
            this.transform.position = Vector3.Lerp(this.transform.position, 
                _player.position, _lerpSpeed * Time.deltaTime);              // Lerp : a값알면 b 자동으로 구함


            _maincamera.localPosition = new Vector3(0, _distance, -_distance);   // 로컬포지션으로 해야됨 (월드 X)

        }

    }
}
