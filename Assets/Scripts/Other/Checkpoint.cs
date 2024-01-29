using UnityEngine;

namespace Other
{
    public class Checkpoint : MonoBehaviour
    {
        private void SetCheckpoint() => EventHandler.OnLastCheckpoint?.Invoke(transform);
        private void OnTriggerEnter(Collider col)
        {
            if (col.TryGetComponent(out InputHandler inputHandler)) SetCheckpoint();
        }
    }
}