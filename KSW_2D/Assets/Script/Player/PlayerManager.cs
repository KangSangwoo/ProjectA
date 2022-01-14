using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class PlayerManager : MonoBehaviour
{

    //유닛 리소스
    public GameObject _Unit1_Source ;       
    public GameObject _Unit2_Source ;        
    public GameObject _Unit3_Source ;       
    public GameObject _Unit4_Source ;

    //생성된 유닛
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

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
    int what_attribte;



    // 속성효과_파티클
    //public GameObject Fire_Particle;
    //public GameObject water_Particle;
    //public GameObject ground_Particle;


    // 소환 위치 선택
    public GameObject WhereStones;
    public GameObject WhereStone1;
    public GameObject WhereStone2;
    public GameObject WhereStone3;

    // 유닛 배열로
    int[] players = new int[] { 1, 2, 3, 4 };       //인덱스 알아보기



    void Start()
    {
    }

    void Update()
    {

    }

    //유닛버튼1 클릭
    public void OnClick_UnitButton1()
    {
        player1 = Instantiate(_Unit1_Source); // 유닛1 생성
        player1.SetActive(false);             // 일단 비활성화
        player1.GetComponent<PlayerMove>();

        //유닛 정보 출력 
        Canvas_Left.SetActive(true);
        txt_1 = string.Format("{0}", "Defender"); 
        Info_txt_1.text = txt_1;
        txt_2 = string.Format("Cost:{0} HP: {1}", 50, 150);
        Info_txt_2.text = txt_2;
        txt_3 = string.Format("공격:{0} 방어:{1} 속도:{2}", 50, 60, 3);
        Info_txt_3.text = txt_3;

        //속성 선택창 활성화
        canvas_right_down.SetActive(true);
    }

    // 속성선택 함수1_불
    public void OnClick_attribute_1()
    {
        Debug.Log("불속성 선택함");

        what_attribte = 1;
        Canvas_Left.SetActive(false);           // 상태/속성창 비활성화하고 속성선택 완료 함수 실행
        canvas_right_down.SetActive(false);
       // attribute1 = Instantiate(Fire_Particle);       //파티클 오브젝트로 생성
       // attribute1.transform.position = player1.transform.position;     // 유닛의 위치로
        Is_attribute_done();

    }

    // 속성선택 함수2_물
    public void OnClick_attribute_2()
    {
        what_attribte = 2;
        Canvas_Left.SetActive(false);
        canvas_right_down.SetActive(false);
        Is_attribute_done();
    }
    
    // 속성선택 함수3_땅
    public void OnClick_attribute_3()
    {
        what_attribte = 3;
        Canvas_Left.SetActive(false);
        canvas_right_down.SetActive(false);
        Is_attribute_done();
    }


    // 속성선택 완료하면 출력하는 함수
    public void Is_attribute_done()
    {
        //unit_color.color = Color.red;     
        if (what_attribte == 1)
        {
            Debug.Log("속성선택완료");
            WhereStones.SetActive(true);        // 소환위치버튼 활성화
            player1.GetComponent<Defender>().Set_Uint_Is_attribute(what_attribte);   // 속성bool값 변경 -> 파티클효과 플레이
            what_attribte = 0;                  // 속성 초기화
            Debug.Log("속성초기화");


        }
        else if (what_attribte == 2)
        {
            WhereStones.SetActive(true);
            player1.GetComponent<Defender>().Set_Uint_Is_attribute(what_attribte);
            what_attribte = 0;                  // 속성 초기화
        }
        else if (what_attribte == 3)
        {
            WhereStones.SetActive(true);
            player1.GetComponent<Defender>().Set_Uint_Is_attribute(what_attribte);
            what_attribte = 0;                  // 속성 초기화
        }

        Debug.Log("속성선택함");
    }



    // 줄 선택 함수_1
    public void OnClick_WhereStone_1()
    {
        player1.transform.position = _CreatePosition1.position;     //1번 줄에서 생성
        player1.SetActive(true);             // 플레이어 활성화
        WhereStones.SetActive(false);

    }

    // 줄 선택 함수_2
    public void OnClick_WhereStone_2()
    {
        player1.transform.position = _CreatePosition2.position;     //2번 줄에서 생성
        player1.SetActive(true);             
        WhereStones.SetActive(false);
        what_attribte = 0;                  // 속성 초기화

    }

    // 줄 선택 함수_3
    public void OnClick_WhereStone_3()
    {
        player1.transform.position = _CreatePosition3.position;     //3번 줄에서 생성
        player1.SetActive(true);             
        WhereStones.SetActive(false);
        what_attribte = 0;                  // 속성 초기화

    }




    // 유닛2 생성
    public void OnClick_UnitButton2()
    {
        GameObject player2 = Instantiate(_Unit2_Source); 
        player2.transform.position = _CreatePosition2.position;    

    }

    // 유닛3 생성
    public void OnClick_UnitButton3()
    {
        GameObject player3 = Instantiate(_Unit3_Source); 
        player3.transform.position = _CreatePosition3.position;    

    }

    // 유닛4 생성
    public void OnClick_UnitButton4()
    {
        GameObject player4 = Instantiate(_Unit4_Source); 
        player4.transform.position = _CreatePosition1.position;    

    }





}


