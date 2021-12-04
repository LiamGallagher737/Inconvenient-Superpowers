using System;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    [Header("Basic Stuff")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 4f;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    
    private Vector2 input;
    
    private InputActions inputActions;
    private InputActions InputActions{
        get{
            if(inputActions != null){return inputActions;}
            return inputActions = new InputActions();
        }
    }

    private void Start() {
        InputActions.Player.Movement.performed += ctx => { input = ctx.ReadValue<Vector2>(); };
        InputActions.Player.Movement.canceled += ctx => { input = Vector2.zero; };
    }

    private void OnEnable() => InputActions.Enable();
    private void OnDisable() => InputActions.Disable();

    private void Update() {
        if (input == Vector2.zero) return;
        if (input.y > 0) {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }
}
