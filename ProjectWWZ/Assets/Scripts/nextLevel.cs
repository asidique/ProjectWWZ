using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour {

    public GameObject nextSceneCollider;
    public Text leaveGameText;
    public GameObject box;


    // Use this for initialization
    void Start () {
        leaveGameText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            box.SetActive(true);
            leaveGameText.enabled = true;
           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Second_Level");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            box.SetActive(false);
            leaveGameText.enabled = false;
        }
    }
}
