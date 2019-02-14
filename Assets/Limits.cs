using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Controlla le collisioni
    {
        if(other.tag == "Player") // Se a collidere è il giocatore
        {            
            other.GetComponent<Player>().GoHome(); // Rimanda a casa il giocatore, cambiagli natura e avvisa che non si sta più muovendo
        }
    }
}
