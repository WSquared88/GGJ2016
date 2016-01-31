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
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            if (objectsToActivate[i])
            {
                ActivationObject obj = objectsToActivate[i].GetComponent<ActivationObject>();
                if (obj)
                {
                    obj.activate();
                }
            }
        }

        for (int i = 0; i < passables.Length; i++)
        {
            if (passables[i])
            {
                Collider objCollider = passables[i].GetComponent<Collider>();
                if (objCollider)
                {
                    Physics.IgnoreCollision(player, passables[i].GetComponent<Collider>());
                }
            }
        }

        if (isActiveAndEnabled)
        {
            Destroy(gameObject);
        }
    }
}
