using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //게임 텍스트
    public GameObject Game_Text_Manager;
    public Text GameText;

    //남은몹 텍스트
    public Text Monster_Number_Text;

    public GameObject Enemy_Tower1;
    public GameObject Enemy_Tower2;
    public GameObject Enemy_Tower3;

    void Start()
    {
    }

    void Update()
    {
    }

    public void Win()
    {
        // (몬스터 다 죽거나) , 적타워 콜라이더에 닿았을때
        //EnemyManager EM = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        GameText.text = "승리하셨습니다!";
        Game_Text_Manager.SetActive(true);

    }


}
