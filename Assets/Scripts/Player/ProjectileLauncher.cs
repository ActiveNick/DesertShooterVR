using UnityEngine;
using System.Collections;
using HoloToolkit.Unity.InputModule;
using System;

public class ProjectileLauncher : MonoBehaviour, IInputClickHandler {

    /// <summary>
    /// Keep Track of the allowed shot interval to throttle users' shots
    /// </summary>
    public int shotsPerSec = 2;

    /// <summary>
    /// Keep Track of the last shot time to throttle users' shots
    /// </summary>
    float LastShotTime = 0;

    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // Should be set to the main camera transform which is where the shells are spawned.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. 
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_CurrentLaunchForce = 100.0f; // The force that will be given to the shell when the fire button is released.

    private void OnEnable()
    {

    }

    // Use this for initialization
    void Start () {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    /// <summary>
    /// OnInputClicked is triggered by the Input Manager on Air Tap, 
    /// signals that the user wants to shoot a bullet.
    /// </summary>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if ((Time.realtimeSinceStartup - LastShotTime) > (1 / shotsPerSec))
        {
            LastShotTime = Time.realtimeSinceStartup;
            Fire();
        }
    }

    /// <summary>
    /// Instantiates a bullet using the Shell prefab and shoots it using Unity physics.
    /// </summary>
    private void Fire()
    {
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
