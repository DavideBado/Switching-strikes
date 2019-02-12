using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool _PlayerType, OnEnemy, OnLimit;
    Animator PlayerAnim;
    public GameObject P_Enemy;
    bool AtHome;
    public GameManager GameManager;
    // Use this for initialization
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GoHome();
        _PlayerType = GameManager.PlayerType;
        PlayerAnim.SetBool("PlayerType1", _PlayerType);

        if (transform.position == new Vector3())
        {
            AtHome = true;
        }

        if (AtHome)
        {
            MoveThePlayer();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            OnEnemy = true;
            P_Enemy = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        OnEnemy = false;
    }

    void MoveThePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 1), 1f);
            AtHome = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -1), 1f);
            AtHome = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1, 0), 1f);
            AtHome = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1, 0), 1f);
            AtHome = false;
        }       
    }
    void GoHome()
    {
        if (OnLimit == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 1f);
            GameManager.PlayerType = !GameManager.PlayerType;
            OnLimit = false;
        }
    }
}
