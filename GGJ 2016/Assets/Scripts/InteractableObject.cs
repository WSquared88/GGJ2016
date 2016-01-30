using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    float moveTime;
    [SerializeField]
    Vector3 destination;
    [SerializeField]
    float speed;
    [SerializeField]
    bool isReuseable;

    float startTime;
    bool lerping;
    Vector3 startPos;
    float distance;

	// Use this for initialization
	void Start ()
    {
        lerping = false;
        startPos = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lerping)
        {
            float timeLeft = Time.time - startTime;
            transform.position = Vector3.Lerp(startPos, startPos+destination, timeLeft);
            if (isReuseable && timeLeft >= moveTime)
            {
                lerping = false;
            }
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (!lerping && other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            MoveObject(other);
        }
    }

    void MoveObject(Collider player)
    {
        player.GetComponent<PlayerController>().StartCoroutine("stopMoving", moveTime);
        startTime = Time.time;
        lerping = true;
        startPos = transform.position;
        distance = Vector3.Distance(startPos, destination);
    }
}
