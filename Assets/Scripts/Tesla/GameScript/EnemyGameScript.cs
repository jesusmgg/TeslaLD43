using Pixelplacement;
using Tesla.CharacterControllers;
using UnityEngine;

namespace Tesla.GameScript
{
    public class EnemyGameScript : BaseGameScript
    {
        MainGameScript mainGameScript;

        EnemyCharacterController characterController;

        public EnemyState state;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();

            characterController = GetComponent<EnemyCharacterController>();

            state = EnemyState.Idle;
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Returning)
            {
                if (characterController.currentTween != null)
                {
                    if (characterController.currentTween.Status == Tween.TweenStatus.Running ||
                        characterController.currentTween.Status == Tween.TweenStatus.Delayed)
                    {
                        state = EnemyState.Attacking;
                    }
                    else
                    {
                        state = EnemyState.Hungry;
                    }
                }
                else
                {
                    state = EnemyState.Hungry;    
                }
            }
            else
            {
                state = Vector3.Distance(characterController.point1, transform.position) < Mathf.Epsilon
                    ? EnemyState.Idle
                    : EnemyState.Defeated;
            }
        }
    }

    public enum EnemyState
    {
        Hungry,
        Attacking,
        Defeated,
        Idle
    }
}