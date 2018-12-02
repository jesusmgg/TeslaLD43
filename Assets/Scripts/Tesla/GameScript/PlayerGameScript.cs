using System.Collections;
using Tesla.Controls;
using Tesla.UI;
using UnityEngine;

namespace Tesla.GameScript
{
    public class PlayerGameScript : BaseGameScript
    {
        MouseControls controls;
        FishMeterNeedle fishMeterNeedle;
        
        FishSchoolGameScript currentFishSchool;
        
        public bool isFishing;
        public FishSchoolGameScript lastFishedSchool;

        void Start()
        {
            controls = GetComponent<MouseControls>();
            fishMeterNeedle = FindObjectOfType<FishMeterNeedle>();
            
            currentFishSchool = null;
        }

        void Update()
        {
            if (currentFishSchool != null)
            {
                if (!isFishing)
                {
                    StartCoroutine(StartFishing());
                }
            }
        }

        void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("FishSchool"))
            {
                currentFishSchool = other.gameObject.GetComponent<FishSchoolGameScript>();
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject == currentFishSchool.gameObject)
            {
                currentFishSchool = null;
            }
        }

        IEnumerator StartFishing()
        {
            isFishing = true;
            
            yield return new WaitUntil(() => controls.GetMouseButtonDown(0));
            Debug.Log(fishMeterNeedle.GetNormalizedValue());
            
            isFishing = false;
            lastFishedSchool = currentFishSchool;

            yield return null;
        }
    }
}