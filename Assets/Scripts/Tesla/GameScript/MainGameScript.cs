using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tesla.GameScript
{
    public class MainGameScript : BaseGameScript
    {
        PlayerGameScript playerGameScript;
        
        public GameState gameState = GameState.Fishing;

        [Header("Fishing")]
        public GameObject fishSchoolPrefab;
        public List<Vector2> fishSchoolPositions;
        public float fishingTime = 60.0f;
        public float fishingTimeLeft;
        GameObject currentFishSchool;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();
            
            fishingTimeLeft = fishingTime;
            currentFishSchool = null;
        }

        void Update()
        {
            if (gameState == GameState.Fishing)
            {
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
                if (playerGameScript.isDocked)
                {
                    gameState = GameState.Selling;
                }
            }
            
            else if (gameState == GameState.Selling)
            {
                
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