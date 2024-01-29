using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    private bool _isActive;
    
    public Timer(float value)
    {
        _time = value;
    }
}