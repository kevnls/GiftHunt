using UnityEngine;

namespace kevnls
{
    public class Gift : MonoBehaviour
    {
        public GameObject character;
        public GameObject gameController;
        public AudioClip unwrapSound;

        void OnTriggerEnter(Collider other)
        {
            character.SendMessage("ShowMessage");
            gameController.SendMessage("FoundGift");
            AudioSource.PlayClipAtPoint(unwrapSound, gameObject.transform.position);
            GameObject.Destroy(gameObject);
        }
    }
}
