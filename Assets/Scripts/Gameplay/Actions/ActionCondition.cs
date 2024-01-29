using UnityEngine;

namespace Gameplay.Actions
{
    public class ActionCondition : MonoBehaviour
    {
        [SerializeField] private bool _isIncluded;
        public bool IsIncluded => _isIncluded;

        public void Include(bool value)
        {
            _isIncluded = value;
            EventHandler.OnIncluded?.Invoke();
        }
    }
}