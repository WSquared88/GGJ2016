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

    Transform tpsCamera;
	// Use this for initialization
	void Start ()
    {
        tpsCamera = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Mouse X") * sensitivityX;
        transform.Rotate(Vector3.up, xMovement);
        tpsCamera.RotateAround(transform.position, -transform.right, Input.GetAxis("Mouse Y") * sensitivityY);
        if (Mathf.Abs(xMovement) > fastTurnLimit)
        {
            Debug.Log("Turning too fast");
        }
    }
}
