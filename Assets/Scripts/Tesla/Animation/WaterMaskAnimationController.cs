using UnityEngine;

namespace Tesla.Animation
{
    public class WaterMaskAnimationController : MonoBehaviour
    {
        public float animationSpeed = 10.0f;

        RectTransform rectTransform;
        float currentPosition = 2.0f;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector2(currentPosition, rectTransform.localPosition.y);
        }

        void Update()
        {
            currentPosition -= animationSpeed * Time.deltaTime;
            currentPosition = Mathf.Clamp(currentPosition, -2.0f, 2.0f);

            if (currentPosition <= -2.0f)
            {
                currentPosition = 2.0f;
            }

            rectTransform.localPosition = new Vector2(currentPosition, rectTransform.localPosition.y);
        }
    }
}