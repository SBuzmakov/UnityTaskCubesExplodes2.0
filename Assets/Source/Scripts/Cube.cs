using System;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : MonoBehaviour
    {
        public float SpawnRate { get; private set; } = 1.0f;
        public float ExplosionForce { get; private set; } = 10.0f;
        public float ExplosionRadius { get; private set; } = 3.0f;
        
        public event Action<Cube> Destroyed;

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }

        public void ChangeParameters(float spawnRateFactor, float explosionForceRateFactor,
            float explosionRadiusRateFactor)
        {
            SpawnRate *= spawnRateFactor;
            ExplosionForce *= explosionForceRateFactor;
            ExplosionRadius *= explosionRadiusRateFactor;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}