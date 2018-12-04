using System.Collections;
using Tesla.Animation;
using Tesla.Controls;
using Tesla.UI;
using UnityEngine;

namespace Tesla.GameScript
{
    public class PlayerGameScript : BaseGameScript
    {
        MouseControls controls;
        FishMeterNeedle fishMeterNeedle;

        MainGameScript mainGameScript;
        FishSchoolGameScript currentFishSchool;
        FishStack fishStack;

        public float fishingMeterTolerance = 0.2f;
        public float weightDamageFactor = 8.0f;

        public bool isFishing;
        public bool isDocked;

        public float currentWeight;
        public float currentDamage;
        public float waterLevel; // When equal to 1.0f, player sinks

        public string tooltipText; // Set to empty string to hide tooltip

        public FishSchoolGameScript lastFishedSchool;

        bool newDay;

        void Start()
        {
            controls = GetComponent<MouseControls>();
            fishMeterNeedle = FindObjectOfType<FishMeterNeedle>();

            mainGameScript = FindObjectOfType<MainGameScript>();
            fishStack = GetComponentInChildren<FishStack>();

            currentFishSchool = null;

            currentWeight = 0.0f;

            newDay = false;
        }

        void ResetValues()
        {
            currentWeight = 0.0f;
            currentDamage = 0.0f;
            waterLevel = 0.0f;
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing || mainGameScript.gameState == GameState.Returning)
            {
                if (newDay)
                {
                    ResetValues();
                    newDay = false;
                }

                if (currentFishSchool != null)
                {
                    if (!isFishing && lastFishedSchool != currentFishSchool)
                    {
                        StartCoroutine(StartFishing());
                    }
                }

                if (currentDamage > 0.0f)
                {
                    waterLevel += (currentDamage + currentWeight / weightDamageFactor) * Time.deltaTime;
                }

                if (waterLevel >= 1.0f)
                {
                    Sink();
                }

                waterLevel = Mathf.Clamp(waterLevel, 0.0f, 2.7f);

                tooltipText = "";
                if (fishStack.hasMouseOver)
                {
                    tooltipText = "Drop some fish to move faster and delay sinking";
                }
            }

            else if (mainGameScript.gameState == GameState.Selling)
            {
                newDay = true;
            }

            else if (mainGameScript.gameState == GameState.Menu)
            {
                newDay = true;
            }
        }

        void OnCollisionEnter2D(Collision2D other)

        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                EnemyGameScript enemy = other.gameObject.GetComponent<EnemyGameScript>();
                if (enemy.canDamage)
                {
                    currentDamage += enemy.damage;
                }
            }
            else if (other.gameObject.CompareTag("Dock"))
            {
                if (mainGameScript.gameState == GameState.Returning)
                {
                    isDocked = true;
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
            if (other.gameObject.CompareTag("FishSchool"))
            {
                if (currentFishSchool != null)
                {
                    if (other.gameObject == currentFishSchool.gameObject)
                    {
                        currentFishSchool = null;
                    }
                }
            }
            else if (other.gameObject.CompareTag("Dock"))
            {
                isDocked = false;
            }
        }

        void Sink()
        {
            Debug.Log("SINK");
        }

        IEnumerator StartFishing()
        {
            isFishing = true;
            yield return new WaitUntil(() => controls.GetMouseButtonDown(0));
            if (currentFishSchool != null)
            {
                if (Mathf.Abs(fishMeterNeedle.GetNormalizedValue()) <= fishingMeterTolerance)
                {
                    currentWeight += currentFishSchool.weight;
                    Debug.Log($"Successfully fished a {currentFishSchool.weight:F2}kg. fish!");
                }
                else
                {
                    Debug.Log($"Failed to fished a {currentFishSchool.weight:F2}kg. fish");
                }
            }

            isFishing = false;
            lastFishedSchool = currentFishSchool;
            yield return null;
        }
    }
}