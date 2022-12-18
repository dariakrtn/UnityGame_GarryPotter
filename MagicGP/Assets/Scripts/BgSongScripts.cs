using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Скрипт для музыки на фоне
public class BgSongScripts : MonoBehaviour
{

    private static BgSongScripts instance = null;
    public static BgSongScripts Instance
    {
        get { return instance; }
    }
    void Start()
    {
        
    }
   
    private void Awake()
    {
        if (instance != null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
    }
}
