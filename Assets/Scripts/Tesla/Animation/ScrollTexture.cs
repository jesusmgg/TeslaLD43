using UnityEngine;

namespace Tesla.Animation
{
    public class ScrollTexture : MonoBehaviour
    {
        public Vector2 scrollSpeed;
        Renderer rend;

        public Material material;

        void Start()
        {
            if (material == null)
            {
                rend = GetComponent<Renderer>();    
            }
        }

        void Update()
        {
            Vector2 offset = Time.time * scrollSpeed;

            if (material == null)
            {
                rend.material.SetTextureOffset("_MainTex", offset);    
            }
            else
            {
                material.SetTextureOffset("_MainTex", offset);
            }
        }
    }
}