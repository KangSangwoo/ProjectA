using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UnitUPMenu : MonoBehaviour
{
    public Text GameText;
    public GameObject GameTextMenu;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick_UnitUP()
    {
        GameText.text = "<유닛 레벨업> 버튼입니다";
        GameTextMenu.SetActive(true);

    }
}
