using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI.HUD
{
    public class GameStateText : MonoBehaviour
    {
        MainGameScript mainGameScript;
        PlayerGameScript playerGameScript;

        Text text;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            playerGameScript = FindObjectOfType<PlayerGameScript>();

            text = GetComponent<Text>();
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing)
            {
                text.text = $"Fishing: {mainGameScript.fishingTimeLeft:F1}s";
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                text.text = "Return to the dock!";
            }
        }
    }
}