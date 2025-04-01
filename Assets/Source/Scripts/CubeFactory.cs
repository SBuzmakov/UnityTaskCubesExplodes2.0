using UnityEngine;

namespace Source.Scripts
{
    public class CubeFactory : MonoBehaviour
    {
        private const float SpawnRateFactor = 0.5f;
        private const float ExplosionForceRateFactor = 1.3f;
        private const float ExplosionRadiusRateFactor = 1.1f;
        
        [SerializeField, Range(0, 1)] private float _scaleRate = 0.5f;
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Painter _painter;

        public Cube Create(Cube parentCube)
        {
            Cube cube = Instantiate(_cubePrefab, parentCube.transform.position, parentCube.transform.rotation);

            ChangeScale(cube, parentCube.transform);

            _painter.Repaint(cube);

            cube.ChangeParameters(parentCube.SpawnRate * SpawnRateFactor,
                parentCube.ExplosionForce * ExplosionForceRateFactor,
                parentCube.ExplosionRadius * ExplosionRadiusRateFactor);

            return cube;
        }

        private void ChangeScale(Cube cube, Transform parentTransform)
        {
            cube.transform.localScale = parentTransform.localScale * _scaleRate;
        }
    }
}