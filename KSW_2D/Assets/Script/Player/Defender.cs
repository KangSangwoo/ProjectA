using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // 속성효과_파티클
    public ParticleSystem Fire_Particle;
    public ParticleSystem water_Particle;
    public ParticleSystem ground_Particle;

    public bool Fire = true; //파티클 제어 bool
    public bool Water = true; //파티클 제어 bool
    public bool Ground = true; //파티클 제어 bool


    //public ParticleSystem a;


    public float _cost;
    public float _atk;
    public float _def;
    public float _MaxHp;
    public float _speed = 1.0f;
    public float attribute = 0 ;   // 0불, 1,물, 2땅


    void Start()
    {
        _cost = 50;
        _atk = 50;
        _def = 60;
        _MaxHp = 250;
        _speed = 1.0f;

        //PlayerManager Pm = new PlayerManager();       
    }

    void Update()
    {
        Set_Uint_fire();
        Set_Uint_water();
        Set_Uint_ground();

        if (attribute == 0)
        {
           // Set_Uint_fire();
        }
        else if (attribute == 1)
        {
           // Set_Uint_water();

        }
        else if (attribute == 2)
        {
           // Set_Uint_ground();

        }
    }

    public void Set_Uint_fire()    
    {
        if (Fire)
            Fire_Particle.Play();
        else if (!Fire)
            Fire_Particle.Stop();
    }

    public void Set_Uint_water()
    {
        if (Water)
            water_Particle.Play();
        else if (!Fire)
            water_Particle.Stop();
    }

    public void Set_Uint_ground()
    {
        if (Ground)
            ground_Particle.Play();
        else if (!Fire)
            ground_Particle.Stop();
    }





}
