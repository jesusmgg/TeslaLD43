using Pixelplacement;
using Tesla.Controls;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.CharacterControllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        public float speed = 2.0f;
        public float weightSlowdownFactor = 8.0f;

        public Vector2 direction;

        MouseControls controls;
        PlayerGameScript gameScript;
        
        MainGameScript mainGameScript;

        AnimationCurve currentAnimationCurve;
        Vector3 startingPosition;
        
        bool newDay;

        void Start()
        {
            controls = GetComponent<MouseControls>();
            gameScript = GetComponent<PlayerGameScript>();

            mainGameScript = FindObjectOfType<MainGameScript>();
            
            direction = Vector2.right;
            
            startingPosition = transform.position;

            newDay = false;
        }

        void ResetValues()
        {
            transform.position = startingPosition;

            newDay = false;
        }

        void Update()
        {
            if (mainGameScript.gameState == GameState.Fishing)
            {
                if (newDay)
                {
                    ResetValues();
                }
                
                currentAnimationCurve = Tween.EaseInOut;
                
                if (!gameScript.isFishing)
                {
                    if (controls.GetMouseButtonDown(0))
                    {
                        MoveTo(controls.GetMouseWorldPosition(), currentAnimationCurve);
                    }    
                }

                // Take away control is player is fishing
                if (gameScript.isFishing)
                {
                    Tween.Stop(transform.GetInstanceID());
                }
            }
            
            else if (mainGameScript.gameState == GameState.Returning) 
            {
                currentAnimationCurve = Tween.EaseOut;
                
                if (controls.GetMouseButtonDown(0))
                {
                    MoveTo(controls.GetMouseWorldPosition(), currentAnimationCurve);
                }
            }
            
            else if (mainGameScript.gameState == GameState.Selling)
            {
                newDay = true;
            }
            
            else if (mainGameScript.gameState == GameState.Menu) 
            {
                newDay = true;
            }
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Tween.Stop(transform.GetInstanceID());

                if (gameScript.waterLevel < 1.0f)
                {
                    MoveTo((Vector2) transform.position - direction, Tween.EaseInOut);
                }
            }
        }

        void MoveTo(Vector2 destination, AnimationCurve animationCurve)
        {
            float trueSpeed = speed - gameScript.currentWeight / weightSlowdownFactor;
            
            float distance = Vector3.Distance(transform.position, destination);
            float time = distance / trueSpeed;

            Tween.Position(transform, transform.position, destination, time, 0.0f, animationCurve);

            direction = (destination - (Vector2) transform.position).normalized;
        }
    }
}