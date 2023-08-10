using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvBtn : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;

    public void Main()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Main_2()
    {
        SceneManager.LoadScene("MainScene2");
    }

    public void Main_3()
    {
        SceneManager.LoadScene("MainScene3");
    }

    public void Main_4()
    {
        SceneManager.LoadScene("MainScene4");
    }
}
