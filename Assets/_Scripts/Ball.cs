using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Block block))
                {
                    
                }
                else if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                }
                else if (hitInfo.collider.TryGetComponent(out Finish finish))
                {

                }
            }
        }
    }
}
