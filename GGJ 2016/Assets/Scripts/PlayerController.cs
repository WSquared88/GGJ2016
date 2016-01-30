using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float sensitivityX;
    [SerializeField]
    float sensitivityY;
    [SerializeField]
    float fastTurnLimit;
    [SerializeField]
    float playerSpeed;

    [Header("Camera"), SerializeField]
    Vector3 startingCameraPos;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    float cameraCloseLimit;
    [SerializeField]
    float cameraFarLimit;

    [Header("Blood"), SerializeField]
    float dripTime;
    [SerializeField]
    Object blood;

    Transform tpsCamera;
    bool isAlive;
    bool canMove;

	// Use this for initialization
	void Start ()
    {
        isAlive = true;
        canMove = true;
        tpsCamera = transform.GetChild(0);
        tpsCamera.position = startingCameraPos;
        tpsCamera.LookAt(transform);
        StartCoroutine("dripBlood");
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float yMovement = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        transform.Rotate(Vector3.up, xMovement);
        tpsCamera.RotateAround(transform.position, -transform.right, yMovement);
        tpsCamera.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, tpsCamera.position) < cameraCloseLimit)
        {
            tpsCamera.Translate(0, 0, Vector3.Distance(transform.position, tpsCamera.position) - cameraCloseLimit);
        }
        if (Vector3.Distance(transform.position, tpsCamera.position) > cameraFarLimit)
        {
            tpsCamera.Translate(0, 0, Vector3.Distance(transform.position, tpsCamera.position) - cameraFarLimit);
        }

        if (Mathf.Abs(xMovement) > fastTurnLimit * Time.deltaTime)
        {
            Debug.Log("Turning too fast");
        }

        if (canMove)
        {
            transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        }
    }

    IEnumerator dripBlood()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(dripTime);
            Debug.Log("started bleeding");
            if (blood)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    Instantiate(blood, hit.point, new Quaternion());
                }
            }
            else
            {
                Debug.Log("The blood is missing");
            }
        }
    }

    public IEnumerator stopMoving(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        startMoving();
    }

    void startMoving()
    {
        canMove = true;
    }
}
