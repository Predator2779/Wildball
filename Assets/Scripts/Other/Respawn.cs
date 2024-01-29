using UnityEngine;

namespace Other
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField] private Transform _respawnPlace;
        private void Start() => EventHandler.OnLastCheckpoint.AddListener(SetRespawnPlace);
        private void SetRespawnPlace(Transform place) => _respawnPlace = place;
        private void OnTriggerEnter(Collider collider) => collider.transform.position = _respawnPlace.position;
    }
}