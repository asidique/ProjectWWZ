using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter(Collider other)
    {
			if(other.gameObject.CompareTag ("Player")){
                SceneManager.LoadScene("Elevator_Scene");
		    }
		
    }
}
