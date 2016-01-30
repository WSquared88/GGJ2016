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

    protected override void Trigger(Collider player)
    {
        player.GetComponent<PlayerController>().StartCoroutine("stopMoving", useTime);
        isInUse = true;
        Lerping.DoCoroutine(Lerping.LerpTo(transform, transform.position, startPos+destination, useTime, stopUsing));
    }

    void stopUsing()
    {
        if (isReuseable)
        {
            isInUse = false;
        }
    }
}
