using System;
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
        
        GameObject waterMask;

        public bool flipX;

        public float failSinkDistance;

        float previousWaterLevel;

        void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            characterController = GetComponent<PlayerCharacterController>();
            gameScript = GetComponent<PlayerGameScript>();
            
            waterMask = GetComponentInChildren<WaterMaskAnimationController>().gameObject;
            
            previousWaterLevel = gameScript.waterLevel;
        }

        void Update()
        {
            spriteRenderer.flipX = characterController.direction.x < 0;
            flipX = spriteRenderer.flipX;

            if (gameScript.isFishing && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("Throw");
            }
            else if (!gameScript.isFishing && animator.GetCurrentAnimatorStateInfo(0).IsName("Fishing"))
            {
                animator.SetTrigger("Pull");
            }
            
            // Sinking
            float sinking = (previousWaterLevel - gameScript.waterLevel) * failSinkDistance;
            
            float yPosition = transform.position.y + sinking;
            float waterMaskYPosition = waterMask.transform.localPosition.y - sinking;
            
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
            waterMask.transform.localPosition = new Vector3(waterMask.transform.localPosition.x, 
                waterMaskYPosition, waterMask.transform.localPosition.z);

            previousWaterLevel = gameScript.waterLevel;
        }
    }
}