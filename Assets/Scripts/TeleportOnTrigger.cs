using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportOnTrigger : MonoBehaviour
{
    public string tagToTeleport = "Player";
    public Vector3 placeToTeleportTo = Vector3.zero;
    [SerializeField] string MainMenuSceneName = "MainMenu";

    [SerializeField] GameObject GameOverScreen;
    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
    
    public void Retry()
    {
        TimeToggle();
        GameOverScreen.SetActive(false);
    }

    private void Start()
    {
        GameOverScreen.SetActive(false);
    }


    public void TimeToggle()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        print(collision.gameObject.name);
        if (collision.gameObject.tag != tagToTeleport)
            return;
        collision.gameObject.transform.position = placeToTeleportTo;

        GameOverScreen.SetActive(true);
        TimeToggle();
    }

}
