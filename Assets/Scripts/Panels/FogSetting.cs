using UnityEngine;

namespace Panels
{
    public class FogSetting : MonoBehaviour
    {
        [SerializeField] private GameObject _fog;
        [SerializeField] private Camera _camera;

        public void SetActiveFog(bool value)
        {
            _fog.SetActive(value);
            _camera.farClipPlane = value ? 1500 : 3000;
        }
    }
}