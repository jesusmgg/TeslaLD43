using System.Collections;
using System.Collections.Generic;
using Tesla.GameScript;
using UnityEngine;
using UnityEngine.UI;

namespace Tesla.UI
{
    public class InfoPanel : MonoBehaviour
    {
        Queue<InfoMessage> queue;
        
        Image image;
        Text text;

        Color originalColor;
        Color originalTextColor;
        
        bool run = true;
        
        public float showingTime = 5.0f;

        void Start()
        {
            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();

            originalColor = image.color;
            originalTextColor = text.color;
            
            queue = new Queue<InfoMessage>();
            
            StartCoroutine(Run());
            
            Hide();
        }
        
        public void AddMessage(InfoMessage infoMessage)
        {
            queue.Enqueue(infoMessage);
        }

        public void AddMessage(string message)
        {
            InfoMessage infoMessage = new InfoMessage {text = message};
            queue.Enqueue(infoMessage);
        }

        IEnumerator Run()
        {
            while (run)
            {
                if (queue.Count > 0)
                {
                    text.text = queue.Dequeue().text;
                    Show();
                    yield return new WaitForSeconds(showingTime);
                    Hide();
                    yield return new WaitForSeconds(2.0f);
                    text.text = "";
                }
                else
                {
                    yield return new WaitForSeconds(1.0f);
                }
            }

            yield return null;
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
    
    public class InfoMessage
    {
        public string text;
    }
}