using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingMenu : MonoBehaviour
{
    public Text GameText;
    public GameObject GameTextMenu;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick_Setting()
    {
        GameText.text = "<환경설정> 버튼입니다";
        GameTextMenu.SetActive(true);

    }
}
