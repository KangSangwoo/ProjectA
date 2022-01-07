using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text _finalScoreText;
    public Text _bestScoreText;

    void Start()
    {
        _finalScoreText.text = "최종점수 : " + SingletonManager.instance.CurrentScore;
        _bestScoreText.text = "최고점수 : " + SingletonManager.instance.BestScore;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickGoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
