using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI.HUD
{
    public class HudPanel : MonoBehaviour
    {
        // Horribly rushed method that kills alpha values (repeated in other panels too)
        public void SetVisible(bool visible)
        {
            float alpha = visible ? 1.0f : 0.0f;
            
            foreach (Text text in GetComponentsInChildren<Text>())
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            }
            foreach (Image image in GetComponentsInChildren<Image>())
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            }
        }
    }
}