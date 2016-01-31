using UnityEngine;
using System.Collections;

public class MonsterKillingZone : MonoBehaviour
{
    [SerializeField]
    float damageCooldown;

    Enemy parent;
    float timeSinceLastDamage;

	// Use this for initialization
	void Start ()
    {
        parent = transform.parent.gameObject.GetComponent<Enemy>();
        timeSinceLastDamage = damageCooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastDamage += Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (timeSinceLastDamage >= damageCooldown && (other.tag == "Player" || other.tag == "Monster"))
        {
            LivingObject obj = other.gameObject.GetComponent<LivingObject>();
            if (obj && parent)
            {
                obj.TakeDamage(parent.GetDamage());
                if (!obj.IsAlive())
                {
                    parent.playerDied();
                }
            }
            timeSinceLastDamage = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
