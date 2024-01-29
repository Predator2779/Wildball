using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _force;
    [SerializeField] private float _minSpeedObj = 100;
    
    private void ApplyForce(Collision col, ForceMode mode)
    {
        var rbody = col.transform.GetComponent<Rigidbody>();
        var speed = _minSpeedObj / 3.6;

        var v = 
            transform.right * _direction.x +
            transform.up * _direction.y +
            transform.forward * _direction.z;
        
        var vec = Vector3.ProjectOnPlane(v, col.contacts[0].normal).normalized;
        
        if (rbody.velocity.magnitude >= speed)
            rbody.AddForce(vec * _force, mode);
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.CompareTag("Player"))
            ApplyForce(col, ForceMode.Impulse);
    }
}