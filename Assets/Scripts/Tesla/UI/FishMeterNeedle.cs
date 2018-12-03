using System.Collections;
using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI
{
    public class FishMeterNeedle : MonoBehaviour
    {
        Image needleImage;
        public Image meterImage;

        PlayerGameScript playerGameScript;

        public float speed = 10.0f;
        public float maxRotationAngle = 70.0f;
        
        public float currentRotation;
        int rotationDirection = 1;

        bool isVisible;
        Coroutine hidingCoroutine;

        void Start()
        {
            needleImage = GetComponent<Image>();
            //meterImage = GetComponentInParent<Image>();

            playerGameScript = FindObjectOfType<PlayerGameScript>();

            hidingCoroutine = StartCoroutine(Hide());
        }

        void Update()
        {
            if (playerGameScript.isFishing)
            {
                if (!isVisible) {Show();}
                
                if (Mathf.Abs(currentRotation) >= maxRotationAngle)
                {
                    rotationDirection *= -1;
                }
            
                currentRotation += rotationDirection * speed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);
            
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotation);   
            }
            else
            {
                if (isVisible)
                {
                    hidingCoroutine = StartCoroutine(Hide(0.7f));
                }
            }
        }

        void Show()
        {
            if (hidingCoroutine != null)
            {
                StopCoroutine(hidingCoroutine);
            }
            
            transform.Rotate(0.0f, 0.0f, maxRotationAngle);
            currentRotation = maxRotationAngle;
            rotationDirection = 1;

            needleImage.color = Color.white;
            meterImage.color = Color.white;

            isVisible = true;
        }
        IEnumerator Hide(float delay=0.0f)
        {
            yield return new WaitForSeconds(delay);
            needleImage.color = Color.clear;
            meterImage.color = Color.clear;

            isVisible = false;
        }

        public float GetNormalizedValue()
        {
            return currentRotation / maxRotationAngle;
        }
    }
}