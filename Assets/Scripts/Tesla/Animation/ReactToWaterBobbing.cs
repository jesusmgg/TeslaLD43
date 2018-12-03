using UnityEngine;

namespace Tesla.Animation
{
    public class ReactToWaterBobbing : MonoBehaviour
    {
        GameObject waterMask;

        [Header("Rotation")]
        public float maxRotation;
        public float rotationSpeed;

        [Header("Translation")]
        public float maxTranslation;
        public float translationSpeed;
        
        float currentRotation = 0.0f;
        float currentTranslation = 0.0f;

        int rotationDirection = 1;
        int translationDirection = 1;

        void Start()
        {
            waterMask = GetComponentInChildren<WaterMaskAnimationController>().gameObject;
        }

        void LateUpdate()
        {
            if (maxRotation > 0.0f)
            {
                float originalRotation = transform.eulerAngles.z - currentRotation;
                float originalWaterMaskRotation = 0.0f;

                if (waterMask != null)
                {
                    originalWaterMaskRotation = waterMask.transform.localEulerAngles.z + currentRotation;
                }
                
                if (Mathf.Abs(currentRotation) >= maxRotation)
                {
                    rotationDirection *= -1;
                }
            
                currentRotation += rotationDirection * rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
            
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
                    originalRotation + currentRotation);
                
                if (waterMask != null)
                {
                    waterMask.transform.localEulerAngles = new Vector3(waterMask.transform.localEulerAngles.x,
                        waterMask.transform.localEulerAngles.y,
                        originalWaterMaskRotation - currentRotation);
                }
            }

            if (maxTranslation > 0.0f)
            {
                float originalTranslation = transform.position.y - currentTranslation;
                float originalWaterMaskTranslation = 0.0f;

                if (waterMask != null)
                {
                    originalWaterMaskTranslation = waterMask.transform.localPosition.y + currentTranslation;
                }
                
                if (Mathf.Abs(currentTranslation) >= maxTranslation)
                {
                    translationDirection *= -1;
                }
                
                currentTranslation += translationDirection * translationSpeed * Time.deltaTime;
                currentTranslation = Mathf.Clamp(currentTranslation, -maxTranslation, maxTranslation);

                transform.position = new Vector3(transform.position.x, originalTranslation + currentTranslation,
                    transform.position.z);
                
                if (waterMask != null)
                {
                    waterMask.transform.localPosition = new Vector3(waterMask.transform.localPosition.x,
                        originalWaterMaskTranslation - currentTranslation,
                        waterMask.transform.localPosition.z);
                }
            }
        }
    }
}