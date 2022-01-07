using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _currentScoreText;
    private int _currentScore;

    public Text _bsetScoreText;
    private int _bestScore;

    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _bsetScoreText.text = "최고 점수 : " + _bestScore;
    }

    void Update()
    {
        
    }

    public int Score
    {
        get
        {
            return _currentScore;
        }
        set
        {
            _currentScore = value;

            _currentScoreText.text = "현재 점수 : " + _currentScore;

            SingletonManager.instance.CurrentScore = _currentScore;

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
                _bsetScoreText.text = "최고 점수 : " + _bestScore;

                PlayerPrefs.SetInt("BestScore", _bestScore);

                SingletonManager.instance.BestScore = _bestScore;
            }
        }
    }
}
