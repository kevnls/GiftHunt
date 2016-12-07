using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace kevnls
{
    public class Character : MonoBehaviour
    {

        public float messageFadeTime;
        public GameObject textObject;

        private Text phraseText;

        void Start()
        {
            phraseText = textObject.GetComponentInChildren<Text>();
            textObject.GetComponentInChildren<CanvasRenderer>().SetAlpha(0.0f);
        }

        public void ShowMessage()
        {
            string strMessage = Story.GetPhrase();
            phraseText.text = strMessage;
            textObject.GetComponentInChildren<CanvasRenderer>().SetAlpha(1.0f);
        }

        public void HideMessage()
        {
            textObject.GetComponentInChildren<CanvasRenderer>().SetAlpha(0.0f);
        }
    }
}
