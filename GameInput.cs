using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    PlayerInputAction         playerInputAction;
    public event EventHandler OnInteractAction;
    void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Interact.performed += Interact_performed;
    }

    void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        
        // Vector2 inputVector = new Vector2(0, 0);
        // if(Input.GetKey((KeyCode.W)))
        // {
        //     inputVector.y = 1;
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     inputVector.y = -1;
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     inputVector.x = -1;
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     inputVector.x = 1;
        // }
        inputVector = inputVector.normalized;
        
        return inputVector;
    }
}
