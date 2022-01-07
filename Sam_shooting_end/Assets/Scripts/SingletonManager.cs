using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int CurrentScore { get; set; }
    public int BestScore { get; set; }
    public int PlaneNumber { get; set; }
}
