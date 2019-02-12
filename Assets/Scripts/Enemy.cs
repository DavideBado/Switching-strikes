using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool _EnemyType;
    Animator anim;

	// Use this for initialization

	void Awake () {
        anim = GetComponent<Animator>();
        _EnemyType = RandomBool();
        anim.SetBool("Enemy1", _EnemyType);
	}
	
	// Update is called once per frame
	void Update () {
        Movement();

    }
    bool RandomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        else return false;
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(), 1f * Time.deltaTime);
    }
}
