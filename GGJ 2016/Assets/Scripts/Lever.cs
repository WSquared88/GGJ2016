using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class Lever : InteractableObject
{
    [SerializeField]
    bool isActive;

	// Use this for initialization
	void Start ()
    {
		gameObject.GetComponent<Animator> ();
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
