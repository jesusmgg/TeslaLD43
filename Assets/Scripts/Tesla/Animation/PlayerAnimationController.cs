using Tesla.CharacterControllers;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.Animation
{
    public class PlayerAnimationController : BaseAnimationController
    {
        Animator animator;
        SpriteRenderer spriteRenderer;
        
        PlayerCharacterController characterController;
        PlayerGameScript gameScript;

        void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            characterController = GetComponent<PlayerCharacterController>();
            gameScript = GetComponent<PlayerGameScript>();
        }

        void Update()
        {
            spriteRenderer.flipX = characterController.direction.x < 0;

            if (gameScript.isFishing && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("Throw");
            }
            else if (!gameScript.isFishing && animator.GetCurrentAnimatorStateInfo(0).IsName("Fishing"))
            {
                animator.SetTrigger("Pull");
            }
        }
    }
}