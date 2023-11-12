using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contraption : MonoBehaviour
{
    [SerializeField] private GameObject[] gates;
    [SerializeField] private bool[] gatesStartLocked;
    [SerializeField] private int energyQuota;

    private bool[] gatesLocked;

    // Start is called before the first frame update
    void Start()
    {
        gatesLocked = new bool[gates.Length];
        for (int i = 0; i < gates.Length; i++) gatesLocked[i] = gatesStartLocked[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetEnergyQuota()
    {
        return energyQuota;
    }

    void ChangeState()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(!gatesLocked[i]);
            gatesLocked[i] = !gatesLocked[i];
        }
    }
}
