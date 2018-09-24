using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel2 : MonoBehaviour {

    public GameObject box;
    public Text leaveText;

	// Use this for initialization
	void Start () {
        box.SetActive(false);
        leaveText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player") {
            box.SetActive(true);
            leaveText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Third_Level");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            box.SetActive(false);
            leaveText.enabled = false;

        }
    }
}
