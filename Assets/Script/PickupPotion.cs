using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool isHeld = false;
    public Transform playerHoldPosition;


    public void Initialize(Transform playerTransform)
    {
        playerHoldPosition = playerTransform;
    }

    private void OnMouseDown()
    {
        if (!isHeld)
        {
            Hold();
        }
        else
        {
            Release();
        }
    }

    private void Hold()
    {
        isHeld = true;
        transform.position = playerHoldPosition.position;
        transform.parent = playerHoldPosition;
    }

    private void Release()
    {
        isHeld = false;
        transform.parent = null;
    }

    private void Update()
    {
        if (isHeld)
        {
            transform.position = playerHoldPosition.position;
        }
    }
}
