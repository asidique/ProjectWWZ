using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcDialouge : MonoBehaviour {

	public GameObject box;
	public Text npcText;


	// Use this for initialization
    void Start()
    {
        box.SetActive(false);
        npcText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player")){
			box.SetActive(true);
            npcText.enabled = true;

        }
    }
	
	void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
			box.SetActive(false);
            npcText.enabled = false;
		}
    }

}
