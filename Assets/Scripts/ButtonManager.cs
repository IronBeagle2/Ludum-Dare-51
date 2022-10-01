using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MenuMain");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void About()
    {
        SceneManager.LoadScene("AboutGame");
    }
}
