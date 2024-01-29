using System.Linq;
using Other;
using UnityEngine;

namespace Gameplay.Actions
{
    public class ActionSwitcher : MonoBehaviour
    {
        [SerializeField] private ActionCondition[] _conditions;
        [SerializeField] private ActionActivator[] _activators;
        [SerializeField] private ExecutingIndicator _indicator;

        private void Start()
        {
            EventHandler.OnIncluded.AddListener(CheckExecuting);
            CheckExecuting();
        }
        private void OnDisable() => EventHandler.OnIncluded.RemoveListener(CheckExecuting);

        private void CheckExecuting()
        {
            if (_conditions == null || _activators == null) return;
            
            SetIndication();
            
            if (_conditions.Any(c => !c.IsIncluded))
            {
                Execute(false);
                return;
            }

            Execute(true);
        }

        private void SetIndication()
        {
            if (_indicator == null) return;
            
            float all = _conditions.Length + 1;
            float startValue = 1 / all;
            int included = GetIncludedConditions();
            float value = included / all + startValue;
            
            _indicator.SetCurrentValue(value);
        }

        private int GetIncludedConditions() => _conditions.Count(c => c.IsIncluded);
        
        private void Execute(bool value)
        {
            foreach (var activator in _activators)
            {
                if (value) activator.TurnOn();
                else activator.TurnOff();
            }
        }
    }
}