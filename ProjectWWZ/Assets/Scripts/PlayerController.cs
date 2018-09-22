using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed = 75.0f;
	Animator anim;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate ()
    {
        float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate(0,0,translation);
		transform.Rotate(0,rotation,0);

		if(translation != 0){
			anim.SetBool("isRunning", true);
		}
		else{
			anim.SetBool("isRunning", false);
		}
		
    }

}
