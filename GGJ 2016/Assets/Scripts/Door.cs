using UnityEngine;
using System.Collections;
using System;

public class Door : ActivationObject
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    protected override void activate()
    {
        throw new NotImplementedException();
        if (!isInUse)
        {
            if (isActive)
            {

            }
            else
            {

            }
        }
    }
}
