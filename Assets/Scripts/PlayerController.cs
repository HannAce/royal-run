using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    private Rigidbody m_rb;
    private Vector3 m_movement;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        m_movement = context.ReadValue<Vector2>();
    }
    
    private void HandleMovement()
    {
        Vector3 currentPos = m_rb.position;
        Vector3 moveDirection = new Vector3(m_movement.x, 0, m_movement.y);
        Vector3 newPos = currentPos + moveDirection * (m_moveSpeed * Time.fixedDeltaTime);
        
        m_rb.MovePosition(newPos);
    }
}
