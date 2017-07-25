using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    public int hitpoint = 10;
    public float speed = 5.0f;
    public AudioClip audioHit = null;
    public AudioClip audioShoot = null;
    public ParticleSystem particle = null;


    void Awake()
    {
        this.GetComponent<AudioSource>().PlayOneShot(audioShoot);
    }

    void Start ()
	{
		
	}

	void Update ()
	{
        MoveObject();
	}

    void MoveObject()
    {
        this.transform.Translate( 0, 0, speed*Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().PlayOneShot(audioHit);
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject, audioHit.length);
    }



}
