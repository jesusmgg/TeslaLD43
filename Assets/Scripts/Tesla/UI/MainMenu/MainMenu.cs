using Tesla.Audio;
using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        MainGameScript mainGameScript;
        AudioPlayer audioPlayer;

        public Text highScoreText;
        
        public bool startClicked;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            audioPlayer = FindObjectOfType<AudioPlayer>();
            
            startClicked = false;
        }

        void ResetValues()
        {
            startClicked = false;
        }

        public void OnStartButton()
        {
            startClicked = true;
            audioPlayer.PlaySound(audioPlayer.click);
            
            audioPlayer.StopMusic();
            audioPlayer.StartMusic(audioPlayer.sailingMusic);
        }
        
        public void SetVisible(bool visible)
        {
            float alpha = visible ? 1.0f : 0.0f;
            
            foreach (Text text in GetComponentsInChildren<Text>())
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            }
            foreach (Image image in GetComponentsInChildren<Image>())
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            }
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Menu)
            {
                highScoreText.text = $"Best run: ${mainGameScript.highScore}";
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