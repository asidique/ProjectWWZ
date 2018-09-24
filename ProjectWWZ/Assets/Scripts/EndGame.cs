using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public float timer = 5.0f;

    public AudioSource aS;
    public GameObject main;
    public AudioSource mainAudio;

    public bool win = false;

	// Use this for initialization
	void Start () {
        mainAudio = main.GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (win)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            aS.clip = Resources.Load<AudioClip>("final");
            mainAudio.Stop();
            aS.Play();
            win = true;
        }
    }
}
