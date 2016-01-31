using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingObject
{
    NavMeshAgent agent;
    Transform target;
    //GameObject[] bloodList;
    ArrayList bloodList;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        bloodList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update ()
    {
        calculateBloodWeighting();
        if (target)
        {
            //agent.SetDestination(target.position);
        }
	}

    void calculateBloodWeighting()
    {
        GameObject richestBlood = null;
        int highestRichness = 0;

        for (int i = 0; i < bloodList.Count; i++)
        {
            GameObject obj = (GameObject)bloodList[i];
            if (obj)
            {
                BloodCollider blood = obj.GetComponent<BloodCollider>();
                if (blood)
                {
                    int richness = blood.getIndex();

                    if (obj.tag == "SmallBloodPool")
                    {
                        richness++;
                    }
                    else if (obj.tag == "MedBloodPool")
                    {
                        richness += 3;
                    }
                    else
                    {
                        richness += 7;
                    }

                    if (richness > highestRichness)
                    {
                        highestRichness = richness;
                        richestBlood = obj;
                    }
                    else if (richness == highestRichness)
                    {
                        if (richness - bloodList.Count > highestRichness - bloodList.Count)
                        {
                            highestRichness = richness;
                            richestBlood = obj;
                        }
                    }
                }
            }
        }

        if (richestBlood)
        {
            target = richestBlood.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("BloodPool"))
        {
            bloodList.Add(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (bloodList.Contains(other.gameObject))
        {
            bloodList.Remove(other.gameObject);
        }
    }
}
