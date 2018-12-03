using Tesla.GameScript;
using UnityEngine;

namespace Tesla.UI
{
    public class UiManager : MonoBehaviour
    {
        MainGameScript mainGameScript;

        public GameObject hudPanel;
        public GameObject sellingPanel;
        public GameObject mainMenuPanel;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing)
            {
                hudPanel.SetActive(true);
                sellingPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                hudPanel.SetActive(true);
                sellingPanel.SetActive(false);
                mainMenuPanel.SetActive(false);
            }
            else if (mainGameScript.gameState == GameState.Selling)
            {
                hudPanel.SetActive(false);
                sellingPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
            }
            else if (mainGameScript.gameState == GameState.Menu)
            {
                hudPanel.SetActive(false);
                sellingPanel.SetActive(false);
                mainMenuPanel.SetActive(true);
            }
        }
    }
}