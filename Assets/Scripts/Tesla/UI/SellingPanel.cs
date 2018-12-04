using Tesla.Audio;
using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI
{
    public class SellingPanel : MonoBehaviour
    {
        MainGameScript mainGameScript;
        PlayerGameScript playerGameScript;
        AudioPlayer audioPlayer;

        public Text titleText;
        public Text fishedText;
        public Text moneyText;

        public Text buttonText;

        public bool nextDayClicked;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            playerGameScript = FindObjectOfType<PlayerGameScript>();
            audioPlayer = FindObjectOfType<AudioPlayer>();

            nextDayClicked = false;
        }

        public void OnNextDayButton()
        {
            nextDayClicked = true;
            audioPlayer.PlaySound(audioPlayer.click);
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
            if (mainGameScript.gameState == GameState.Selling)
            {
                int earnings = (int) (playerGameScript.currentWeight * 10.0f);
                
                titleText.text = $"Day {mainGameScript.currentDay}/3";

                if (playerGameScript.waterLevel >= 1.0f)
                {
                    fishedText.text = "Your boat sunk. Bad luck.";
                    moneyText.text = $"You've made no money today (total:${mainGameScript.money}).";
                }
                
                else if (playerGameScript.currentWeight <= 1.0f)
                {
                    fishedText.text = $"Bad day. You've fished {playerGameScript.currentWeight:F2}kg.";
                    moneyText.text = $"You've made ${earnings} today (total: ${mainGameScript.money}).";
                }
                
                else if (playerGameScript.currentWeight <= 3.0f)
                {
                    fishedText.text = $"Good job! You've fished {playerGameScript.currentWeight:F2}kg.";
                    moneyText.text = $"You've made ${earnings} today (total: ${mainGameScript.money}).";
                }
                
                else if (playerGameScript.currentWeight <= 8.0f)
                {
                    fishedText.text = $"Well done! You've fished {playerGameScript.currentWeight:F2}kg.";
                    moneyText.text = $"You've made ${earnings} today (total: ${mainGameScript.money}).";
                }
                
                else
                {
                    fishedText.text = $"Outstanding! You've fished {playerGameScript.currentWeight:F2}kg.";
                    moneyText.text = $"You've made ${earnings} today! (Total: ${mainGameScript.money}).";
                }
                
                buttonText.text = "Next Day";
                if (mainGameScript.currentDay == 2)
                {
                    buttonText.text = "Final day";                    
                }
                else if (mainGameScript.currentDay > 2)
                {
                    buttonText.text = "See results";                    
                }
            }
            
            else if (mainGameScript.gameState == GameState.Fishing)
            {
                nextDayClicked = false;
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                nextDayClicked = false;
            }
            else if (mainGameScript.gameState == GameState.Menu)
            {
                nextDayClicked = false;
            }
        }
    }
}