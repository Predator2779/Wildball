using UnityEngine;

public class RotationObj : MonoBehaviour
{
    [Header("Вектор вращения:")] 
    [SerializeField] private bool _isRotate;
    
    [Header("Вектор вращения:")]
    [SerializeField] private float _speedRotation = 1f;
    [SerializeField] [Range(-1, 1)] private int _reverseDirection;

    [Header("Оси вращения:")]
    [SerializeField] [Range(0, 1)] private int _xRot;
    [SerializeField] [Range(0, 1)] private int _yRot;
    [SerializeField] [Range(0, 1)] private int _zRot;
    
    private void FixedUpdate()
    {
        var vec = _speedRotation * _reverseDirection * Time.fixedDeltaTime;
        
        if (_isRotate)
            transform.Rotate(vec * _xRot, vec * _yRot, vec * _zRot, Space.Self);
    }
}