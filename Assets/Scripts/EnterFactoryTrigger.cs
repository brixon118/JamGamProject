using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFactoryTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioForest;
    [SerializeField] private AudioSource audioFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerControls>() == null) return;
        audioForest.Stop();
        audioFactory.Play();
    }
}
