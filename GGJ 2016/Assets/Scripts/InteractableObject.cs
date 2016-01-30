using UnityEngine;
using System.Collections;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField]
    protected float useTime;
    [SerializeField]
    protected bool isReuseable;

    protected bool isInUse;

	// Use this for initialization
	void Start ()
    {
        isInUse = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerStay(Collider other)
    {
        if (!isInUse && other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Trigger(other);
        }
    }

    protected abstract void Trigger(Collider player);
}
