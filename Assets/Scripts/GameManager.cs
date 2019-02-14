using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*************************************ATTENZIONE*************************************
 * ORA CHE LA VELOCITÀ DEI NEMICI AUMENTA È NECESSARIO MODIFICARE IL RITMO DI SPAWN *
 ************************************************************************************/

public class GameManager : MonoBehaviour {
    public Text Pointstext, Tutorialtext;
    public bool PlayerType, EnemyType, Tutorial = true;
    public int Points = 0, Life = 1;
    int TutorialEnemy;
    public GameObject Player, EnemyPref;
    GameObject Enemy, NewEnemy, Spawner;
    float SpawnTime, SavedSpawnTime = 5f;
    float TimeForSpeed = 0;
    public float EnemySpeedManagerValue = 1;
    // Use this for initialization
    void Start () {
        SpawnTime = SavedSpawnTime;
        PlayerType = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerInput();      
        EnemySpawner();
        Point();
        UpdateText();
        TutorialUpdate();
        EnemySpeedManager();
    }

    void PlayerInput() // Controlla se il giocatore vuole cambiare natura manualmente
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Se preme la barra spaziatrice
        {
            PlayerType = !PlayerType; // Cambia la natura del giocatore
        }
    }

    public void Point() // Conta i punti e in generale le interazioni del giocatore con i nemici
    {
        if (Player.GetComponent<Player>().OnEnemy) // Se il giocatore è a contatto con un nemico
        {
            Enemy = Player.GetComponent<Player>().P_Enemy; // Prendi il nemico
            if (PlayerType == Enemy.GetComponent<Enemy>()._EnemyType) // Se la natura del nemico è uguale a quella del giocatore
            {
                Points++; // Aumenta il punteggio di uno
                Destroy(Enemy); // Distruggi il nemico
                Player.GetComponent<Player>().GoHome(); // Rimanda a casa il giocatore, cambiagli natura e avvisa che non si sta più muovendo         
            }
            else // Se la tipologia del nemico non è uguale a quella del giocatore
            {
                Life--; // Togli una vita al giocatore
                Destroy(Enemy); // Distruggi il nemico
                if(Life <= 0) // Se la vita è minore o uguale di zero
                {
                    UnityEditor.EditorApplication.isPlaying = false; // Chiudi la partita, questo comando non funziona in una build quindi è necessario cambiarlo prima di crearla
                }
            }
        }
    }
    void EnemySpawner() // Generatore di nemici
    {
        SpawnTime -= Time.deltaTime; // Aspetta il momento giusto per creare un nemico
        if(SpawnTime <= 0)  // Se è giunta l'ora di creare un nemico
        {
            SpawnPoint(); // Controlla dove crearlo
            NewEnemy = GameObject.Instantiate(EnemyPref, Spawner.transform); // Crealo e posizionalo
            SpawnTime = SavedSpawnTime; // Riporta il timer al suo valore iniziale 
        }
    }

    void SpawnPoint() // Selettore di luoghi di nascita dei nemici
    {
        int SpawnSelector;
        if (Tutorial == false)
            SpawnSelector = Random.Range(0, 3); // Genera un valore random compreso tra 0 e 3
        else SpawnSelector = 3;
        if(SpawnSelector == 0) // Se è uguale a 0
        {
            Spawner = GameObject.Find("SpawnN"); // Il nemico nasce a nord
        }
        if (SpawnSelector == 1) // Se è uguale a 1
        {
            Spawner = GameObject.Find("SpawnS"); // Il nemico nasce a sud
        }
        if (SpawnSelector == 2) // Se è uguale a 2
        {
            Spawner = GameObject.Find("SpawnE"); // Il nemico nasce a est
        }
        if (SpawnSelector == 3) // Se è uguale a 3
        {
            Spawner = GameObject.Find("SpawnW"); // Il nemico nasce a ovest
        }
    }

    void UpdateText() // Aggiorna i testi a schermo
    {
        Pointstext.text = "Points:" + Points;
        if (Tutorial == true && Points == 1) Tutorialtext.text = "Press space";
        else Tutorialtext.text = "";
    }

    void TutorialUpdate() // Spegne il "tutorial"
    {
        if (Points >= 2) Tutorial = false;
    }
    void EnemySpeedManager()
    {
        TimeForSpeed += Time.deltaTime;
       if(TimeForSpeed > 10f) // Ogni 10 secondi
        {
            TimeForSpeed = 0;
            EnemySpeedManagerValue++; // Aumenta la velocità dei nemici di uno
        }
    }
}
