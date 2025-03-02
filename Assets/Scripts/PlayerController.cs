using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    private Rigidbody m_rb;
    private Vector3 m_movementInput;

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
        
        float clampedX = Mathf.Clamp(newPos.x, -4f, 4f);
        float clampedZ = Mathf.Clamp(newPos.z, -1.5f, 3f);
        Vector3 clampedPos = new Vector3(clampedX, newPos.y, clampedZ);
        
        m_rb.MovePosition(clampedPos);
    }

    private void ClampMovement()
    {
    }
}
