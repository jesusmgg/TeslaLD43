using System.Collections.Generic;
using Tesla.GameScript;
using UnityEngine;

namespace Tesla.Animation
{
    public class FishStack : MonoBehaviour
    {
        PlayerGameScript playerGameScript;
        PlayerAnimationController playerAnimationController;

        new SpriteRenderer renderer;

        public SpriteMask spriteMask;
        public List<Sprite> sprites;

        float originalX;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();
            playerAnimationController = FindObjectOfType<PlayerAnimationController>();

            renderer = GetComponent<SpriteRenderer>();

            originalX = transform.localPosition.x;
        }

        void Update()
        {
            if (playerGameScript.currentWeight <= 0.0f)
            {
                renderer.sprite = sprites[0];
            }

            else if (playerGameScript.currentWeight <= 1.5f)
            {
                renderer.sprite = sprites[1];
            }

            else if (playerGameScript.currentWeight <= 4.0f)
            {
                renderer.sprite = sprites[2];
            }

            else if (playerGameScript.currentWeight <= 8.0f)
            {
                renderer.sprite = sprites[3];
            }

            else
            {
                renderer.sprite = sprites[4];
            }

            renderer.flipX = playerAnimationController.flipX;

            transform.localPosition = renderer.flipX
                ? new Vector3(-originalX, transform.localPosition.y, transform.localPosition.z)
                : new Vector3(originalX, transform.localPosition.y, transform.localPosition.z);
        }
    }
}