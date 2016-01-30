using UnityEngine;
using System.Collections;

abstract public class ActivationObject : MonoBehaviour
{
    [SerializeField]
    protected float activationTime;

    protected bool isActive;
    protected bool isInUse;

	// Use this for initialization
	void Start ()
    {
        isActive = false;
        isInUse = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public abstract void activate();

    public bool IsObjectInUse()
    {
        return isInUse;
    }
}
