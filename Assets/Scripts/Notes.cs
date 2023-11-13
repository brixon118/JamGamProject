using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] Text Note;
    [SerializeField] bool ShowNote;
    void Start()
    {
        Note.color = Color.clear;
        ShowNote = false;
    }

    private void Update()
    {
        if (ShowNote && Note.color.a < 255)
        {
            Note.color = new Color(Note.color.r, Note.color.g, Note.color.b, Note.color.a + 1 * Time.deltaTime);  
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("2");
            ShowNote = true;
        }
        print("1");
    }
}
