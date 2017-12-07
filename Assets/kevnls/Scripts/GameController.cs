using UnityEngine;
using UnityEngine.UI;

namespace kevnls
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] gifts;
        public Terrain terrain;
        public int numberOfGroupsOfFiveGifts;
        public GameObject character;
        public GameObject scoreTextObject;
        
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

        void Update()
        {

        }

        public void FoundGift()
        {
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
            character.SendMessage("ShowStoryBeginning");
        }

        void EndStory()
        {
            character.SendMessage("ShowStoryEnding");
        }
    }
}
