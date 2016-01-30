using UnityEngine;
using System.Collections;
using System;

public class Key : InteractableObject
{

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
        throw new NotImplementedException();
    }
}
