using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGround : MonoBehaviour
{
    float time;


    void Update()
    {
        time += Time.deltaTime;

        if (time%10<3)
        {
            this.GetComponent<Image>().color = Color.white;

        }
        else if (time%10<6)
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else
        {
            this.GetComponent<Image>().color = Color.gray;

        }
    }
}
