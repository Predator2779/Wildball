using System;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private List<Rigidbody> _rbodys;

    private void ApplyForce(ContactPoint point)
    {
        foreach (var rbody in _rbodys)
            rbody.AddForce(point.normal * _force * rbody.mass / rbody.velocity.magnitude * Time.fixedDeltaTime, ForceMode.Force);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            var rbody = collision.transform.GetComponent<Rigidbody>();
            
            if (!_rbodys.Contains(rbody))
                _rbodys.Add(rbody);
            
            ApplyForce(collision.GetContact(0));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var rbody = collision.transform.GetComponent<Rigidbody>();
        
        if (_rbodys.Contains(rbody))
            _rbodys.Remove(rbody);
    }
}