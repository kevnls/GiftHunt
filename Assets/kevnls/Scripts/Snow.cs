using UnityEngine;

namespace kevnls
{
    public class Snow : MonoBehaviour
    {
        void Update()
        {
            //keep the attached transform faced one direction
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        }
    }
}
