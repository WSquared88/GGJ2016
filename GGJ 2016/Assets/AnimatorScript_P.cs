using UnityEngine;
using System.Collections;

public class AnimatorScript_P : MonoBehaviour {

    bool running;
    Animator myAnimator;
    PlayerController pc;
	// Use this for initialization
	void Start () {
        myAnimator = transform.GetComponent<Animator>();
        pc = GameObject.Find("Player (1)").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (running)
        {
            myAnimator.Play("Run");
            myAnimator.SetBool("Moving", true);
        }
        else
        {
            myAnimator.SetBool("Moving", false);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            running = true;
        }
        else
        {
            running = false;
            myAnimator.Play("Idle");
        }

    }

    void stopAnim(float time)
    {
        Debug.Log("test");
        Debug.Log(pc);
        pc.StartCoroutine("stopMoving", time);
    }
}
