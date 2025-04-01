using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class Painter : MonoBehaviour
    {
        public void Repaint(Cube cube)
        {
            if (cube.GetComponent<Renderer>() == null)
                throw new NullReferenceException("Component Renderer is missing");
        
            Renderer cubeRenderer = cube.GetComponent<Renderer>();

            Color randomColor = new Color(Random.value, Random.value, Random.value);
            cubeRenderer.material.color = randomColor;
        }
    }
}
