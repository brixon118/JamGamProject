using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static List<EnemyCounter> enemyCounterList = new();

    private void OnEnable()
    {
        enemyCounterList.Add(this);
    }
    private void OnDisable()
    {
        enemyCounterList.Remove(this);
    }

    public static int GetNumberOfActiveEnemyCounters()
    {
        for (int i = enemyCounterList.Count - 1; i >= 0; i--)
        {
            if (enemyCounterList[i] == null)
                enemyCounterList.RemoveAt(i);
        }

        return enemyCounterList.Count;
    }

}
