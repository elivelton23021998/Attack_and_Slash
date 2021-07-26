using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiProjetil : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projetil"))
        {
            Destroy(other.gameObject);
        }

        
    }
}
