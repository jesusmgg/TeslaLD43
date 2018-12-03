using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI
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
        }
    }
}