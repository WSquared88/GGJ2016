using UnityEngine;
using System.Collections;


[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingObject
{
    [System.Serializable]
    public struct PriorityTarget
    {
        public GameObject target;
        public int weight;
    }

    [SerializeField]
    PriorityTarget[] wantedList;

    public ArrayList nearbyTargets;

    NavMeshAgent agent;
    Transform bloodTarget;
    Transform enemyTarget;
    int enemyWeight = 0;
    ArrayList bloodList;
    bool sensesPlayer;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        bloodList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!sensesPlayer)
        {
            calculateBloodWeighting();
            if (bloodTarget)
            {
                agent.SetDestination(bloodTarget.position);
            }
        }
        else
        {
            agent.SetDestination(enemyTarget.position);
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
            bloodTarget = richestBlood.transform;
        }
    }

    public void EvaluateTarget(Collider other)
    {
        int highestWeight = 0;
        GameObject mostEvilObj = null;

        for (int i = 0; i < wantedList.Length; i++)
        {
            if (wantedList[i].target && wantedList[i].target.tag == other.tag)
            {
                nearbyTargets.Add(other.gameObject);
                if (wantedList[i].weight > enemyWeight)
                {
                    highestWeight = wantedList[i].weight;
                    mostEvilObj = wantedList[i].target;
                }
            }
        }

        if (mostEvilObj)
        {
            sensesPlayer = true;
            enemyTarget = mostEvilObj.transform;
            enemyWeight = highestWeight;
        }
    }

    public void removeTarget(Collider other)
    {
        nearbyTargets.Remove(other.gameObject);
    }

    void EvaluateAllTargets()
    {
        int highestWeight = 0;
        GameObject mostEvilObj = null;

        for (int i = 0; i < nearbyTargets.Count; i++)
        {
            for (int j = 0; j < wantedList.Length; j++)
            {
                GameObject obj = (GameObject)nearbyTargets[i];
                if (wantedList[j].target && obj && wantedList[j].target.tag == obj.tag)
                {
                    if (wantedList[j].weight > highestWeight)
                    {
                        highestWeight = wantedList[j].weight;
                        mostEvilObj = wantedList[j].target;
                    }
                }
            }
        }

        if (mostEvilObj)
        {
            sensesPlayer = true;
            enemyTarget = mostEvilObj.transform;
            enemyWeight = highestWeight;
        }
    }

    public void playerDied()
    {
        sensesPlayer = false;
        enemyTarget = null;
        enemyWeight = 0;
        EvaluateAllTargets();
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
