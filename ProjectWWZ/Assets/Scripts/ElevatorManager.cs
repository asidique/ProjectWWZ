using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevatorManager : MonoBehaviour {

    public float UI = 5.0f;
    public float death = 10.0f;

    public GameObject box;
    public Light light;
    //public Text deathText;

    public float force = 5.0f;

    public GameObject player;

    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
        box.SetActive(false);
     //   deathText.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        UI -= Time.deltaTime;
        death -= Time.deltaTime;
        if(UI < 0) {
            ShowUI();
            light.range = 40;
            cam.transform.Rotate(20.0f, 0.5f, 20.0f);
        }
        if(death < 0) {
            Death();
            SceneManager.LoadScene("Death");
        }
	}

    void ShowUI() {
        box.SetActive(true);
    //   deathText.enabled = true;
    }

    void Death() {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        player.GetComponent<Animator>().Play("Death");

    }
}