using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public Transform respawnPoint;

    private bool isDead;

    public float respawnTimer;
    private float deathTimer;

    private MeshRenderer mr;
    private BoxCollider bc;

    private ParticleSystem deathParticles;

    private Health health;

    private void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        bc = gameObject.GetComponent<BoxCollider>();
        deathParticles = gameObject.GetComponentInChildren<ParticleSystem>();
        health = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathTimer < 0)
            {
                gameObject.transform.position = respawnPoint.position;
                mr.enabled = true;
                bc.enabled = true;
                isDead = false;
                health.resetHealth();
            }

            deathTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           if (health.updateHealth(-1) <= 0)
            {
                killPlayer();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Instakill")
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        mr.enabled = false;
        bc.enabled = false;
        isDead = true;
        deathParticles.Play();
        deathTimer = respawnTimer;
    }

}
