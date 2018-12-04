using System.Collections;
using Pixelplacement;
using Tesla.Audio;
using Tesla.CharacterControllers;
using UnityEngine;

namespace Tesla.GameScript
{
    public class EnemyGameScript : BaseGameScript
    {
        MainGameScript mainGameScript;
        AudioPlayer audioPlayer;

        EnemyCharacterController characterController;

        public float damage = 0.1f;
        
        public bool canDamage;

        public EnemyState state;

        void Start()
        {
            mainGameScript = FindObjectOfType<MainGameScript>();
            audioPlayer = FindObjectOfType<AudioPlayer>();

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

            if (state == EnemyState.Idle)
            {
                canDamage = true;
            }
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                audioPlayer.StopMusic();
                audioPlayer.StartMusic(audioPlayer.enemyMusic);
                
                // Can't damage anymore this round
                StartCoroutine(StopDamaging(0.5f));
            }
        }

        IEnumerator StopDamaging(float delay = 0.0f)
        {
            yield return new WaitForSeconds(delay);
            canDamage = false;
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