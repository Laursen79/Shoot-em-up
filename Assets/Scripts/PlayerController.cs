using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : CameraTarget
{
    [SerializeField] private float moveSpeed;
    
    //The maximum distance which can be traveled at max speed until reaching the peak of the jump.
    [SerializeField] private float jumpPeakDistance;

    [SerializeField] private float jumpHeight;

    //The gravitational constant.
    private float _g;
    
    //Current vertical velocity.
    private float _vVelocity;

    //If set to false, the player is unable to move.
    private bool _acceptInput = true;
    
    //The current movement to be performed by the avatar.
    private Vector3 _currMov;
    
    private CharacterController _charCon;

    private void Awake()
    {
        _charCon = GetComponent<CharacterController>();

    }

    private static float PlayerGravity(float maxJumpHeight, float maxLateralSpeed, float distanceToJumpPeak)
    {
        return -2 * (maxJumpHeight * maxLateralSpeed * maxLateralSpeed) / (distanceToJumpPeak * distanceToJumpPeak);
    }

    private void Update()
    {
        if (GetInputFromPlayer() == Vector3.zero)
            _charCon.Move(Vector3.zero);

    }

    private void FixedUpdate()
    {
        var input = GetInputFromPlayer();
        var movement = Movement(input, moveSpeed);
        _charCon.Move(movement);
    }

    Vector3 GetInputFromPlayer()
    {
        if (!_acceptInput) return Vector3.zero;
        var movement = new Vector3
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Jump"),
            z = Input.GetAxis("Vertical")
        };
        return movement;
    }

    private Vector3 Movement(Vector3 playerInput, float speedMultiplier)
    {
        var moveScalar = Math.Sqrt(playerInput.x * playerInput.x + playerInput.z * playerInput.z);
        if (moveScalar > 0)
            moveScalar = 1 / moveScalar;
        
        Vector3 movement = new Vector3
        {
            //Lateral movement
            x = playerInput.x * (float)moveScalar,
            y = 0,
            z = playerInput.z * (float)moveScalar
        };
        
        var deltaTime = Time.fixedDeltaTime;
        movement *= speedMultiplier;
        
        //This might not need to be updated every fixed update
        _g = PlayerGravity(jumpHeight, moveSpeed, jumpPeakDistance);
        
        //Vertical movement
        if (IsGrounded(_charCon.collisionFlags))
        {
            _vVelocity = 0;
            if (playerInput.y > 0)
                _vVelocity = JumpVelocity(jumpHeight, speedMultiplier, jumpPeakDistance);
        }
        else
            _vVelocity += _g * deltaTime;
        
        movement.y = _vVelocity;
        
        return movement * deltaTime;
    }
    
    private static float JumpVelocity(float maxJumpHeight, float maxLateralSpeed, float distanceToJumpPeak)
    {
        return 2 * maxJumpHeight * maxLateralSpeed / distanceToJumpPeak;
    }


    private static bool IsGrounded(CollisionFlags collisionFlags)
    {
        return (collisionFlags & CollisionFlags.Below) != 0;
    }

}
