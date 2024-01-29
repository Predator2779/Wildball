using UnityEngine;
using static GlobalVars.GlobalVariables;

public class SphereScaler : MonoBehaviour
{
    private Rigidbody _rbody;

    private void Start() => _rbody = GetComponent<Rigidbody>();

    public void ScaleWheel(float scaleValue)
    {
        ChangeScale(scaleValue);

        ChangeWeight(scaleValue * KoefWeightFromScale());

        SendScaleMessage();
    }

    public void SetScaleAndWeight(float scale, float weight)
    {
        SetScale(new Vector3(scale, scale, scale));

        SetWeight(weight);
    }

    private void ChangeScale(float scaleValue)
    {
        var scale = GetScale();

        if (scale.y + scaleValue <= MinScaleSph.y)
            SetScale(MinScaleSph);
        else if (scale.y + scaleValue >= MaxScaleSph.y)
            SetScale(MaxScaleSph);
        else
            SetScale(scale + new Vector3(scaleValue, scaleValue, scaleValue));
    }

    private void ChangeWeight(float scaleValue)
    {
        var weight = GetWeight() + scaleValue;

        if (weight <= MinWeightSph || GetScale().y <= MidScaleSph.y)
            SetWeight(MinWeightSph);
        else if (weight >= MaxWeightSph)
            SetWeight(MaxWeightSph);
        else
            SetWeight(weight + scaleValue);
    }

    private Vector3 GetScale() => transform.localScale;

    private void SetScale(Vector3 scale) => transform.localScale = scale;

    private float GetWeight() => _rbody.mass;

    private void SetWeight(float mass) => _rbody.mass = mass;

    private void SendScaleMessage() => EventHandler.OnScaling?.Invoke(transform.localScale.x);
}