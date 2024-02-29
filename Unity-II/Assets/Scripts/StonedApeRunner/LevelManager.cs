using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;

    public static int levelNumber = 0;
    public int numLevels = 3;

    // public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            StartCoroutine(Respawn());
        }
        else if(other.tag == "Checkpoint")
        {   
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            Destroy(other.gameObject);
        }
        else if(other.tag == "Goal")
        {
            Destroy(other.gameObject);
            StartCoroutine(Goal());
        }
    }

    IEnumerator Respawn()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        DisableCharacter();
        transform.position = startPos;
        transform.rotation = startRot;
        GetComponent<Animator>().Play("LOSE00");
        yield return new WaitForSeconds(3.5f);
        EnableCharacter();
    }

    // public void PlayerReborn()
    // {
    //     HealthManager.health = 0;
    //     healthBar.value = HealthManager.health;
    //     HealthManager.health = 100;
    //     GetComponent<Animator>().Play("DAMAGED01");
    // }

    IEnumerator Goal()
    {
        yield return new WaitForSeconds(0.15f);
        DisableCharacter();
        GetComponent<Animator>().Play("WIN00");
        yield return new WaitForSeconds(3.5f);
        EnableCharacter();
        NextLevel();
    }

    void DisableCharacter()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonController>().enabled = false;
    }

    void EnableCharacter()
    {
        GetComponent<CharacterController>().enabled = true;
        GetComponent<ThirdPersonController>().enabled = true;
    }

    void NextLevel()
    {
        levelNumber++;

        if(levelNumber == numLevels)
        {
            levelNumber = 0;
        }

        SceneManager.LoadScene(levelNumber);
    }
}
