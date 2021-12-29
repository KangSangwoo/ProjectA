using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 레이저 빛
public class RayTest : MonoBehaviour
{

    Ray _ray;

    void Start()
    {
        
    }

    void Update()
    {
        // 동적할당
        // _ray = new Ray(this.transform.position, this.transform.forward);
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //레이져를 눈에 보이도록 빨갛게
        Debug.DrawRay(_ray.origin, _ray.direction*100.0f, Color.red);

        // 충돌된 곳을 담는 장소 
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, 100.0f)==true)       //out:
        {
            Debug.Log(hit.transform);
        }
    }
}
