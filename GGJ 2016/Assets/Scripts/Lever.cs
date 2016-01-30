using UnityEngine;
using System.Collections;

public class Lever : InteractableObject
{
    [SerializeField]
    bool isActive;

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
        if (objectToActivate)
        {
            ActivationObject obj = objectToActivate.GetComponent<ActivationObject>();
            if (obj)
            {
                obj.activate();
                isActive = !isActive;
            }
        }
    }
}
