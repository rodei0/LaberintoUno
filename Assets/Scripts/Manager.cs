using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public int totalCollect = 5;
    private int collectedCount = 0;
    private AudioSource audioSource;


    public GameObject door;
    public TMP_Text contador;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateContadorUI();
    }

    private void OnEnable()
    {
        Collect.OnCollected += UpdateCollectCount;
    }

    private void OnDisable()
    {
        Collect.OnCollected -= UpdateCollectCount;
    }

    private void UpdateCollectCount()
    {
        collectedCount++;
        Debug.Log($"Recolectados: {collectedCount}/{totalCollect}");

        UpdateContadorUI();
        
        if (collectedCount >= totalCollect) 
        {
            audioSource.Play();
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("Todos los objetos han sido obtenidos");
        if (door != null)
        {
            door.SetActive(false);
        }
    }

    private void UpdateContadorUI()
    {
        if (contador != null)
        {
            contador.text = $"{collectedCount} / {totalCollect}";
        }
    }
}
