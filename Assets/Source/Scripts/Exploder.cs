using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts
{
    public class Exploder : MonoBehaviour
    {
        private const int MaxExplodableCollidersCount = 200;
        [SerializeField] private CubeSpawner _cubeSpawner;

        private void OnEnable()
        {
            _cubeSpawner.CubesSpawnFailed += Explode;
        }

        private void OnDisable()
        {
            _cubeSpawner.CubesSpawnFailed -= Explode;
        }

        private void Explode(Cube parentCube)
        {
            foreach (Rigidbody explodableCube in GetExplodableCubes(parentCube))
            {
                explodableCube.AddExplosionForce(parentCube.ExplosionForce, parentCube.transform.position, parentCube.ExplosionRadius);
            }
        }

        private List<Rigidbody> GetExplodableCubes(Cube parentCube)
        {
            Collider[] results = new Collider[MaxExplodableCollidersCount];
            
            int size = Physics.OverlapSphereNonAlloc(parentCube.transform.position, parentCube.ExplosionRadius, results);
            
            List<Rigidbody> explodableCubes = new List<Rigidbody>();

            for (var i = 0; i < size; i++)
            {
                if (results[i].attachedRigidbody != null)
                {
                    explodableCubes.Add(results[i].attachedRigidbody);
                }
            }

            return explodableCubes;
        }
    }
}