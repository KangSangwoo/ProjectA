using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exp_Gague : MonoBehaviour
{
    public Slider expBar;
    public Text exp_txt;

    float exp = 0;
    public float plus_exp = 1.0f;
    float exp_max = 1000.0f;

    void Start()
    {
        Set_exp(0);    //처음에 코스트0으로 시작
    }


    void Update()
    {
        Change_exp();
    }


    public void Change_exp()
    {
        exp += plus_exp * Time.deltaTime;      // 코스트 1씩 계속 오름
        Set_exp(exp);
    }


    public void Set_exp(float _exp)
    {
        exp = _exp;           // 입력받은 코스트를 변수로

        string txt = "";
        if (exp <= 0)
        {
            exp = 0;       // 0이하면 0 (이럴경우 없긴함)
        }
        else
        {
            if (exp > exp_max)
            {
                exp = exp_max;        // max 못넘게
            }
            txt = string.Format("Exp: {0:N0}/{1}", exp, exp_max); //수치표기
            exp_txt.text = txt;
        }

        expBar.value = exp / exp_max;// 이미지 채우기


    }
}

