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

        isActive = !isActive;
    }
}
