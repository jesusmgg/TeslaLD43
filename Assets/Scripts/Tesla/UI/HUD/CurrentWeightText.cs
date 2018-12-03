using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI.HUD
{
    public class CurrentWeightText : MonoBehaviour
    {
        PlayerGameScript playerGameScript;

        Text text;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();

            text = GetComponent<Text>();
        }

        void Update()
        {
            text.text = $"Weight: {playerGameScript.currentWeight:F2}kg.";
        }
    }
}