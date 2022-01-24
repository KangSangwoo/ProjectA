using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // 속성효과_파티클
    public ParticleSystem Fire_Particle;
    public ParticleSystem Water_Particle;
    public ParticleSystem Ground_Particle;

    //파티클 제어 bool
    public bool Fire = true; 
    public bool Water = false; 
    public bool Ground = false;

    //유닛 스텟 정보
    public string _name= "Defender";
    public float _cost = 50;
    public float _atk = 50;
    public float _def = 60;
    public float _MaxHp = 250;
    public float _speed = 1.0f;
    //public float attribute = 0 ;   // 0불, 1,물, 2땅

    public GameObject Pm;


    void Start()
    {
    }

    void Update()
    {
    }

    //bool값 변경
    public void Set_Uint_Is_attribute(int _what_attribte)
    {
        if (_what_attribte == 1)        // 불속성 클릭 -> 불속성 부여
        {
            Debug.Log("클릭값 불");
            Fire = true;
            Water = false;
            Ground = false;
}
        else if (_what_attribte == 2)
        {
            Debug.Log("클릭값 물");
            Fire = false;
            Water = true;
            Ground = false;
        }
        else if (_what_attribte == 3)
        {
            Debug.Log("클릭값 땅");
            Fire = false;
            Water = false;
            Ground = true;
        }

        Set_Uint_attribute();
    }

    // 파티클 효과 플레이
    public void Set_Uint_attribute()      
    {
        if (Fire == true )
        {
            Debug.Log("파티컬 불");
            Fire_Particle.Play();           // 왜 실행이 안될까?..
            Water_Particle.Stop();
            Ground_Particle.Stop();
        }
        else if (Water == true)
        {
            Debug.Log("파티컬 물");
            Fire_Particle.Stop();
            Water_Particle.Play();
            Ground_Particle.Stop();
        }
        else if (Ground == true)
        {
            Debug.Log("파티컬 땅");
            Fire_Particle.Stop();
            Water_Particle.Stop();
            Ground_Particle.Play();
        }

        //플레이어 매니져가서 속성 초기화 함수실행
        //Pm.Reset_attribute();
        Pm.GetComponent<PlayerManager>().Reset_attribute();

    }






}
