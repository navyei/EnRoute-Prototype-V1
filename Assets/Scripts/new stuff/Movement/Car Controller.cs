using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    private bool isBoosting;
    private float boostEndTime;
    private float boostCooldownEndTime;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float boostMultiplier = 1.5f; // Multiplier for speed boost
    [SerializeField] private float boostDuration = 5f; // Duration of the speed boost
    [SerializeField] private float boostCooldown = 10f; // Cooldown time for the boost

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        HandleBoost();
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);

        // Boost Input
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > boostCooldownEndTime)
        {
            isBoosting = true;
            boostEndTime = Time.time + boostDuration;
            boostCooldownEndTime = Time.time + boostDuration + boostCooldown;
        }
    }

    private void HandleMotor()
    {
        float currentMotorForce = isBoosting ? motorForce * boostMultiplier : motorForce;
        frontLeftWheelCollider.motorTorque = verticalInput * currentMotorForce;
        frontRightWheelCollider.motorTorque = verticalInput * currentMotorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void HandleBoost()
    {
        if (isBoosting && Time.time > boostEndTime)
        {
            isBoosting = false;
        }
    }
}
