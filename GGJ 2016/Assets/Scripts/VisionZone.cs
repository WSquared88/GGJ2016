using UnityEngine;
using System.Collections;

public class VisionZone : MonoBehaviour
{
    GameObject[] targets;
    Enemy parent;

    // Use this for initialization
    void Start ()
    {
        parent = transform.parent.gameObject.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        parent.EvaluateTarget(other);
    }

    void OnTriggerExit(Collider other)
    {
        parent.removeTarget(other);
    }
}
