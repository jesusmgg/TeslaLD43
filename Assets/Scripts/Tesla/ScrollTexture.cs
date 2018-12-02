using UnityEngine;

namespace Tesla
{
    public class ScrollTexture : MonoBehaviour
    {
        public Vector2 scrollSpeed;
        Renderer rend;

        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        void Update()
        {
            Vector2 offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", offset);
        }
    }
}