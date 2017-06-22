using HoloToolkit.Unity;
using UnityEngine;

namespace Complete
{
    public class ShellExplosion : MonoBehaviour
    {
        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on bullet impact explosion.
        public ParticleSystem m_DestroyedParticles;         // Reference to the particles that will play when an enemy id destroyed
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        public AudioClip m_ShellHitClip;
        public AudioClip m_EnemyDestroyedClip;
        //public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
        //public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        //public float m_ExplosionRadius = 0.5f;                // The maximum distance away from the explosion tanks can be and are still affected.


        private void Start ()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy (gameObject, m_MaxLifeTime);
        }

        //private float CalculateDamage (Vector3 targetPosition)
        //{
        //    // Create a vector from the shell to the target.
        //    Vector3 explosionToTarget = targetPosition - transform.position;

        //    // Calculate the distance from the shell to the target.
        //    float explosionDistance = explosionToTarget.magnitude;

        //    // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        //    float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        //    // Calculate damage as this proportion of the maximum possible damage.
        //    float damage = relativeDistance * m_MaxDamage;

        //    // Make sure that the minimum damage is always 0.
        //    damage = Mathf.Max (0f, damage);

        //    return damage;
        //}

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