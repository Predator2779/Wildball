using UnityEngine;

namespace Gameplay.Actions
{
    public abstract class ActionActivator : MonoBehaviour
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}