using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Rules;
    public GameObject Spells;

    //Opening the game scene
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);

    }

    //Opening of the main scene
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }

    //Opening the Settings scene
    public void ButtonSetting()
    {
        SceneManager.LoadScene(2);
    }

    //Closing the application
    public void ButtonExit()
    {
        Application.Quit();

    }

    //Game start button lets start
    public void onClickStart()
    {
        Rules.SetActive(false);

        Spells.SetActive(true);
    }

}
