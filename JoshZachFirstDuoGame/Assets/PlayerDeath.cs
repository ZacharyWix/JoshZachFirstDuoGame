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

    private void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        bc = gameObject.GetComponent<BoxCollider>();
        deathParticles = gameObject.GetComponentInChildren<ParticleSystem>();
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
            }

            deathTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            mr.enabled = false;
            bc.enabled = false;
            isDead = true;
            deathParticles.Play();
            deathTimer = respawnTimer;
        }
    }

}
