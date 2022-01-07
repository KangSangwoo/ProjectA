using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _player;

    public GameObject _js;  //조이스틱

    public GameObject _fb;  //파이어버튼

    private void Awake()
    {
#if UNITY_ANDROID // 폰

        _fb.SetActive(true);
        _js.SetActive(true);

#elif UNITY_EDITOR || UNITY_STANDAL //pc
    _fb.SetActive(False);
    _js.SetActive(False);
#endif
    }

    void Start()
    {
        SingletonManager.instance.CurrentScore = 0;
        SingletonManager.instance.BestScore = PlayerPrefs.GetInt("BestScore");

        GameObject plane = Instantiate(Resources.Load<GameObject>("Prefab/Plane_" + SingletonManager.instance.PlaneNumber));
        plane.transform.position = _player.transform.position;
        plane.transform.parent = _player.transform;
    }
}


