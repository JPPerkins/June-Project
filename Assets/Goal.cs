using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInChildren<PlayerController>() != null) 
        {
            Debug.Log("You Win!");
        }
    }
}
