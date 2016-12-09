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

        void PlaceGifts()
        {
            for (int x = 0; x < numberOfGroupsOfFiveGifts + 1; x++)
            {
                //scramble the placement of the gifts
                for (int i = 0; i < gifts.Length; i++)
                {
                    // generate random x position
                    int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                    // generate random z position
                    int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                    // get the terrain height at the random position
                    float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
                    // create new gameObject on random position
                    Instantiate(gifts[i], new Vector3(posx, posy, posz), Quaternion.identity);
                }
            }
        }
    }
}
