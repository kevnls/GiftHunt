using UnityEngine;
using UnityEngine.UI;

namespace kevnls
{
    public class Character : MonoBehaviour
    {
        public float messageFadeTime;
        public float messageHoldTime;
        public GameObject textObject;

        private Text phraseText;
        private bool showingMessage = false;
        private float messageTimer = 0.0f;

        void Start()
        {
            phraseText = textObject.GetComponentInChildren<Text>();
            phraseText.CrossFadeAlpha(0.0f, 0.0f, false);
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

        public void ShowMessage()
        {
            showingMessage = true;
            messageTimer = 0.0f;
            string strMessage = Story.GetPhrase();
            phraseText.text = strMessage;
            phraseText.CrossFadeAlpha(1.0f, messageFadeTime, false);
            messageTimer = Time.fixedTime + messageHoldTime;
        }

        private void HideMessage()
        {
            phraseText.CrossFadeAlpha(0.0f, messageFadeTime, false);
            showingMessage = false;
        }
    }
}
