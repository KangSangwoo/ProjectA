using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManger : MonoBehaviour
{

    public GameObject _Unit1_Source ;        // 유닛1 리소스
    public GameObject _Unit2_Source ;        // 유닛2 리소스
    public GameObject _Unit3_Source ;        // 유닛3 리소스
    public GameObject _Unit4_Source ;        // 유닛4 리소스

    public Transform _CreatePosition1;     //생성 위치1
    public Transform _CreatePosition2;     //생성 위치2
    public Transform _CreatePosition3;     //생성 위치3

    public GameObject _UnitButton1;      // 유닛버튼1
    public GameObject _UnitButton2;      // 유닛버튼2
    public GameObject _UnitButton3;      // 유닛버튼3
    public GameObject _UnitButton4;      // 유닛버튼4


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnClick_UnitButton1()
    {
        

        GameObject player1 = Instantiate(_Unit1_Source); // 유닛1 생성
        player1.transform.position = _CreatePosition1.position;    

    }

    public void OnClick_UnitButton2()
    {
        GameObject player2 = Instantiate(_Unit2_Source); // 유닛2 생성
        player2.transform.position = _CreatePosition2.position;    

    }

    public void OnClick_UnitButton3()
    {
        GameObject player3 = Instantiate(_Unit3_Source); // 유닛3 생성
        player3.transform.position = _CreatePosition3.position;    

    }

    public void OnClick_UnitButton4()
    {
        GameObject player4 = Instantiate(_Unit4_Source); // 유닛4 생성
        player4.transform.position = _CreatePosition1.position;    

    }





}


