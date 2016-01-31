using UnityEngine;
using System.Collections;
using System;

public class BookCase : InteractableObject
{
    [SerializeField]
    Vector3 openPos;

    Vector3 startPos;
    float startTime;
    bool isOpen;

    // Use this for initialization
    void Start ()
    {
        startPos = transform.position;
    }

    protected override void Trigger(Collider player)
    {
        if (!isInUse)
        {
            isInUse = true;
            player.GetComponent<PlayerController>().StartCoroutine("stopMoving", useTime);
            if (isOpen)
            {
                Lerping.DoCoroutine(Lerping.LerpTo(transform, transform.position, startPos, useTime, stopUsing));
            }
            else
            {
                Lerping.DoCoroutine(Lerping.LerpTo(transform, transform.position, transform.position + openPos, useTime, stopUsing));
            }
        }
    }

    void stopUsing()
    {
        if (isReuseable)
        {
            isInUse = false;
            isOpen = !isOpen;
        }
    }
}
