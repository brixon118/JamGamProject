using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonOptions : MonoBehaviour
{
    public void PlayButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void UnPauseButton()
    {
        Time.timeScale = 1;
    }

    public void CloseAppButton()
    {
        Application.Quit();
    }


}
