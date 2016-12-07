using UnityEngine;

namespace kevnls
{
    public class Snow : MonoBehaviour
    {
        void Update()
        {
            //keep the attached transform faced one direction
            transform.Rotate(0, 25, 0);
        }
    }
}
