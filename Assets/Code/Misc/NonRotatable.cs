using UnityEngine;

namespace Misc
{
    public class NonRotatable : MonoBehaviour
    {
        private void LateUpdate() => transform.rotation = Quaternion.identity;
    }
}