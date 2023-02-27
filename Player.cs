using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float     moveSpeed    = 7f;
    [SerializeField] float     rotaSpeed    = 5f;
    [SerializeField] float     playerRadius = 0.7f;
    [SerializeField] float     playerHeight = 2f;
    public           bool      isWalking;
    [SerializeField] GameInput gameInput;
    [SerializeField] Vector3   lastPosition;
    [SerializeField] LayerMask counterLayerMask;
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    
    
    public bool IsWalking()
    {
        return isWalking;
    }
    
    public void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir     = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastPosition = moveDir;
        }
        
        float interacDistance = 2f;
        if (Physics.Raycast(transform.position, lastPosition, out RaycastHit raycastHit, interacDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        } 
        
    }

    public void HandleMovement()
    {
        Vector2 inputVector  = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir      = new Vector3(inputVector.x, 0f, inputVector.y);
        float   moveDistance = moveSpeed * Time.deltaTime;
        bool    canMove      = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir
            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can only move on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move on the X
                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can only move on the Z
                    moveDir = moveDirZ;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir*moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        // transform.forward  =  moveDir;
        transform.forward = Vector3.Lerp(transform.forward, moveDir, rotaSpeed *Time.deltaTime);
    }


}
