using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float fallThreshold = -10f;
 

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            RespawnPlayer();
        }
    }
    void RespawnPlayer()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            if (TryGetComponent<CharacterController>(out CharacterController controller))
            {
                controller.enabled = false;
                controller.enabled = true;
            }
        }

    }
}
