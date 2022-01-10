using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sp_Gague : MonoBehaviour
{
    public Image img;
    public Slider SpBar;
    public Text Sp_txt;

    float Sp = 0;
    public float plus_Sp = 3.0f;
    float Sp_max = 100.0f;

    void Start()
    {
        Set_Sp(0);    //처음에 0으로 시작
    }


    void Update()
    {
        Change_Sp();
    }


    public void Change_Sp()
    {
        Sp += plus_Sp * Time.deltaTime;      // 코스트 1씩 계속 오름
        Set_Sp(Sp);
    }


    public void Set_Sp(float _Sp)
    {
        Sp = _Sp;           // 입력받은 코스트를 변수로

        string txt = "";
        if (Sp <= 0)
        {
            Sp = 0;       // 0이하면 0 (이럴경우 없긴함)
        }
        else
        {
            if (Sp > Sp_max)
            {
                Sp = Sp_max;        // max 못넘게
            }
            txt = string.Format("Sp: {0:N0}/{1}", Sp, Sp_max); //수치표기
            Sp_txt.text = txt;
        }

        SpBar.value = Sp / Sp_max;// 이미지 채우기


    }
}

