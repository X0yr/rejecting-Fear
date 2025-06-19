using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputEctions playerInputActions;

    public event EventHandler onPlayerAttack;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputEctions();
        playerInputActions.Enable();


        playerInputActions.Combat.Attack.started += PlayerAttack_started;
    }

    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
        onPlayerAttack?.Invoke(this, EventArgs.Empty);

    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePase = Mouse.current.position.ReadValue();
        return mousePase;
    }
}
