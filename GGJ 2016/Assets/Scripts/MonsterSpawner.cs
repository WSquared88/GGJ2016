using UnityEngine;
using System.Collections;
using System;

public class MonsterSpawner : ActivationObject
{
    [SerializeField]
    GameObject monster;
    [SerializeField]
    bool OneTimeSpawn;
    [SerializeField]
    float spawnCooldown;

    float timeSinceLastSpawn;
    bool monsterSpawned;

	// Use this for initialization
	void Start ()
    {
        timeSinceLastSpawn = spawnCooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawn += Time.deltaTime;
	}

    public override void activate()
    {
        if (!(OneTimeSpawn && monsterSpawned) && timeSinceLastSpawn >= spawnCooldown && monster)
        {
            Instantiate(monster, transform.position, Quaternion.identity);
            timeSinceLastSpawn = 0;
            monsterSpawned = true;
        }
    }
}
