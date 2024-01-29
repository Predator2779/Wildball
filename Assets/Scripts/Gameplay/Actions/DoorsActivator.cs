using Controllers;
using UnityEngine;

namespace Gameplay.Actions
{
    public class DoorsActivator : ActionActivator
    {
        [SerializeField] private DoorsControl[] _activatedObjects;
        public override void TurnOn() => SetActivity(true);
        public override void TurnOff() => SetActivity(false);

        private void SetActivity(bool value)
        {
            int length = _activatedObjects.Length;

            for (int i = 0; i < length; i++)
                _activatedObjects[i].OpeningDoors(value);
        }
    }
}