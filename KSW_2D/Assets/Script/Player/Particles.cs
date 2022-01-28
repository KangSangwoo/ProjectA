using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    // 속성효과_파티클
    public ParticleSystem Fire_Particle;
    public ParticleSystem Water_Particle;
    public ParticleSystem Ground_Particle;

    public GameObject player1;

    void Start()
    {
        //접근하는거 어케하지
        Fire_Particle.Stop();
        
        Debug.Log("파티클 나와라");

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("파티클 마우스 누름");
            Fire_Particle.Play();
            }



        if (player1.GetComponent<Defender>()._attribute == "fire")
        {
            Fire_Particle.Play();
            Debug.Log("파티클 불");
        } 
        else if (player1.GetComponent<Defender>()._attribute != "fire")
            Fire_Particle.Stop();
    }
}
