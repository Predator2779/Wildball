using Gameplay.Actions;
using UnityEngine;

namespace Gameplay
{
    public class EnergyStorage : ActionCondition
    {
        [SerializeField] private bool _isCharged;
        [SerializeField] private GameObject _electricity;
        [SerializeField] private Light _light;
        [SerializeField] private Color32 _trueColor;
        [SerializeField] private Color32 _falseColor;
        
        public bool IsCharged() => _isCharged;
        public void Charge() => SetCharge(true);
        public void Discharge() => SetCharge(false);

        private void SetCharge(bool value)
        {
            Include(value);
            
            _isCharged = value;

            if (_electricity != null) _electricity.SetActive(value);
            if (_light != null) _light.color = value ? _trueColor : _falseColor;
        }
    }
}