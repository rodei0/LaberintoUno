using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private AudioSource audioSource;
    private bool played = false;
    // Start is called before the first frame update

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !played)
        {
            played = true;
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
