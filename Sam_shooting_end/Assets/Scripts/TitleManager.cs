using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    public Image _pcb_1;
    public Image _pcb_2;
    public Image _pcb_3;

    void Start()
    {
        SingletonManager.instance.PlaneNumber = 0;
    }

    void Update()
    {
        
    }

    public void OnClick_GameStart()
    {
        if (SingletonManager.instance.PlaneNumber == 0) return;

        SceneManager.LoadScene("GameScene");
    }

    public void OnClick_PCB()
    {
        _pcb_1.color = Color.white;
        _pcb_2.color = Color.white;
        _pcb_3.color = Color.white;

        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "PCB_1":
                _pcb_1.color = Color.red;
                SingletonManager.instance.PlaneNumber = 1;
                break;
            case "PCB_2":
                _pcb_2.color = Color.yellow;
                SingletonManager.instance.PlaneNumber = 2;
                break;
            case "PCB_3":
                _pcb_3.color = Color.green;
                SingletonManager.instance.PlaneNumber = 3;
                break;
        }
    }

}
