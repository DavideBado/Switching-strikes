using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool PlayerType, EnemyType;
    public int Points, Life;
    public GameObject Player, EnemyPref;
    GameObject Enemy, NewEnemy, Spawner;
    float SpawnTime, SavedSpawnTime = 5f;
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


    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerType = !PlayerType;
        }
    }

    public void Point()
    {
        if (Player.GetComponent<Player>().OnEnemy)
        {
            Enemy = Player.GetComponent<Player>().P_Enemy;
            if (PlayerType == Enemy.GetComponent<Enemy>()._EnemyType)
            {
                Points++;
                PlayerType = !PlayerType;
                Destroy(Enemy);
                
            }
            else
            {
                Life--;
                Destroy(Enemy);
                if(Life <= 0)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            }
        }
    }
    void EnemySpawner()
    {
        SpawnTime -= Time.deltaTime;
        if(SpawnTime <= 0)
        {
            SpawnPoint();
            NewEnemy = GameObject.Instantiate(EnemyPref, Spawner.transform);
            SpawnTime = SavedSpawnTime;
        }
    }

    void SpawnPoint()
    {
        int SpawnSelector;
        SpawnSelector = Random.Range(0, 3);
        if(SpawnSelector == 0)
        {
            Spawner = GameObject.Find("SpawnN");
        }
        if (SpawnSelector == 1)
        {
            Spawner = GameObject.Find("SpawnS");
        }
        if (SpawnSelector == 2)
        {
            Spawner = GameObject.Find("SpawnE");
        }
        if (SpawnSelector == 0)
        {
            Spawner = GameObject.Find("SpawnW");
        }
    }
}
