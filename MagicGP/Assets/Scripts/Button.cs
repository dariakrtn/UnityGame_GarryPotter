using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Rules;
    public GameObject Spells;

    //Открытие сцены игры
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);

    }

    //Открытия главной сцены
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }

    //Открытия сцены настроек
    public void ButtonSetting()
    {
        SceneManager.LoadScene(2);
    }

    //Закрытие приложения
    public void ButtonExit()
    {
        Application.Quit();

    }
    public void onClickStart()
    {
        Rules.SetActive(false);

        Spells.SetActive(true);
    }

}
