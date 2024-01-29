using UnityEngine;

namespace Other
{
    public class Following : MonoBehaviour
    {
        [SerializeField] private Transform _followingObject;

        private void Update()
        {
            transform.position = _followingObject.position;
            transform.localScale = _followingObject.localScale;
        }
    }
}