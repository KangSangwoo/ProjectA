using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadController : MonoBehaviour
{
    //static string

    [SerializeField]
    private Image ProgressBar;
    private float CrossLine;

    void Start()
    {
        CrossLine = 0.05f;
    }

    public static void SetScene(string _SceneName)
    {
        Debug.Log(_SceneName);
    }

    IEnumerator LoadsceneDate()
    {
        //SceneManager
        //AsyncOperation; // 장면전환

        while(true)
        {
            yield return null;  // null로 하면 델타타임마다 호출이됨


        }

    }

    void Update()
    {
        
    }
}
