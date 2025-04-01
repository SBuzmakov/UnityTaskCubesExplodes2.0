using System;
using UnityEngine;

namespace Source.Scripts
{
    public class MouseRaycast : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public event Action<Cube> CubeClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                TryInvokeCubeClick();
        }

        private void TryInvokeCubeClick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();

                if (cube != null)
                {
                    CubeClicked?.Invoke(cube);
                }
            }
        }
    }
}