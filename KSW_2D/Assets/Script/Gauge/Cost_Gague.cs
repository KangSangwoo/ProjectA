using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cost_Gague : MonoBehaviour
{
    public Image img;
    public Slider CostBar;
    public Text cost_txt;

    float cost = 0;
    public float plus_cost = 1.0f;
    float cost_max = 500.0f;

    void Start()
    {
        Set_cost(200);    //처음에 코스트0으로 시작
    }


    void Update()
    {
        Change_cost();  // 코스트 변화
    }


    public void Change_cost()
    {
        cost += plus_cost * Time.deltaTime;      // 코스트 1씩 계속 오름
        Set_cost(cost);
    }


    public void Set_cost(float _cost)
    {
        cost = _cost;           // 입력받은 코스트를 변수로

        string txt = "";
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
            txt = string.Format("Cost: {0:N0}/{1}", cost, cost_max); //수치표기
            cost_txt.text = txt;
        }

        CostBar.value = cost / cost_max;        // 이미지 채우기
        //img.fillAmount = cost / cost_max;     // 이미지 채우기


    }
}
