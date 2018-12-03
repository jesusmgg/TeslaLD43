using UnityEngine;

namespace Tesla.Animation
{
    public class SpriteOutline : MonoBehaviour
    {
        new SpriteRenderer renderer;
        
        public Material outlineMaterial;
        Material originalMaterial;

        public bool isHighlighted;
        
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();

            originalMaterial = renderer.material;
        }
        
        void Update()
        {
            renderer.material = isHighlighted ? outlineMaterial : originalMaterial;
        }
    }
}