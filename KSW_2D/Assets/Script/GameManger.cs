using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManger : MonoBehaviour
{

    //유닛 리소스
    public GameObject _Unit1_Source ;       
    public GameObject _Unit2_Source ;        
    public GameObject _Unit3_Source ;       
    public GameObject _Unit4_Source ;        

    //생성위치
    public Transform _CreatePosition1;     
    public Transform _CreatePosition2;     
    public Transform _CreatePosition3;     

    //유닛버튼
    public GameObject _UnitButton1;      
    public GameObject _UnitButton2;      
    public GameObject _UnitButton3;      
    public GameObject _UnitButton4;      

    //유닛 정보
    public Text Info_txt_1;         // 이름 
    public Text Info_txt_2;         // 코스트,체력
    public Text Info_txt_3;         // 공격,방어,스피드
    public GameObject Canvas_Left;  // 레벨 스톤, 테두리
    string txt_1 = "";
    string txt_2 = "";
    string txt_3 = "";

    // 속성선택
    public GameObject canvas_right_down;    // 캔버스
    public GameObject attribute1;   // 불
    public GameObject attribute2;   // 물
    public GameObject attribute3;   // 땅
    bool Is_attribute = false;

    

    // 소환 위치 선택
    public GameObject WhereStones;
    public GameObject WhereStone1;
    public GameObject WhereStone2;
    public GameObject WhereStone3;


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnClick_UnitButton1()
    {
        GameObject player1 = Instantiate(_Unit1_Source); // 유닛1 생성
        player1.SetActive(false);

        //유닛 정보 출력
        Canvas_Left.SetActive(true);
        txt_1 = string.Format("{0}", "Defender"); 
        Info_txt_1.text = txt_1;
        txt_2 = string.Format("Cost:{0} HP: {1}", 50, 150);
        Info_txt_2.text = txt_2;
        txt_3 = string.Format("공격:{0} 방어:{1} 속도:{2}", 50, 60, 3);
        Info_txt_3.text = txt_3;

        //속성선택
        canvas_right_down.SetActive(true);

        // 줄선택
        player1.transform.position = _CreatePosition1.position;    


    }

    // 속성선택 함수_불
    public void OnClick_attribute_1()
    {
        Is_attribute = true;

    }


    // 줄 선택 함수_1
    public void OnClick_WhereStone_1()
    {
        if (Is_attribute)
        {
            WhereStones.SetActive(true);
        }


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


