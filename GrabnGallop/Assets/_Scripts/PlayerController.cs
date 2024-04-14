using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

//To make sure the object contains the required components
[RequireComponent(typeof(CharacterController))]

public class PlayerController : Subject
{
    #region Private Fields
    GrabnGallop _inputs;
    Vector2 _move;
    #endregion

    #region Serialize Fields
    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;
    #endregion

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
        // Player Movement
        Vector3 moveDirection = new Vector3(_move.x, 0.0f, _move.y);
        Vector3 movement = moveDirection * _speed * Time.fixedDeltaTime;
        if (!_controller.enabled) { return; }
        _controller.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}
