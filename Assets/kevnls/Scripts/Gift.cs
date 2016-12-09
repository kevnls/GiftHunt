using UnityEngine;

namespace kevnls
{
    public class Gift : MonoBehaviour
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
