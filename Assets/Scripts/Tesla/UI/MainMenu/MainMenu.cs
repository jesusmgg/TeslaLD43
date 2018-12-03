using Tesla.GameScript;
using UnityEngine;

namespace Tesla.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        MainGameScript mainGameScript;
        
        public bool startClicked;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            
            startClicked = false;
        }

        void Reset()
        {
            startClicked = false;
        }

        public void OnStartButton()
        {
            startClicked = true;
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Menu)
            {
                
            }
            else if (mainGameScript.gameState == GameState.Fishing)
            {
                startClicked = false;
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                startClicked = false;
            }
            else if (mainGameScript.gameState == GameState.Selling)
            {
                startClicked = false;
            }
        }
    }
}