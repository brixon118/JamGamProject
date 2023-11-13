using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiEnemyCounter : MonoBehaviour
{
    TMP_Text uiText;


    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!uiText)
            return;
        uiText.text = "" + EnemyCounter.GetNumberOfActiveEnemyCounters();
    }
}
