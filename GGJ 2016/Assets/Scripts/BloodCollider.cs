using UnityEngine;
using System.Collections;

public class BloodCollider : MonoBehaviour
{
    [SerializeField]
    Object NextBloodPool;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SmallBloodPool")
        {
            if (NextBloodPool)
            {
                Instantiate(NextBloodPool);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
