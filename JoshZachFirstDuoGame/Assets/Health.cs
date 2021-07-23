using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int maxHealth;
    private int currHealth;

    public float invulnDelay;
    private float invulnTimer;

    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        health.text = maxHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }
    }

    public int updateHealth(int change)
    {
        if (change < 0)
        {
            if (invulnTimer <= 0)
            {
                currHealth += change;//Deals damage
                invulnTimer = invulnDelay;
            }
        } else
        {
            currHealth += change;//Heals
        }
        

        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

        health.text = currHealth.ToString();

        Debug.Log(currHealth);
        return currHealth;
    }

    public void resetHealth()
    {
        updateHealth(maxHealth);
    }
}
