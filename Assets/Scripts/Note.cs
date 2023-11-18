using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject noteScreen;
    [SerializeField] private GameObject canvasToHide;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private AudioSource musicToStop;
    [SerializeField] private AudioSource musicToPlay;

    // Start is called before the first frame update
    void Start()
    {
        noteScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControls>() == null) return;
        pauseManager.SetPaused(true);
        canvasToHide.SetActive(false);
        noteScreen.SetActive(true);
        if (musicToStop != null) musicToStop.Stop();
        if (musicToPlay != null) musicToPlay.Play();
        Destroy(gameObject);
    }
}
