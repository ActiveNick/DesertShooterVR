using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class RaycastShooter : MonoBehaviour, IInputClickHandler
{


    // Keep Track of the allowed shot interval to throttle users' shots
    public float FireRate = 0.5f;
    // This will be used to delay the bullet hit sound & particle effects
    public float BulletSpeed = 300.0f;
    // Max weapon range
    public float WeaponRange = 200.0f;

    // Keep Track of when the user can shoot next to throttle shots
    private float nextFire;

    public Transform FireTransform;           // Should be set to the main camera transform which is where the raycast is calculated from.
    public AudioSource ShootingAudio;         // Reference to the audio source used to play the shooting audio. 
    public AudioClip FireClip;                // Audio that plays when each shot is fired.

    public ParticleSystem HitParticles;         // Reference to the particles that will play on bullet impact explosion.
    public ParticleSystem DestroyedParticles;         // Reference to the particles that will play when an enemy id destroyed
    public AudioSource ExplosionAudio;                // Reference to the audio that will play on explosion.
    public AudioClip ShellHitClip;
    public AudioClip EnemyDestroyedClip;


    // Use this for initialization
    void Start () {
        // This is the equivalent of a "catch-all" for user air taps when no other objects trigger a click
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + FireRate;

            ShootingAudio.clip = FireClip;
            ShootingAudio.Play();

            // Create a vector at the center of our camera's viewport
            //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            Vector3 rayOrigin = FireTransform.position;

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, FireTransform.forward, out hit, WeaponRange))
            {
                ParticleSystem impact = Instantiate(HitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                impact.transform.parent = hit.transform;
                // Play the bullet particle system no matter what we hit
                impact.Play();

                // Once the particles have finished, destroy the gameobject they are on.
                Destroy(impact.gameObject, impact.main.duration);
            }

        }

    }
}
