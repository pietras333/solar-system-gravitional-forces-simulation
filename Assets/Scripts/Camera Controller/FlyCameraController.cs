using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class FlyCameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float boostMultiplier = 3f;
    public float lookSensitivity = 2f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float verticalInput;

    private float rotationX;
    private float rotationY;

    private bool isBoosting;

    private void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
    private void OnLook(InputValue value) => lookInput = value.Get<Vector2>();
    private void OnUp(InputValue value) => verticalInput = value.isPressed ? 1f : 0f;
    private void OnDown(InputValue value) => verticalInput = value.isPressed ? -1f : 0f;
    private void OnBoost(InputValue value) => isBoosting = value.isPressed;

    private void Update()
    {
        HandleLook();
        HandleMovement();
    }

    private void HandleLook()
    {
        rotationX -= lookInput.y * lookSensitivity;
        rotationY += lookInput.x * lookSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    private void HandleMovement()
    {
        float currentSpeed = moveSpeed * (isBoosting ? boostMultiplier : 1f);
        Vector3 direction = new Vector3(moveInput.x, verticalInput, moveInput.y);
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.Self);
    }
}