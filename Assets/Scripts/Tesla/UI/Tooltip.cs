using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI
{
    public class Tooltip : MonoBehaviour
    {
        PlayerGameScript playerGameScript;
        
        Image image;
        Text text;

        Color originalColor;
        Color originalTextColor;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();

            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();

            originalColor = image.color;
            originalTextColor = text.color;
            
            Hide();
        }

        void Update()
        {
            text.text = playerGameScript.tooltipText;
            transform.position = (Vector2) Input.mousePosition;
            
            if (text.text != "")
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        void Hide()
        {
            image.color = Color.clear;
            text.color = Color.clear;
        }

        void Show()
        {
            image.color = originalColor;
            text.color = originalTextColor;
        }
    }
}