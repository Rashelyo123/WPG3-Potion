using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameInput : MonoBehaviour
{

    private PlayerInputAction playerInputActions;
    public event EventHandler OnInteract;

    private void Awake()
    {
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;


    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);

    }
    // Start is called before the first frame update
    public Vector2 GetMovmentInputNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();


        inputVector.Normalize();

        return inputVector;


    }
}
