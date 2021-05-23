using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInChildren<PlayerController>() != null) 
        {
            PlayerController player = other.GetComponentInChildren<PlayerController>();
            player.Respawn();
        }
    }
}

