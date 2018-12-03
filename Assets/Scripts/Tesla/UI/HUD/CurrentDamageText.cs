using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI.HUD
{
    public class CurrentDamageText : MonoBehaviour
    {
        PlayerGameScript playerGameScript;

        Text text;

        void Start()
        {
            playerGameScript = FindObjectOfType<PlayerGameScript>();

            text = GetComponent<Text>();
        }

        void Update()
        {
            int damage = (int) (playerGameScript.currentDamage * 100.0f);
            text.text = $"Damage: {damage}%";
        }
    }
}