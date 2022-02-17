using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private string[] Scenes = { "Main", "inGame" };

    private int Index;

    void Start()
    {
        Index = 1;
    }

    public void LoadScene()
    {
        Scenes[Index];
    }
}
