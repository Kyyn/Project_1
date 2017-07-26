using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject cannonball = null;
    public Transform player = null;

    public int health = 100;

    public float minDelay = 1.0f;
    public float maxDelay = 4.0f;

    private float lastTime = 0.0f;
    private float delayTime = 0.0f;

	void Start ()
	{
		
	}

	
	void Update ()
	{
        FollowPlayer();
        Shoot();
	}

    void FollowPlayer()
    {
        this.transform.LookAt(player);
    }

    void Shoot()
    {
        if (Time.time > lastTime + delayTime)
        {
            lastTime = Time.time;

            delayTime = GetRandomValue();

            GameObject obj = Instantiate(cannonball, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "cannonball";
        }
    }

    float GetRandomValue()
    {
        return Random.Range(minDelay, maxDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "magicOrb")
        {
            int hp = other.GetComponent<MagicOrb>().hitpoint;
            GetHealth(hp);
        }
    }

    void GetHealth(int hp)
    {
        if (health > 0)
        {
            health -= hp;

            Debug.Log("Turrent hit for: " + hp + "  Turrent Health: " + health);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
