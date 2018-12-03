using Cinemachine;
using UnityEngine;

namespace Tesla.GameScript
{
    public class CameraGameScript : BaseGameScript
    {
        MainGameScript mainGameScript;
        PlayerGameScript playerGameScript;
        
        CinemachineVirtualCamera virtualCamera;

        public Vector3 fishingPosition;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            playerGameScript = FindObjectOfType<PlayerGameScript>();

            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing)
            {
                virtualCamera.Follow = null;
                transform.position = fishingPosition;
            }
            else if (mainGameScript.gameState == GameState.Returning)
            {
                virtualCamera.Follow = playerGameScript.transform;
            }
            else if (mainGameScript.gameState == GameState.Selling)
            {
                
            }
            else if (mainGameScript.gameState == GameState.Menu)
            {
                
            }
        }
    }
}