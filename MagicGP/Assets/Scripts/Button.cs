using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Rules;
    public GameObject Spells;

    //�������� ����� ����
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);

    }

    //�������� ������� �����
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }

    //�������� ����� ��������
    public void ButtonSetting()
    {
        SceneManager.LoadScene(2);
    }

    //�������� ����������
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
