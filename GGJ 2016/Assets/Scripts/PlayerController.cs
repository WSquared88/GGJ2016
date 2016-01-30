using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float sensitivityX;
    [SerializeField]
    float sensitivityY;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    float fastTurnLimit;
    [SerializeField]
    float playerSpeed;
    [SerializeField]
    Vector3 cameraPos;
    [SerializeField]
    float cameraCloseLimit;
    [SerializeField]
    float cameraFarLimit;

    Transform tpsCamera;

	// Use this for initialization
	void Start ()
    {
        tpsCamera = transform.GetChild(0);
        tpsCamera.position = cameraPos;
        tpsCamera.LookAt(transform);
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

        transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
    }
}
