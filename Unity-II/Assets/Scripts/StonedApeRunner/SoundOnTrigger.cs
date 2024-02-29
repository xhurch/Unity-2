using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
