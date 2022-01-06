using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManger : MonoBehaviour
{

    public GameObject _Unit1Source = null;        // 유닛1 리소스

    public Transform _CreatePosition;     //생성 위치

    public GameObject _UnitButton;      // 유닛버튼


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

/*
public void OnClick_UnitButton1()
{
    GameObject Player = Instantiate(_Unit1Source); // 유닛 생성
    enermy.SetActive(true);             //  적 활성화
    this.transform.position = new Vector3(-6, 2, 0);    // 윗줄생산

}
*/
