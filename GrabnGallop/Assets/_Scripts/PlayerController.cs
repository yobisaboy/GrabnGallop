using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

//To make sure the object contains the required components
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    #region Private Fields
    GrabnGallop _inputs;
    Vector2 _move;
    Camera _camera;
    Vector3 _camForward, _camRight;
    #endregion

    #region Serialize Fields
    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Respawn Locations")]
    [SerializeField] Transform _respawn;
    #endregion

    void Awake()
    {
        // Camera Control
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();
        
        // Inputs
        OnEnable();
    }

    private void OnEnable()
    {
        _inputs = new GrabnGallop();
        _inputs.Enable();
        _inputs.Player.Move.performed += context => _move = context.ReadValue<Vector2>();
        _inputs.Player.Move.canceled += context => _move = Vector2.zero;
    }

    private void OnDisable()=> _inputs.Disable();

    void FixedUpdate()
    {   
        // Camera Control
        _camForward = _camera.transform.forward;
        _camRight = _camera.transform.right;
        _camForward.y = 0.0f;
        _camRight.y = 0.0f;
        _camForward.Normalize();
        _camRight.Normalize();

        // Player Ground
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        // Player Movement
        Vector3 movement = (_camRight * _move.x + _camForward * _move.y) * _speed * Time.fixedDeltaTime;
        if (!_controller.enabled) { return; }
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_velocity * Time.fixedDeltaTime);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
