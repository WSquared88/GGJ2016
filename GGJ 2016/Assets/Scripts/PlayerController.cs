using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : LivingObject
{
    #region player
    [SerializeField]
    float sensitivityX;
    [SerializeField]
    float sensitivityY;
    [SerializeField]
    float fastTurnLimit;
    #endregion

    #region camera
    [Header("Camera"), SerializeField]
    Vector3 startingCameraOffset;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    float cameraCloseLimit;
    [SerializeField]
    float cameraFarLimit;
    [SerializeField]
    float cameraLowerAngleLimit;
    [SerializeField]
    float cameraUpperAngleLimit;
    #endregion

    #region blood
    [Header("Blood"), SerializeField]
    float dripTime;
    [SerializeField]
    Object blood;
    #endregion

    Transform tpsCamera;
    bool canMove;
    AudioSource bloodDrip;
    int currentIndex;
    public CanvasGroup myCanvas;
    private bool fade;

    // Use this for initialization
    void Start ()
    {
        canMove = true;
        tpsCamera = transform.GetChild(0);
        tpsCamera.localPosition = startingCameraOffset;
        tpsCamera.LookAt(transform);
        bloodDrip = GetComponent<AudioSource>();
        StartCoroutine("dripBlood");
        myCanvas.alpha = 0f;
        fade = false;
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

        float angle = Vector3.Angle(-transform.forward, tpsCamera.position-transform.position);
        if (tpsCamera.position.y < transform.position.y)
        {
            if (angle > cameraLowerAngleLimit)
            {
                tpsCamera.RotateAround(transform.position, transform.right, angle - cameraLowerAngleLimit);
            }
        }
        else
        {
            if (angle > cameraUpperAngleLimit)
            {
                tpsCamera.RotateAround(transform.position, -transform.right, angle - cameraUpperAngleLimit);
            }
        }

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
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }

        if (fade)
        {
            myCanvas.alpha = myCanvas.alpha + Time.deltaTime;
            if (myCanvas.alpha >= 1)
            {
                myCanvas.alpha = 1;
                fade = false;
            }
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
                    bloodDrip.Play();
                    Quaternion bloodAngle = new Quaternion();
                    bloodAngle = Quaternion.AngleAxis(Random.rotation.x*360, Vector3.up);
                    Instantiate(blood, hit.point, bloodAngle);
                    currentIndex++;
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

    public int getIndex()
    {
        return currentIndex;
    }

    protected override void die()
    {
        isAlive = false;
        fade = true;

    }
}
