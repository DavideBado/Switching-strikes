using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool _PlayerType, OnEnemy, OnLimit;
    Animator PlayerAnim;
    bool isMovingUp, isMovingDown, isMovingLeft, isMovingRight, isMoving;
    public GameObject P_Enemy;
    bool AtHome;
    public GameManager GameManager;
    public float Speed = 2f;
    // Use this for initialization
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        _PlayerType = GameManager.PlayerType; // Aggiorna la variabile locale relativa alla natura del giocatore con quella del gamemanager
        PlayerAnim.SetBool("PlayerType1", _PlayerType); // Cambia colore al giocatore in relazione alla sua natura
        OnEnemyCheck();
        MoveThePlayer(); // Controlla se ci sono input relativi al movimento

    }

    public void OnTriggerEnter(Collider other) // Controlla le collisioni
    { 
        if (other.tag == "Enemy") // Controlla se è in collisione con un nemico, se sì:
        {
            OnEnemy = true; // Avvisa il gamemanager
            P_Enemy = other.gameObject; // Passa al gamemanager il nemico
        }
    }
    void OnEnemyCheck() // Controlla se sono a contatto con un nemico
    { if(P_Enemy == null) 
        OnEnemy = false; // Non è più a contatto con un nemico
    }

    void MoveThePlayer() // Input del giocatore
    {
        if (Input.GetKeyDown(KeyCode.W) && isMoving == false) // Se il giocatore non è in movimento e viene premuto il tasto W
        {
            isMovingUp = true; // Si sta muovendo in alto
            isMoving = true; // Si sta muovendo 
        }
            if (isMovingUp) // Se si sta muovendo in alto
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,1), Speed * Time.deltaTime); // Sposta il giocatore verso il limite superiore dell'arena
            if (transform.position == new Vector3(0, 1)) { isMovingUp = false; isMoving = false; } // Se ha raggiunto il limite non si sta più muovendo
            }
        
        if (Input.GetKeyDown(KeyCode.S) && isMoving == false)  // Se il giocatore non è in movimento e viene premuto il tasto S
        {
            isMovingDown = true;  // Si sta muovendo in basso
            isMoving = true; // Si sta muovendo 
        }
        if (isMovingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -1), Speed * Time.deltaTime); // Sposta il giocatore verso il limite inferiore dell'arena
            if (transform.position == new Vector3(0, -1)) { isMovingDown = false; isMoving = false; } // Se ha raggiunto il limite non si sta più muovendo
        }

        if (Input.GetKeyDown(KeyCode.A) && isMoving == false)  // Se il giocatore non è in movimento e viene premuto il tasto A
        {
            isMovingLeft = true;  // Si sta muovendo a sinistra
            isMoving = true; // Si sta muovendo 
        }
        if (isMovingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1, 0), Speed * Time.deltaTime); // Sposta il giocatore verso il limite sinistro dell'arena
            if (transform.position == new Vector3(-1, 0)) { isMovingLeft = false; isMoving = false; } // Se ha raggiunto il limite non si sta più muovendo

        }
        if (Input.GetKeyDown(KeyCode.D) && isMoving == false)  // Se il giocatore non è in movimento e viene premuto il tasto D
        {
            isMovingRight = true;  // Si sta muovendo a destra
            isMoving = true; // Si sta muovendo 
        }
        if (isMovingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1, 0), Speed * Time.deltaTime); // Sposta il giocatore verso il limite destro dell'arena
            if (transform.position == new Vector3(1, 0)) { isMovingRight = false; isMoving = false; } // Se ha raggiunto il limite non si sta più muovendo
        }
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 1f); // Riporta a casa il giocatore
        GameManager.PlayerType = !GameManager.PlayerType; // Cambia la natura del giocatore
        isMovingDown = false; // Da qui
        isMovingLeft = false;
        isMovingRight = false; // Il giocatore non si sta muovendo
        isMovingUp = false;
        isMoving = false; // Fino a qui
    }
}
