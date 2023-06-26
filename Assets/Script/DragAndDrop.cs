using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;
    private Vector3 mouseOffset;
    private bool isDroppedOnDish = false;
    private GameObject dish;

    private void Awake()
    {
        // Assign the dish object here or through the Inspector
        dish = GameObject.Find("dish"); // Replace "dish" with the actual name of the dish object
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            initialPosition = transform.position;
            mouseOffset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + mouseOffset;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;

            // Perform any necessary logic upon dropping the object
            // For example, check if it's dropped on the target object (dish object)
            if (IsDroppedOnDish())
            {
                isDroppedOnDish = true;
            }
            else
            {
                transform.position = initialPosition;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private bool IsDroppedOnDish()
    {
        if (dish != null)
        {
            Collider2D dishCollider = dish.GetComponent<Collider2D>();
            if (dishCollider != null)
            {
                Collider2D draggableCollider = GetComponent<Collider2D>();
                if (draggableCollider != null)
                {
                    return draggableCollider.IsTouching(dishCollider);
                }
            }
        }

        return false;
    }
}