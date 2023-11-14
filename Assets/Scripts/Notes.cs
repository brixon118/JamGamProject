using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] Text Note;
    [SerializeField] bool ShowNote;
    [SerializeField] bool InRange;
    [SerializeField, Multiline] string NoteText;

    
    void Start()
    {
        Note.color = Color.clear;
        Note.text = "Press `E` to read the note";
        ShowNote = false;
    }

    private void Update()
    {
        
        if (ShowNote && Note.color.a < 255)
        {
            Note.color = new Color(Note.color.r, Note.color.g, Note.color.b, Note.color.a + 1 * Time.deltaTime);  
        }

        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            Note.text = NoteText;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("2");
            ShowNote = true;
            InRange = true;
        }
        print("1");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}
