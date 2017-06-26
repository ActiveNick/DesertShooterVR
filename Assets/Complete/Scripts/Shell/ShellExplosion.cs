using HoloToolkit.Unity;
using UnityEngine;

namespace Complete
{
    public class ShellExplosion : MonoBehaviour
    {

        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on bullet impact explosion.
        public ParticleSystem m_DestroyedParticles;         // Reference to the particles that will play when an enemy id destroyed
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        public AudioClip m_ShellHitClip;
        public AudioClip m_EnemyDestroyedClip;

        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.

        private void Start ()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy (gameObject, m_MaxLifeTime);
        }

        private void OnCollisionEnter(Collision otherObj)
        {
            // Unparent the particles from the shell.
            m_ExplosionParticles.transform.parent = null;

            if (otherObj.contacts.Length > 0)
            {
                m_ExplosionParticles.transform.position = otherObj.contacts[0].point;
            }

            // Play the bullet particle system no matter what we hit
            m_ExplosionParticles.Play();

            // Once the particles have finished, destroy the gameobject they are on.
            Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

            // Destroy the shell.
            Destroy(gameObject);

            // If we hit an enemy
            if (otherObj.gameObject.transform.root.gameObject.tag == "Enemy")
            {
                // Play the enemy explosion sound effect.
                m_ExplosionAudio.clip = m_EnemyDestroyedClip;
                m_ExplosionAudio.Play();

                m_DestroyedParticles.Play();
                Destroy(otherObj.gameObject.transform.root.gameObject);
                // Once the particles have finished, destroy the gameobject they are on.
                //Destroy(m_DestroyedParticles.gameObject, m_ExplosionParticles.duration);
            }
            else
            {
                // Play the bullet explosion sound effect.
                m_ExplosionAudio.clip = m_ShellHitClip;
                m_ExplosionAudio.Play();

            }
        }
    }
}