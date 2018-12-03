using UnityEngine;

namespace Tesla.GameScript
{
    public class FishSchoolGameScript : BaseGameScript
    {
        public bool isHighlighted;

        public float weight;

        PlayerGameScript currentPlayer;

        void Start()
        {
            currentPlayer = null;

            weight = Random.Range(0.2f, 1.0f);
        }

        void Update()
        {
            if (currentPlayer != null)
            {
                // If player has finished fishing this school, destroy it
                if (currentPlayer.lastFishedSchool == this && !currentPlayer.isFishing)
                {
                    Destroy(gameObject);
                }
            }
        }
        
        void OnMouseEnter()
        {
            isHighlighted = true;
        }
        
        void OnMouseExit()
        {
            isHighlighted = false;
        }
        
        void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                currentPlayer = other.gameObject.GetComponent<PlayerGameScript>();
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject == currentPlayer.gameObject)
                {
                    currentPlayer = null;
                }
            }
        }
    }
}