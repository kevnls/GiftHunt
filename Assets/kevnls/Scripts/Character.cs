using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace kevnls
{
    public class Character : MonoBehaviour
    {
        public GameObject textObject;

        private float messageHoldTime = GameController.messageHoldTime;
        private float messageFadeTime = GameController.messageFadeTime;
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

        public void ShowMessage(string messageText)
        {
            showingMessage = true;
            messageTimer = 0.0f;
            string strMessage = messageText;
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
