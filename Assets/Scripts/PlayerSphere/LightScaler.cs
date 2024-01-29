using UnityEngine;
public class LightScaler : MonoBehaviour
{
    [SerializeField] private float _defaultIntensity;
    [SerializeField] private float _defaultRange;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();

        _defaultIntensity = _light.intensity;
        _defaultRange = _light.range;

        EventHandler.OnScaling.AddListener(ScalingLight);
    }

    public void ScalingLight(float multiplier)
    {
        _light.intensity = _defaultIntensity * multiplier;
        _light.range = _defaultRange * multiplier;
    }
}