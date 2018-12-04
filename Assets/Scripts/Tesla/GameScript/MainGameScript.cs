using System.Collections.Generic;
using Tesla.UI;
using Tesla.UI.MainMenu;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tesla.GameScript
{
    public class MainGameScript : BaseGameScript
    {
        PlayerGameScript playerGameScript;
        InfoPanel infoPanel;
        SellingPanel sellingPanel;
        MainMenu mainMenu;

        public GameState gameState;

        public int currentDay;
        public int money;
        public string playerName = "Tesla";

        [Header("Fishing")]
        public GameObject fishSchoolPrefab;
        public List<Vector2> fishSchoolPositions;
        public float fishingTime = 60.0f;
        public float fishingTimeLeft;
        GameObject currentFishSchool;

        int tutorialProgress;
        bool endOfDayDone;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();
            infoPanel = FindObjectOfType<InfoPanel>();
            sellingPanel = FindObjectOfType<SellingPanel>();
            mainMenu = FindObjectOfType<MainMenu>();

            gameState = GameState.Menu;
            
            fishingTimeLeft = fishingTime;
            currentFishSchool = null;

            tutorialProgress = 0;
            endOfDayDone = false;
            
            currentDay = 0;
            money = 0;
        }

        void ResetValues()
        {
            tutorialProgress = 0;
            
            currentDay = 0;
            money = 0;
            
            fishingTimeLeft = fishingTime;
        }

        void Update()
        {
            if (gameState == GameState.Fishing)
            {
                if (currentDay == 0)
                {
                    if (tutorialProgress == 0)
                    {
                        string message = "Day 1 of 3\n\nClick on a fish school to start fishing.";
                        infoPanel.AddMessage(message);

                        tutorialProgress = 1;
                    }   
                }
                
                fishingTimeLeft -= Time.deltaTime;

                if (fishingTimeLeft <= 0.0f)
                {
                    Destroy(currentFishSchool);
                    gameState = GameState.Returning;
                }

                if (currentFishSchool == null)
                {
                    Vector2 position = fishSchoolPositions[Random.Range(0, fishSchoolPositions.Count)];
                    while (Vector3.Distance(playerGameScript.transform.position, position) < 3.0f)
                    {
                        position = fishSchoolPositions[Random.Range(0, fishSchoolPositions.Count)];
                    }
                    
                    currentFishSchool = Instantiate(fishSchoolPrefab, position, Quaternion.identity, null);
                }
            }
            
            else if (gameState == GameState.Returning)
            {
                if (currentDay == 0)
                {
                    if (tutorialProgress == 1)
                    {
                        string message = "Return to the dock to sell your fish.\n\nBeware the crocodiles at the river.";
                        infoPanel.AddMessage(message);
                    
                        message = "Drop fish by clicking them in your boat\n(to move faster and delay sinking).";
                        infoPanel.AddMessage(message);

                        tutorialProgress = 2;
                    }
                }
                
                if (playerGameScript.isDocked)
                {
                    gameState = GameState.Selling;
                }
            }
            
            else if (gameState == GameState.Selling)
            {
                if (!endOfDayDone)
                {
                    money += (int) (playerGameScript.currentWeight * 10.0f);
                    currentDay++;

                    endOfDayDone = true;
                }

                if (sellingPanel.nextDayClicked)
                {
                    if (currentDay > 2)
                    {
                        // End game
                        gameState = GameState.Menu;
                        ResetValues();
                    }
                    else
                    {
                        gameState = GameState.Fishing;  
                        fishingTimeLeft = fishingTime;
                    }
                    
                    endOfDayDone = false;
                }
            }
            
            else if (gameState == GameState.Menu)
            {
                if (mainMenu.startClicked)
                {
                    gameState = GameState.Fishing;
                }
            }
        }
    }

    public enum GameState
    {
        Fishing,
        Returning,
        Selling,
        Menu
    }
}