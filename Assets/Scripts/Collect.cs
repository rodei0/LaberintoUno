using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public delegate void CollectedAction();
    public static event CollectedAction OnCollected;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) 
        {
            audioSource.Play(); 
            OnCollected?.Invoke();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
