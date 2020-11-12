using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayScene1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayScene2()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayScene4()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayScene5()
    {
        SceneManager.LoadScene(5);
    }
    public void PlayScene6()
    {
        SceneManager.LoadScene(6);
    }
    public void EndScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
