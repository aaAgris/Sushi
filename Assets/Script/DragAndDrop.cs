using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 initialPosition;
    private Vector3 mouseOffset;
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            // Store the initial position and calculate the offset from the mouse position
            initialPosition = transform.position;
            mouseOffset = transform.position - GetMouseWorldPosition();

            // Set isDragging to true
            isDragging = true;

            // Enable the SpringJoint2D component
            springJoint.enabled = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update the object's position based on the mouse position
            transform.position = GetMouseWorldPosition() + mouseOffset;

            // Update the target position of the SpringJoint2D to the current position
            springJoint.connectedAnchor = transform.position;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            // Set isDragging to false and perform any necessary logic upon dropping the object
            isDragging = false;

            // Disable the SpringJoint2D component
            springJoint.enabled = false;

            // Restore Rigidbody2D properties
            rb.bodyType = RigidbodyType2D.Dynamic;

            // Add your code here to handle dropping the object, such as snapping it to a target position or checking for correct placement
            // Example:
            if (transform.position.y < 0f)
            {
                // Object dropped in an invalid position, snap it back to the initial position
                transform.position = initialPosition;
            }
            else
            {
                // Object dropped in a valid position, perform any necessary actions
                // ...
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}