using Pixelplacement;
using Pixelplacement.TweenSystem;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.CharacterControllers
{
    public class EnemyCharacterController : BaseCharacterController
    {
        EnemyGameScript gameScript;

        public Vector2 point1;
        public Vector2 point2;
        Vector2 currentTarget;

        public float speed = 2.0f;

        public Vector2 direction;

        public TweenBase currentTween;

        void Start()
        {
            gameScript = GetComponent<EnemyGameScript>();

            Reset();
        }

        void Reset()
        {
            transform.position = point1;
            currentTarget = point2;
        }

        void Update()
        {
            
            if (gameScript.state == EnemyState.Hungry)
            {
                currentTween?.Stop();
                Reset();
                Move(transform.position, point2);
            }
            else if (gameScript.state == EnemyState.Attacking)
            {
                if (currentTarget == point2 && currentTween.Status == Tween.TweenStatus.Finished)
                {
                    Move(transform.position, point1);
                    currentTarget = point1;
                }
                else if (currentTarget == point1 && currentTween.Status == Tween.TweenStatus.Finished)
                {
                    Move(transform.position, point2);
                    currentTarget = point2;
                }
            }
            else if (gameScript.state == EnemyState.Defeated)
            {
                currentTween?.Stop();
                Move(transform.position, point1);
            }
        }

        void Move(Vector2 origin, Vector2 destination, Tween.LoopType loopType=Tween.LoopType.None)
        {
            float distance = Vector3.Distance(origin, destination);
            float time = distance / speed;

            currentTween = Tween.Position(transform, origin, destination, time, 0.0f, Tween.EaseInOutStrong, loopType);
            
            direction = (destination - (Vector2) transform.position).normalized;
        }
    }
}