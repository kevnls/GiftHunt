using UnityEngine;

namespace kevnls
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] gifts;
        public Terrain terrain;
        public int numberOfGroupsOfFiveGifts;

        private int terrainWidth; 
        private int terrainLength; 
        private int terrainPosX; 
        private int terrainPosZ;
        private int giftTally = 0;

        void Start()
        {
            terrainWidth = (int)terrain.terrainData.size.x;
            terrainLength = (int)terrain.terrainData.size.z;
            terrainPosX = (int)terrain.transform.position.x;
            terrainPosZ = (int)terrain.transform.position.z;

            PlaceGifts();
        }

        void Update()
        {

        }

        public void FoundGift()
        {
            //tally the gifts found
            giftTally++;
        }

        void PlaceGifts()
        {
            for (int x = 0; x < numberOfGroupsOfFiveGifts + 1; x++)
            {
                //randomize the placement of the gifts
                for (int i = 0; i < gifts.Length; i++)
                {

                    int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                    int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                    float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
                    Instantiate(gifts[i], new Vector3(posx, posy, posz), Quaternion.identity);
                }
            }
        }
    }
}
