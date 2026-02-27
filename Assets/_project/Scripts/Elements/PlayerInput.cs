using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera mainCamera;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public LayerMask jumpLayers;
    public LayerMask lookLayers;
    public float fallSpeedBonus;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        var direction = Vector3.zero;
        var currentSpeed = walkSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& CheckIfLanded())
        {
            Jump();
        }
        MovePlayer(direction,currentSpeed);
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        if (Physics.Raycast(mainCamera.transform.position,
            mainCamera.ScreenPointToRay(Input.mousePosition).direction,
            out var hit,
            50,
            lookLayers))
        {
            var lookPos = hit.point;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce);
    }

    private bool CheckIfLanded()
    {
        if(Physics.Raycast(transform.position + Vector3.up * .1f, Vector3.down, .3f, jumpLayers))
        {
            return true;
        }
        return false;
    }

    public void MovePlayer(Vector3 dir, float speed)
    {
        var yVeloctiy = _rb.linearVelocity;
        yVeloctiy.x=0;
        yVeloctiy.z = 0;
        
        if(yVeloctiy.y < 0)
        {
            yVeloctiy.y -= fallSpeedBonus * Time.deltaTime;
        }

        _rb.linearVelocity = dir.normalized * speed + yVeloctiy;
    }
}
