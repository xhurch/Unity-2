using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    public static int health;

    bool subtractHealth;

    // Start is called before the first frame update
    void Start()
    {
        subtractHealth = true;
        health = 100;
        InvokeRepeating("SubtractHealth", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            LivesManager.lives--;
            print(LivesManager.lives);
            StartCoroutine(PlayerReborn());
        }
    }

    void SubtractHealth()
    {
        if(subtractHealth)
        {
            health -= 20;
            health = Mathf.Clamp(health, 0, 100);
            healthBar.value = health;
        }
        
    }

    IEnumerator PlayerReborn()
    {
        health = 100;
        subtractHealth = false;
        GetComponent<Animator>().Play("DAMAGED01");
        yield return new WaitForSeconds(3.5f);
        healthBar.value = health;
        subtractHealth = true;
    }
}
