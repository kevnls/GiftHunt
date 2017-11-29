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

        public void ShowStoryBeginning()
        {
            //showingMessage = true;
            //messageTimer = 0.0f;
            //string strMessage = Story.GetNextParagraph();
            //textArea.text = strMessage;
            //textArea.CrossFadeAlpha(1.0f, messageFadeTime, false);
            //messageTimer = Time.fixedTime + messageHoldTime;
        }

        //there's a bug here. The function should wait for the ending gift message before displaying this.
        public void ShowStoryEnding()
        {
            //showingMessage = true;
            //messageTimer = 0.0f;
            //string strMessage = Story.GetPhrase();
            //textArea.text = strMessage;
            //textArea.CrossFadeAlpha(1.0f, messageFadeTime, false);
            //messageTimer = Time.fixedTime + messageHoldTime;
        }

        private void HideMessage()
        {
            textArea.CrossFadeAlpha(0.0f, messageFadeTime, false);
            showingMessage = false;
        }
    }
}
