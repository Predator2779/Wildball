using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _wildBall;

        [SerializeField] private float _minAngle = -75;
        [SerializeField] private float _maxAngle = 15;
    
        [Range(1.0f, 100.0f)] public float _sensitivity = 10.0f;

        private Vector3 _offset;
        private float _xRot, _yRot;

        private void Start() => StartCalibration();

        private void StartCalibration()
        {
            _offset = transform.position - _wildBall.position;
        }

        public void CameraControl(float mouse_X, float mouse_Y)
        {
            SetRotation(mouse_X, mouse_Y);
            GetScaleDistance();
            SetDistance(transform.localRotation * _offset * GetScaleDistance() + _wildBall.position);
        }
    
        private void SetDistance(Vector3 position)
        {
            transform.position = position;

            if (!Physics.Linecast(_wildBall.position, transform.position, out RaycastHit hit)) return;
            if (hit.collider.isTrigger) return;
            
            Vector3 hitLine = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            transform.position = hitLine;
        }

        private void SetRotation(float mouse_X, float mouse_Y)
        {
            _xRot = transform.localEulerAngles.y + mouse_X * _sensitivity * Time.timeScale;
            _yRot += mouse_Y * _sensitivity * Time.timeScale;
            _yRot = Mathf.Clamp(_yRot, _minAngle, _maxAngle);

            transform.localEulerAngles = new Vector3(-_yRot, _xRot, 0);
        }
    
        private float GetScaleDistance() => _wildBall.localScale.y / 3;
    }
}