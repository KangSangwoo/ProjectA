using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    private void Awake()
    {
        if(GM == null)
        {
            GM = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }

    public GameState _gState;

    public Text _gameText;

    PlayerMove _player;

    void Start()
    {
        _gState = GameState.Ready;
        _gameText.text = "Ready....";
        _gameText.color = Color.yellow;

        StartCoroutine(GameStart());

        _player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {
        if(_player._hp <= 0)
        {
            _player.GetComponentInChildren<Animator>().SetFloat("MoveSpeed", 0);

            _gameText.gameObject.SetActive(true);
            _gameText.text = "Game Over";
            _gameText.color = Color.red;

            _gState = GameState.GameOver;
        }
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2.0f);

        _gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);

        _gameText.gameObject.SetActive(false);
        _gState = GameState.Run;
    }
}
