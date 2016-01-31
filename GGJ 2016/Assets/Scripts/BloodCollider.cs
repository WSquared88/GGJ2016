using UnityEngine;
using System.Collections;

public class BloodCollider : MonoBehaviour
{
    [SerializeField]
    GameObject NextBloodPool;
    [SerializeField]
    Color poolColor;

    int index;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = poolColor;
        //GetComponent<Renderer>().enabled = true;
        index = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getIndex();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if (isActiveAndEnabled && other.tag != "undefined" && other.tag.Contains("BloodPool") && NextBloodPool && !isBloodInUpgrade(other))
        {
            Destroy(other.gameObject);
            Instantiate(NextBloodPool, (transform.position - other.transform.position) * .5f + other.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public bool isBloodInUpgrade(Collider other)
    {
        if (NextBloodPool)
        {
            return other.tag == NextBloodPool.tag || NextBloodPool.GetComponent<BloodCollider>().isBloodInUpgrade(other);
        }
        return false;
    }

    public int getIndex()
    {
        return index;
    }
}
