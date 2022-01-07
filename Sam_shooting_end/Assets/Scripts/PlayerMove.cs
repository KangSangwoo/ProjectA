using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _speed = 5.0f;

    public FixedJoystick Joystick;  //  설치한 조이스틱을 이용

    void Start()
    {
        
    }

    void Update()
    {
        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.transform.position += new Vector3(-1.0f, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.transform.position += new Vector3(+1.0f, 0, 0);
        //}

#if UNITY_ANDROID   // 안드로이드 전처리

        Vector3 dir = Vector3.right * Joystick.Horizontal + Vector3.up * Joystick.Vertical; 


#elif UNITY_EDITOR || UNITY_STANDAL //pc

        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.right * h + Vector3.up * v;
#endif




        this.transform.Translate(dir * _speed * Time.deltaTime);

        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        this.transform.position = Camera.main.ViewportToWorldPoint(pos);


        //if(this.transform.position.x <= -2.5f)
        //{
        //    this.transform.position = new Vector3(-2.5f, this.transform.position.y, this.transform.position.z);
        //}
        //
        //if (this.transform.position.x >= 2.5f)
        //{
        //    this.transform.position = new Vector3(2.5f, this.transform.position.y, this.transform.position.z);
        //}
        //
        //if (this.transform.position.y <= -4.3f)
        //{
        //    this.transform.position = new Vector3(this.transform.position.x, -4.3f, this.transform.position.z);
        //}
        //
        //if (this.transform.position.y >= 4.5f)
        //{
        //    this.transform.position = new Vector3(this.transform.position.x, 4.5f, this.transform.position.z);
        //}

    }
}