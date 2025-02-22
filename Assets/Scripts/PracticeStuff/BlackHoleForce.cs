using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BlackHoleForce : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    private void FixedUpdate()
    {
        Vector3 force = (BlackHoleAttractor.instance.transform.position - transform.position).normalized;
        rb.AddForce(force * BlackHoleAttractor.instance.PullForce, ForceMode.Impulse);
    }
}
