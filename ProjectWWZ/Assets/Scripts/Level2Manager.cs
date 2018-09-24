using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour {

    public GameObject ExitArea;
    public Transform StartingPosition;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        Player =  FindObjectOfType<PlayerController>().gameObject;
        Player.GetComponent<Transform>().SetPositionAndRotation(StartingPosition.position, StartingPosition.rotation);

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}