using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed = 75.0f;
	Animator anim;
	private Rigidbody rb;
	bool firstshot = true;
	private float nextFire = .3F;
	private float lastFireTime = 1.5F;
	public GameObject bulletPrefab;
    public Transform bulletSpawn;

	public float initialFire = 1.0f;

    public int health = 5;

    public float regenTime = 2.5f;

    public float deathTimer = 2.5f;

    public bool dead = false;
    public bool regen = false;

    public AudioSource walking;

    public Image hitPanel;
	// Use this for initialization
	void Start () {
        walking.loop = true;
        hitPanel.CrossFadeAlpha(0.0f, 0.1f, true);
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate ()
    {
        float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

        if(dead) {
            deathTimer -= Time.deltaTime;
            if(deathTimer < 0) {
                SceneManager.LoadScene("Death");
            }
        } 

        if(regen) {
            regenTime -= Time.deltaTime;
            if(regenTime < 0) {
                regenTime = 2.5f;
                regen = false;
            }
        }

        if(Input.GetMouseButton(0) && translation != 0) {
            if (Time.time > (lastFireTime + nextFire))
            {
                walking.clip = Resources.Load<AudioClip>("gun");
                walking.loop = false;
                walking.Play();
                
                lastFireTime = Time.time;
                Fire();
            }
        }
		if (Input.GetMouseButton(0) && translation == 0){
			anim.SetBool("isShooting", true);
			if(initialFire < 0.0f) {
		
				if(Time.time > ( lastFireTime + nextFire)){
					lastFireTime=Time.time;
					Fire();
				}
			}
			initialFire -= 0.1f;
		}
		else{
		initialFire = 1.5f;
			anim.SetBool("isShooting", false);
			//translation *= Time.deltaTime;
			//rotation *= Time.deltaTime;
			if(translation != 0){
				anim.SetBool("isRunning", true);
                if (!walking.isPlaying)
                {
                    walking.clip = Resources.Load<AudioClip>("footsteps");

                    walking.Play();
                }
			}
			else{
                walking.Stop();
				anim.SetBool("isRunning", false);
			}
		}

		transform.Translate(0,0,translation);
		transform.Rotate(0,rotation,0);
    }

	void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate (
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        walking.clip = Resources.Load<AudioClip>("gun");
        walking.loop = false;
        walking.Play();

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public void hitPlayer() {
        if (!regen)
        {
            walking.loop = false;
            walking.clip = Resources.Load<AudioClip>("panting");
            walking.Play();
            if (health == 1)
            {
                anim.SetBool("Dead", true);
                dead = true;

            }

            health--;
            //activate red sprite
            hitPanel.CrossFadeAlpha(0.7f * health / 5, 0.15f, false);
            regen = true;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            hitPlayer();
        }
    }


}
