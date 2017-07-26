using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 100.0f;
    public int magicOrbAmount = 20;
    public GameObject magicOrb = null;
    public Transform socket = null;
    public int health = 100;

	void Start ()
	{
		
	}

	void Update ()
	{
        Move();
        Shoot();
	}

    private void Move()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(0, 0, move * Time.deltaTime);
        this.transform.Rotate(0, rotation * Time.deltaTime, 0);
    }

    void Shoot()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            if (magicOrbAmount > 0)
            {
                magicOrbAmount--;
                GameObject obj = Instantiate(magicOrb, socket.position, socket.rotation) as GameObject;
                obj.name = "magicOrb";
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "cannonball")
        {
            int hp = other.GetComponent<Cannonball>().hitpoint;
            GetHealth(hp);
        }
    }

    void GetHealth(int hp)
    {
        if (health > 0)
        {
            health -= hp;

            Debug.Log("Hero hit for: " + hp + "  Hero Health: " + health);
            
        }
        else
        {
            Debug.Log("Game Over.");
        }
    }
}
