using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Gague : MonoBehaviour
{
    
    public GameObject HP_Bar_prefeb;
    public GameObject cnavas;

    RectTransform hp_bar;

    public float height = 1.7f;

    void Start()
    {
        hp_bar = Instantiate(HP_Bar_prefeb, cnavas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y + height, 0));

        hp_bar.position = _hpBarPos;
    }
}
