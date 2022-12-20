using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for music in the background
public class BgSongScripts : MonoBehaviour
{

    private static BgSongScripts instance = null;
    public static BgSongScripts Instance
    {
        get { return instance; }
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
}
