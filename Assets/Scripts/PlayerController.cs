using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    private Rigidbody m_rb;
    private Vector3 m_movementInput;

    private const float ClampedX = 4f;
    private const float MinClampedZ = -1.5f;
    private const float MaxClampedZ = 3f;

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
        m_movementInput = context.ReadValue<Vector2>();
    }
    
    private void HandleMovement()
    {
        Vector3 currentPos = m_rb.position;
        Vector3 moveDirection = new Vector3(m_movementInput.x, 0, m_movementInput.y);
        Vector3 newPos = currentPos + moveDirection * (m_moveSpeed * Time.fixedDeltaTime);
        
        float clampedX = Mathf.Clamp(newPos.x, -ClampedX, ClampedX);
        float clampedZ = Mathf.Clamp(newPos.z, MinClampedZ, MaxClampedZ);
        Vector3 clampedPos = new Vector3(clampedX, newPos.y, clampedZ);
        
        m_rb.MovePosition(clampedPos);
    }

    private void ClampMovement()
    {
        
    }
}
