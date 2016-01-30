using UnityEngine;
using System.Collections;
using System;

public class BookCase : InteractableObject
{
    [SerializeField]
    protected Vector3 destination;

    float startTime;
    Vector3 startPos;
    float distance;

    // Use this for initialization
    void Start ()
    {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isInUse)
        {
            float timeLeft = Time.time - startTime;
            transform.position = Vector3.Lerp(startPos, startPos + destination, timeLeft);
            if (isReuseable && timeLeft >= useTime)
            {
                isInUse = false;
            }
        }
    }

    protected override void Trigger(Collider player)
    {
        player.GetComponent<PlayerController>().StartCoroutine("stopMoving", useTime);
        startTime = Time.time;
        isInUse = true;
        startPos = transform.position;
        distance = Vector3.Distance(startPos, destination);
    }
}
