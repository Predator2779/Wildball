using UnityEngine;
using UnityEngine.UI;

namespace Other
{
    public class ExecutingIndicator : MonoBehaviour
    {
        // [SerializeField][Range(0, 1)] private float _value;
        [SerializeField] private Slider _slider;
        [SerializeField] private Light _light;
        [SerializeField] private Image _fill;
        [SerializeField] private Gradient _gradientLight;
        [SerializeField] private Gradient _gradientFill;

        // private void Update() => SetCurrentValue(_value);
        
        public void SetCurrentValue(float value)
        {
            _slider.value = value;
            _light.color = _gradientLight.Evaluate(_slider.normalizedValue);
            _fill.color = _gradientFill.Evaluate(_slider.normalizedValue);
        }
    }
}