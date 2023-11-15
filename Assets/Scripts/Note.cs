using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject noteScreen;
    [SerializeField] private GameObject[] canvasesToHide;
    [SerializeField] private PauseManager pauseManager;

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
        foreach (GameObject c in canvasesToHide) c.SetActive(false);
        noteScreen.SetActive(true);
        Destroy(gameObject);
    }
}
