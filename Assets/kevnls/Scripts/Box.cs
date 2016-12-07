using UnityEngine;
using System.Collections;

namespace kevnls
{
    public class Box : MonoBehaviour
    {

        public GameObject character;

        void OnTriggerEnter(Collider other)
        {
            character.SendMessage("ShowMessage");
        }

        void OnTriggerExit(Collider other)
        {
            character.SendMessage("HideMessage");
        }
    }
}
