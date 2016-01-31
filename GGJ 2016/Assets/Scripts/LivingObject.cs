using UnityEngine;
using System.Collections;

public class LivingObject : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float immunityTime;

    protected bool isAlive = true;
    bool canTakeDamage = true;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public virtual void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            if (health <= 0)
            {
                die();
            }
            canTakeDamage = false;
            StartCoroutine(becomeImmune(immunityTime));
        }
    }

    IEnumerator becomeImmune(float time)
    {
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }

    protected virtual void die()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
