using UnityEngine;
using System.Collections;
using System;

public class Door : ActivationObject
{
    [SerializeField]
    Vector3 openPos;

    Vector3 closedPos;

	// Use this for initialization
	void Start ()
    {
        closedPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public override void activate()
    {
        if (!isInUse)
        {
            isInUse = true;
            if (isActive)
            {
                Lerping.DoCoroutine(Lerping.LerpTo(transform, transform.position, closedPos, activationTime, stopUsing));
            }
            else
            {
                Lerping.DoCoroutine(Lerping.LerpTo(transform, transform.position, transform.position + openPos, activationTime, stopUsing));
            }
        }
    }

    void stopUsing()
    {
        isInUse = false;
        isActive = !isActive;
    }
}
