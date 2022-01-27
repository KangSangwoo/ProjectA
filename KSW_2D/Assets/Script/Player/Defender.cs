using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // 속성효과_파티클
    public ParticleSystem Fire_Particle;
    public ParticleSystem Water_Particle;
    public ParticleSystem Ground_Particle;

    //유닛 스텟 정보
    public string _name= "Defender";
    public float _cost = 50;
    public float _atk = 50;
    public float _def = 60;
    public float _MaxHp = 250;
    public float _speed = 1.0f;
    public string _attribute;   // fire , water, ground

   // public GameObject Pm;


    void Start()
    {
    }

    void Update()
    {
    }

    public void Set_Uint_attribute()
    {
        switch (_attribute)
        {
            case "fire":        // 불속성 클릭 -> 불속성 부여
            Debug.Log("클릭값 불");

            Fire_Particle.Play();           // 왜 실행이 안될까?
            Water_Particle.Stop();
            Ground_Particle.Stop();
            break;

            case "water":
            Debug.Log("클릭값 물");
            Fire_Particle.Stop();
            Water_Particle.Play();
            Ground_Particle.Stop();
            break;

            case "Ground":
            Debug.Log("클릭값 땅");
            Fire_Particle.Stop();
            Water_Particle.Stop();
            Ground_Particle.Play();
            break;
        }

    }

 
        
    }






