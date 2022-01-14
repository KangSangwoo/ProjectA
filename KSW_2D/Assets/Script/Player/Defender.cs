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
    public bool Fire = false; 
    public bool Water = false; 
    public bool Ground = false; 

    //유닛 스텟 정보
    public float _cost;
    public float _atk;
    public float _def;
    public float _MaxHp;
    public float _speed = 1.0f;
    //public float attribute = 0 ;   // 0불, 1,물, 2땅


    void Start()
    {
        _cost = 50;
        _atk = 50;
        _def = 60;
        _MaxHp = 250;
        _speed = 1.0f;
        //Playeranager Pm = new PlayerManager();       

         Fire = false;
         Water = false;
         Ground = false;    
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
        }
        else if (_what_attribte == 2)
        {
            Debug.Log("클릭값 물");
            Water = true;
        }
        else if (_what_attribte == 3)
        {
            Debug.Log("클릭값 땅");
            Ground = true;
        }
        else return;

        Set_Uint_attribute();
    }

    // 파티클 효과 플레이
    public void Set_Uint_attribute()      
    {
        if (Fire == true )
        {
            Debug.Log("파티컬 불");
            Fire_Particle.Play();
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
        else return;

    }






}
