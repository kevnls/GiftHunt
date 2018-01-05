using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

namespace kevnls
{
    public class GameController : MonoBehaviour
    {
        public Image sceneFadeImg;
        public float sceneOpeningWait = 5f;
        public float sceneFadeSpeed = 1.5f;
        public GameObject[] gifts;
        public Terrain terrain;
        public int numberOfGroupsOfFiveGifts;
        public GameObject character;
        public GameObject scoreTextObject;
        public const float messageHoldTime = 7;
        public const float messageFadeTime = 5;
        public int giftPlacementSizeBuffer = 75;

        private FirstPersonController firstPersonController;
        private Text scoreText;
        private int terrainWidth; 
        private int terrainLength; 
        private int terrainPosX;
        private int terrainPosY;
        private int terrainPosZ;
        private int giftTotal;

        void Start()
        {

            sceneFadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);

            firstPersonController = character.GetComponent<FirstPersonController>();

            terrainWidth = (int)terrain.terrainData.size.x;
            terrainLength = (int)terrain.terrainData.size.z;
            terrainPosX = (int)terrain.transform.position.x;
            terrainPosY = (int)terrain.transform.position.y;
            terrainPosZ = (int)terrain.transform.position.z;

            scoreText = scoreTextObject.GetComponentInChildren<Text>();
            giftTotal = numberOfGroupsOfFiveGifts * 5;
            scoreText.text = giftTotal.ToString();

            PlaceGifts();
            StartCoroutine(StartStory());
        }

        public void FoundGift()
        {
            string strMessage = Story.GetPhrase();
            character.SendMessage("ShowMessage", strMessage);

            giftTotal--;
            scoreText.text = giftTotal.ToString();

            if (giftTotal <= 0)
            {
                StartCoroutine(EndStory());
            }
        }

        void PlaceGifts()
        {
            for (int x = 0; x < numberOfGroupsOfFiveGifts + 1; x++)
            {
                for (int i = 0; i < gifts.Length; i++)
                {
                    int posx = Random.Range(terrainPosX + giftPlacementSizeBuffer, terrainPosX + terrainWidth - giftPlacementSizeBuffer);
                    int posz = Random.Range(terrainPosZ + giftPlacementSizeBuffer, terrainPosZ + terrainLength - giftPlacementSizeBuffer);
                    float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz)) + terrainPosY;
                    Instantiate(gifts[i], new Vector3(posx, posy, posz), Quaternion.identity);
                }
            }
        }

        IEnumerator StartStory()
        {
            firstPersonController.InputEnabled = false;

            string strMessage = Story.GetNextParagraph();
            character.SendMessage("ShowMessage", strMessage);

            yield return new WaitForSeconds(sceneOpeningWait);

            StartCoroutine(FadeToClear());
            firstPersonController.InputEnabled = true;
        }

        IEnumerator EndStory()
        {
            StartCoroutine(FadeToBlack());

            string strMessage;
            do
            {
                yield return new WaitForSeconds(messageFadeTime + messageHoldTime);
                firstPersonController.InputEnabled = false;

                //incremental ending
                strMessage = Story.GetNextParagraph();
                character.SendMessage("ShowMessage", strMessage);
            }
            while (strMessage != string.Empty);
            //the end
            SceneManager.LoadScene("Start");
        }

        IEnumerator FadeToClear()
        {
            CanvasGroup fadeCanvas = sceneFadeImg.GetComponent<CanvasGroup>();
            while (fadeCanvas.alpha > 0)
            {
                fadeCanvas.alpha -= Time.deltaTime / sceneFadeSpeed;
                yield return null;
            }

            //testing code for story ending
            //FoundGift();
        }


        IEnumerator FadeToBlack()
        {
            CanvasGroup fadeCanvas = sceneFadeImg.GetComponent<CanvasGroup>();
            while (fadeCanvas.alpha < 1)
            {
                fadeCanvas.alpha += Time.deltaTime / sceneFadeSpeed;
                yield return null;
            }
        }
    }
}
