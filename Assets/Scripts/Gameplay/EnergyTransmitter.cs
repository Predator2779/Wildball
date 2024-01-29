using Gameplay;
using PlayerSphere;
using UnityEngine;

namespace Other
{
    [RequireComponent(typeof(EnergyStorage))]
    public class EnergyTransmitter : MonoBehaviour
    {
        [SerializeField] private GameObject _icon;
        private EnergyStorage _energyStorage;
        
        private void Start() => _energyStorage = GetComponent<EnergyStorage>();
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EnergyStorage energyStorage)) return;
            
            if (_energyStorage.IsCharged() && !energyStorage.IsCharged())
            {
                energyStorage.Charge();
                _energyStorage.Discharge();
                
                if (_icon != null) _icon.SetActive(false);
            }
            else if (!_energyStorage.IsCharged() && energyStorage.IsCharged())
            {
                _energyStorage.Charge();
                energyStorage.Discharge();
                
                if (_icon != null) _icon.SetActive(true);
            }
        }
    }
}