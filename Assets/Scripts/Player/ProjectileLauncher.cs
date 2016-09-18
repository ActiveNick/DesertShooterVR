using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {

    /// <summary>
    /// Keep Track of the allowed shot interval to throttle users' shots
    /// </summary>
    public int shotsPerSec = 2;

    /// <summary>
    /// Keep Track of the last shot time to throttle users' shots
    /// </summary>
    float LastShotTime = 0;

    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_CurrentLaunchForce = 30.0f; // The force that will be given to the shell when the fire button is released.

    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.

    private void OnEnable()
    {

    }

    // Use this for initialization
    void Start () {
	
	}

    /// <summary>
    /// OnSelect is sent by gesture manager.
    /// </summary>
    void OnSelect()
    {
        if ((Time.realtimeSinceStartup - LastShotTime) > (1 / shotsPerSec))
        {
            LastShotTime = Time.realtimeSinceStartup;
            Fire();
        }
    }

    private void Fire()
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

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
