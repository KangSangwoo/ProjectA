using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cost_Gague : MonoBehaviour
{
    // 코스트 이미지
    public Image img;
    public Slider CostBar;
    public Text cost_txt;

    //게임 텍스트
    public GameObject Game_Text_Manager;
    public Text GameText;

    //코스트 관련
    public float cost = 0;
    public float plus_cost = 5.0f;
    float cost_max = 500.0f;

    public GameObject PM;


    void Start()
    {
        Set_cost(80);    //처음에 코스트0으로 시작
    }
    
    void Update()
    {
        Change_cost();  // 코스트 변화
    }

    // 코스트 변화
    public void Change_cost()
    {
        cost += plus_cost * Time.deltaTime;      // 코스트 1씩 계속 오름
        Set_cost(cost);
    }

    //유닛소환
    public void Unit_Sommon(float _cost)
    {

        if (_cost <= cost)
        {
            Set_cost(cost - _cost);
        }
        else 
        {
            Set_cost(cost);
            GameText.text = "코스트가 부족합니다";
            Game_Text_Manager.SetActive(true);
            
            Invoke("GameTextOff", 2f);
            //PM.GetComponent<PlayerManager>().Not_summon();

        }
    }



    // 게임텍스트
    public void GameTextOff()   
    {
        Game_Text_Manager.SetActive(false);
    }

    //코스트 설정
    public void Set_cost(float _cost)
    {
        cost = _cost;           // 입력받은 코스트를 변수로

        if (cost <= 0)
        {
            cost = 0;       // 0이하면 0 (이럴경우 없긴함)
        }
        else
        {
            if (cost > cost_max)
            {
                cost = cost_max;        // max 못넘게
            }

            cost_txt.text = string.Format("Cost: {0:N0}/{1}", cost, cost_max); //수치표기 , 소숫점없이
        }

        CostBar.value = cost / cost_max;        // 이미지 채우기 => 밸류값

        //img.fillAmount = cost / cost_max;     // 이미지 채우기

    }
}
