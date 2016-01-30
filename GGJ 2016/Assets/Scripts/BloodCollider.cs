using UnityEngine;
using System.Collections;

public class BloodCollider : MonoBehaviour
{
    [SerializeField]
    GameObject NextBloodPool;
    [SerializeField]
    Color poolColor;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = poolColor;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (isActiveAndEnabled && other.tag != "undefined" && other.tag.Contains("BloodPool"))
        {
            if (NextBloodPool && isEvolving(other))
            {
                Destroy(other.gameObject);
                Instantiate(NextBloodPool, transform.position, new Quaternion());
                Destroy(gameObject);
            }
        }
    }

    public bool isEvolving(Collider other)
    {
        if (NextBloodPool)
        {
            return other.tag != NextBloodPool.tag && NextBloodPool.GetComponent<BloodCollider>().isEvolving(other);
        }
        return true;
    }
}
