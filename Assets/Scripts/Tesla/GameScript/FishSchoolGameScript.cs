using UnityEngine;

namespace Tesla.GameScript
{
    public class FishSchoolGameScript : BaseGameScript
    {
        public bool isHighlighted;

        PlayerGameScript currentPlayer;

        void Start()
        {
            currentPlayer = null;
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
            if (other.gameObject == currentPlayer.gameObject)
            {
                currentPlayer = null;
            }
        }
    }
}