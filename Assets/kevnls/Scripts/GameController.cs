using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace kevnls
{
    public class GameController : MonoBehaviour
    {
        //public Image sceneFadeImg;
        public float sceneFadeSpeed = 1.5f;
        public GameObject[] gifts;
        public Terrain terrain;
        public int numberOfGroupsOfFiveGifts;
        public GameObject character;
        public GameObject scoreTextObject;
        public const float messageHoldTime = 7;
        public const float messageFadeTime = 5;
        
        //used to keep the gifts away from the boundary mountains
        public int giftPlacementSizeBuffer = 75;

        private Text scoreText;
        private int terrainWidth; 
        private int terrainLength; 
        private int terrainPosX;
        private int terrainPosY;
        private int terrainPosZ;
        private int giftTotal;

        void Start()
        {

            //sceneFadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
            //sceneFadeImg.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);

            terrainWidth = (int)terrain.terrainData.size.x;
            terrainLength = (int)terrain.terrainData.size.z;
            terrainPosX = (int)terrain.transform.position.x;
            terrainPosY = (int)terrain.transform.position.y;
            terrainPosZ = (int)terrain.transform.position.z;

            scoreText = scoreTextObject.GetComponentInChildren<Text>();
            giftTotal = numberOfGroupsOfFiveGifts * 5;
            scoreText.text = giftTotal.ToString();

            PlaceGifts();
            StartStory();
        }

        //void FadeToClear()
        //{
        //    // Lerp the colour of the image between itself and transparent.
        //    sceneFadeImg.color = Color.Lerp(sceneFadeImg.color, Color.clear, sceneFadeSpeed * Time.deltaTime);
        //}


        //void FadeToBlack()
        //{
        //    // Lerp the colour of the image between itself and black.
        //    sceneFadeImg.color = Color.Lerp(sceneFadeImg.color, Color.black, sceneFadeSpeed * Time.deltaTime);
        //}

        public void FoundGift()
        {
            string strMessage = Story.GetPhrase();
            character.SendMessage("ShowMessage", strMessage);

            giftTotal--;
            scoreText.text = giftTotal.ToString();

            if (giftTotal <= 0)
            {
                EndStory();
            }
        }

        void PlaceGifts()
        {
            for (int x = 0; x < numberOfGroupsOfFiveGifts + 1; x++)
            {
                //randomize the placement of the gifts
                for (int i = 0; i < gifts.Length; i++)
                {
                    int posx = Random.Range(terrainPosX + giftPlacementSizeBuffer, terrainPosX + terrainWidth - giftPlacementSizeBuffer);
                    int posz = Random.Range(terrainPosZ + giftPlacementSizeBuffer, terrainPosZ + terrainLength - giftPlacementSizeBuffer);
                    float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz)) + terrainPosY;
                    Instantiate(gifts[i], new Vector3(posx, posy, posz), Quaternion.identity);
                }
            }
        }

        void StartStory()
        {
            //fade in from black, disable controller
            Wait(5);
            string strMessage = Story.GetNextParagraph();
            character.SendMessage("ShowMessage", strMessage);
        }

        void EndStory()
        {
            string strMessage;
            do
            {
                //incremental ending
                strMessage = Story.GetNextParagraph();
                Wait(messageFadeTime + 2);
                character.SendMessage("ShowMessage", strMessage);
            }
            while (strMessage != string.Empty);
            //the real end
        }

        private IEnumerator Wait(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}
