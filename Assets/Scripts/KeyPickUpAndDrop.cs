using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPickUpAndDrop : MonoBehaviour
{
    public LayerMask mask;
    public Transform thisKeyHole;

    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI energyQuotaText;

    private int energy;

    // Start is called before the first frame update
    void Start()
    {
        energyQuotaText.gameObject.SetActive(false);
    }
    private float cooldown = 0;
    // Update is called once per frame
    void Update()
    {
        energyQuotaText.gameObject.SetActive(false);
        
        cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        /*
        if (cooldown > 0 || thisKeyHole == null || !Input.GetButtonDown("Jump"))
            return;
        */
        Collider2D collider = Physics2D.OverlapBox(transform.position, Vector2.one, 0, mask);

        if (collider == null)
            return;

        if (collider.gameObject.tag == "KeyHoleEnemy")
        {
            if (cooldown <= 0 && Input.GetKeyDown(KeyCode.Space))
            {
                collider.gameObject.GetComponent<KeyHole>().Lock();
                energy++;
                energyText.text = energy + "";
                cooldown = 0.5f;
            }
            else
            {
                energyQuotaText.gameObject.SetActive(true);
                energyQuotaText.text = "Press space to deactivate.";
            }
        }
        else if (collider.gameObject.tag == "KeyHoleSwitch")
        {
            KeyHole keyHole = collider.gameObject.GetComponent<KeyHole>();
            int quota = keyHole.GetEnergyQuota();
            if (keyHole.GetUnlocked())
            {
                if (Input.GetKeyDown(KeyCode.Space)) keyHole.Lock();
            }
            else if (keyHole.GetMetEnergyQuota())
            {
                if (!keyHole.GetUnlocked() && Input.GetKeyDown(KeyCode.Space))
                {
                    keyHole.Unlock();
                    cooldown = 0.5f;
                }
            }
            else if (energy < quota)
            {
                energyQuotaText.gameObject.SetActive(true);
                energyQuotaText.text = quota + " energy unit" + (quota == 1 ? "" : "s") + " required to activate.";
            }
            else if (cooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    energy -= quota;
                    energyText.text = energy + "";
                    keyHole.Unlock();
                    cooldown = 0.5f;
                }
                else
                {
                    energyQuotaText.gameObject.SetActive(true);
                    energyQuotaText.text = "Press space to activate.";
                }
            }
        }

        /*
        Key thisKey = thisKeyHole.GetComponentInChildren<Key>();
        Key otherKey = collider.gameObject.GetComponentInChildren<Key>();
        Transform otherKeyHole = collider.gameObject.transform;

        if (thisKey == null && otherKey != null)
        {
            otherKey.transform.parent = thisKeyHole;
            otherKey.transform.position = thisKeyHole.position;
            otherKey.transform.rotation = thisKeyHole.rotation;
            cooldown = 0.5f;
        }

        if (thisKey != null && otherKey == null)
        {
            thisKey.transform.parent = otherKeyHole;
            thisKey.transform.position = otherKeyHole.position;
            thisKey.transform.rotation = otherKeyHole.rotation;
            cooldown = 0.5f;
        }
        */
    }
}
