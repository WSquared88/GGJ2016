using UnityEngine;
using System.Collections;

public class MonsterKillingZone : MonoBehaviour
{
    [SerializeField]
    float damageCooldown;

    LivingObject parent;
    float timeSinceLastDamage;

	// Use this for initialization
	void Start ()
    {
        parent = transform.parent.gameObject.GetComponent<LivingObject>();
        timeSinceLastDamage = damageCooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastDamage += Time.deltaTime;
	}

    void OnTriggerStay(Collider other)
    {
        if (timeSinceLastDamage >= damageCooldown && (other.tag == "Player" || other.tag == "Monster"))
        {
            LivingObject obj = other.gameObject.GetComponent<LivingObject>();
            if (obj && parent)
            {
                obj.TakeDamage(parent.getDamage());
            }
            timeSinceLastDamage = 0;
        }
    }
}
