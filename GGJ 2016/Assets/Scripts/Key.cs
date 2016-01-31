using UnityEngine;
using System.Collections;
using System;

public class Key : InteractableObject
{
    [SerializeField]
    GameObject[] passables;

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
        bool didWork = false;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            ActivationObject obj = objectsToActivate[i].GetComponent<ActivationObject>();
            if (obj)
            {
                obj.activate();
                didWork = true;
            }
        }

        for (int i = 0; i < passables.Length; i++)
        {
            Collider objCollider = passables[i].GetComponent<Collider>();
            if (objCollider)
            {
                Physics.IgnoreCollision(player, passables[i].GetComponent<Collider>());
                didWork = true;
            }
        }

        if (didWork && isActiveAndEnabled)
        {
            Destroy(gameObject);
        }
    }
}
