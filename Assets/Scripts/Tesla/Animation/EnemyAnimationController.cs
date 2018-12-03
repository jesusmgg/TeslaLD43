using Tesla.CharacterControllers;
using UnityEngine;

namespace Tesla.Animation
{
    public class EnemyAnimationController : BaseAnimationController
    {
        new SpriteRenderer renderer;

        EnemyCharacterController characterController;

        public bool flipX;

        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();

            characterController = GetComponent<EnemyCharacterController>();
        }

        void Update()
        {
            renderer.flipX = characterController.direction.x < 0;
            flipX = renderer.flipX;
        }
    }
}