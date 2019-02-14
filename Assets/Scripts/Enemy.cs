using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool _EnemyType;
    Animator anim;
    public float EnemySpeed;
    public GameObject GameManager;

    // Use this for initialization

    void Awake () {
      
        GameManager = GameObject.Find("GameManager");
        EnemySpeed = GameManager.GetComponent<GameManager>().EnemySpeedManagerValue;
        anim = GetComponent<Animator>();
        if (GameManager.GetComponent<GameManager>().Tutorial == false) // Se il tutorial è finito
        { _EnemyType = RandomBool(); }// La natura del nemico è uguale alla booleana generata
        else _EnemyType = true; // Se il tutorial non è finito i nemici sono solo rossi
        anim.SetBool("Enemy1", _EnemyType); // Modifica il colore del nemico in relazione alla sua natura
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
    }
    bool RandomBool() // Generatore di booleane random
    {
        if (Random.value >= 0.5) // Ritorna un valore compreso tra 0 e 1, se il questo valore è maggiore uguale di 0.5
        {
            return true; // La booleana è uguale a true
        }
        else return false; // Se il valore è minore di 0.5 la booleana è uguale a false
    }

    void Movement() // Muove i nemici
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(), EnemySpeed * Time.deltaTime); // Muove i nemici verso il centro dell'arena
    }
}
