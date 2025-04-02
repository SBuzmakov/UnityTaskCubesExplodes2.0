using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class Painter : MonoBehaviour
    {
        public void Repaint(Renderer objectRenderer)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            objectRenderer.material.color = randomColor;
        }
    }
}
