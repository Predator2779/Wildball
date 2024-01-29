using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSphere
{
    public class Speedometer : MonoBehaviour
    {
        [SerializeField] private Text _speedo;

        public float CurrentSpeed => GetComponent<Rigidbody>().velocity.magnitude;

        private void Update()
        {
            if (_speedo != null) _speedo.text = $"{Math.Round(CurrentSpeed)} m/s";
        }
    }
}