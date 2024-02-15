using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;

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
            GetComponent<CharacterController>().enabled = false;
            transform.position = startPos;
            transform.rotation = startRot;
            GetComponent<CharacterController>().enabled = true;
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
            GetComponent<Animator>().Play("WIN00");
        }
    }
}
