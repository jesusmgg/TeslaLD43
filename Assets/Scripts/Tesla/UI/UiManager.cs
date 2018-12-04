using Tesla.GameScript;
using Tesla.UI.HUD;
using UnityEngine;

namespace Tesla.UI
{
    public class UiManager : MonoBehaviour
    {
        MainGameScript mainGameScript;

        public HudPanel hudPanel;
        public SellingPanel sellingPanel;
        public MainMenu.MainMenu mainMenuPanel;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing)
            {
                hudPanel.SetVisible(true);
                sellingPanel.SetVisible(false);
                mainMenuPanel.SetVisible(false);
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                hudPanel.SetVisible(true);
                sellingPanel.SetVisible(false);
                mainMenuPanel.SetVisible(false);
            }
            else if (mainGameScript.gameState == GameState.Selling)
            {
                hudPanel.SetVisible(false);
                sellingPanel.SetVisible(true);
                mainMenuPanel.SetVisible(false);
            }
            else if (mainGameScript.gameState == GameState.Menu)
            {
                hudPanel.SetVisible(false);
                sellingPanel.SetVisible(false);
                mainMenuPanel.SetVisible(true);
            }
        }
    }
}