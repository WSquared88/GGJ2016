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
        for(int i = 0;i<objectsToActivate.Length;i++)
        {
            ActivationObject obj = objectsToActivate[i].GetComponent<ActivationObject>();
            if (obj)
            {
                obj.activate();
                if (isActiveAndEnabled)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
