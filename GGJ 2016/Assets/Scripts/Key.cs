﻿using UnityEngine;
using System.Collections;
using System;

public class Key : InteractableObject
{
    GameObject door;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    protected override void Trigger(Collider player)
    {
        if (door)
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }
}