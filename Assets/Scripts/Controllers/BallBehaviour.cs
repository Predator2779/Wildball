using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using static GlobalVars.GlobalVariables;

public class BallBehaviour : MonoBehaviour
{
    [Header("General:")] public Transform wildCamera;
    public float forceSpeed = 1000;
    public float spaceSpeed = 300;
    public float maxSpeed = 360;
    public float jumpForce = 3;
    public float boostForce = 5;
    public float boostDelay = 1.5f;
    
    [Header("Jump Rotation:")] public float jumpRotation = 5.0f;
    
    [Header("Bools:")]
    [SerializeField] private bool _isBoost = true;
    [SerializeField] private bool _isGround;
    public bool isDeath;

    [CanBeNull] private Collision _currentCollision;
    private Vector3 _vectorMove;
    private Rigidbody _rbody;

    private float _acceleration = 1;
    private float _speed;
    private float _jump;

    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();

        EventHandler.OnDisapperance.AddListener(Death);
    }

    public void Move(float verticalAxis, float horizontalAxis)
    {
        if (_rbody.velocity.magnitude > maxSpeed / 3.6f) return;

        var v = ProjectVector(wildCamera.forward.normalized) * verticalAxis;
        var h = ProjectVector(wildCamera.right.normalized) * horizontalAxis;

        _vectorMove = h + v;

        ApplyingForce(_vectorMove.normalized, _speed * _acceleration, ForceMode.Acceleration);
    }

    public void Boost(float verticalAxis, float horizontalAxis)
    {
        if (!_isGround && _isBoost)
        {
            var v = wildCamera.forward.normalized * verticalAxis;
            var h = wildCamera.right.normalized * horizontalAxis;

            _vectorMove = h + v;

            ApplyingForce(_vectorMove.normalized, boostForce * _speed, ForceMode.Impulse);

            if (CanBoost())
                StartCoroutine(BoostRollBack());
        }
    }

    public void Jump(float force)
    {
        force *= 5;

        if (force > _jump)
            force = _jump;

        ApplyingForce(Vector3.up, force * _speed, ForceMode.Impulse);
    }

    public float Acceleration(bool mode) => _acceleration = mode ? 3 : 1;

    private Vector3 ProjectVector(Vector3 vector)
    {
        if (_isGround && _currentCollision != null && _currentCollision.contacts.Length != 0)
            return Vector3.ProjectOnPlane(vector,
                _currentCollision.contacts[0].normal).normalized;

        return Vector3.ProjectOnPlane(vector,
            Vector3.up).normalized;
    }

    private void ApplyingForce(Vector3 vector, float force, ForceMode forceMode) =>
        _rbody.AddForce(vector * force, forceMode);

    public void GroundControl()
    {
        if (_isGround)
        {
            _speed = GetSpeed(forceSpeed);
            _jump = jumpForce;
        }
        else
        {
            _speed = GetSpeed(spaceSpeed);
            _jump = 0;

            RotateBall();
        }
    }

    private float GetSpeed(float speed)
    {
        float scaleY = transform.localScale.y;

        if (scaleY <= MidScaleSph.y)
            return speed / (MidScaleSph.y / scaleY);

        return speed * KoefSpeedFromScale / scaleY;
    }

    private void RotateBall()
    {
        if (isDeath) return;

        float speedRotation = jumpRotation * Time.timeScale;

        transform.Rotate
        (
            _vectorMove.z * speedRotation,
            0,
            -_vectorMove.x * speedRotation,
            Space.World
        );
    }

    public void Death(GameObject g)
    {
        if (g.GetInstanceID() == gameObject.GetInstanceID())
        {
            isDeath = true;
            _rbody.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _currentCollision = collision;
            _isGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _currentCollision = collision;
            _isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _currentCollision = null;
            _isGround = false;
        }
    }

    private bool CanBoost() => _isBoost && _currentCollision == null;

    private IEnumerator BoostRollBack()
    {
        _isBoost = false;

        yield return new WaitForSeconds(boostDelay);

        _isBoost = true;
    }
}