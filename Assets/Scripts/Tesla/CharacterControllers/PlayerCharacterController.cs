using Pixelplacement;
using Tesla.Controls;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.CharacterControllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        public float speed = 2.0f;

        public Vector2 direction;

        MouseControls controls;
        PlayerGameScript gameScript;

        void Start()
        {
            controls = GetComponent<MouseControls>();
            gameScript = GetComponent<PlayerGameScript>();
            
            direction = Vector2.right;
        }

        void Update()
        {
            // Take away control is player is fishing
            if (!gameScript.isFishing)
            {
                if (controls.GetMouseButtonDown(0))
                {
                    MoveTo(controls.GetMouseWorldPosition());
                }    
            }

            if (gameScript.isFishing)
            {
                Tween.Stop(transform.GetInstanceID());
            }
        }

        void MoveTo(Vector2 destination)
        {
            float distance = Vector3.Distance(transform.position, destination);
            float time = distance / speed;

            Tween.Position(transform, transform.position, destination, time, 0.0f, Tween.EaseInOut);

            direction = (destination - (Vector2) transform.position).normalized;
        }
    }
}