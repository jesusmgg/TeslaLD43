using Tesla.CharacterControllers;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.Animation
{
    public class EnemyAnimationController : BaseAnimationController
    {
        new SpriteRenderer renderer;

        EnemyGameScript gameScript;
        EnemyCharacterController characterController;

        public bool flipX;

        Color originalColor;

        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();

            gameScript = GetComponent<EnemyGameScript>();
            characterController = GetComponent<EnemyCharacterController>();

            originalColor = renderer.color;
        }

        void Update()
        {
            renderer.flipX = characterController.direction.x < 0;
            flipX = renderer.flipX;

            renderer.color = gameScript.canDamage ? originalColor : Color.clear;
        }
    }
}