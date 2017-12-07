using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace kevnls
{
    public class Character : MonoBehaviour
    {
        public float messageFadeTime;
        public float messageHoldTime;
        public GameObject textObject;

        private Text textArea;
        private bool showingMessage = false;
        private float messageTimer = 0.0f;

        void Start()
        {
            textArea = textObject.GetComponentInChildren<Text>();
            textArea.CrossFadeAlpha(0.0f, 0.0f, false);
        }

        void Update()
        {
            if (showingMessage)
            {
                if (Time.fixedTime > messageTimer)
                {
                    HideMessage();
                }
            }
        }

        public void ShowGiftMessage()
        {
            showingMessage = true;
            messageTimer = 0.0f;
            string strMessage = Story.GetPhrase();
            textArea.text = strMessage;
            textArea.CrossFadeAlpha(1.0f, messageFadeTime, false);
            messageTimer = Time.fixedTime + messageHoldTime;
        }

        public IEnumerator ShowStoryBeginning()
        {
            //fade in from black to let snow start
            //disable controller for a period
            //show message
            yield return new WaitForSeconds(5);
            showingMessage = true;
            messageTimer = 0.0f;
            string strMessage = Story.GetNextParagraph();
            textArea.text = strMessage;
            textArea.CrossFadeAlpha(1.0f, messageFadeTime, false);
            messageTimer = Time.fixedTime + messageHoldTime;
        }

        public IEnumerator ShowStoryEnding()
        {
            //fade out to black
            yield return new WaitForSeconds(messageFadeTime + 2);
            showingMessage = true;
            messageTimer = 0.0f;
            string strMessage = Story.GetPhrase();
            textArea.text = strMessage;
            textArea.CrossFadeAlpha(1.0f, messageFadeTime, false);
            messageTimer = Time.fixedTime + messageHoldTime;
        }

        private void HideMessage()
        {
            textArea.CrossFadeAlpha(0.0f, messageFadeTime, false);
            showingMessage = false;
        }
    }
}
