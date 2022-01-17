using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerUPMenu : MonoBehaviour
{
    public Text GameText;
    public GameObject GameTextMenu;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick_TowerUP()
    {
        GameText.text = "<타워 레벨업> 버튼입니다";
        GameTextMenu.SetActive(true);
        
    }
}
