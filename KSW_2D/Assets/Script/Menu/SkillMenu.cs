using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillMenu : MonoBehaviour
{
    public Text GameText;
    public GameObject GameTextMenu;


    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick_Skill()
    {
        GameText.text = "<스킬사용> 버튼입니다";
        GameTextMenu.SetActive(true);

    }
}
