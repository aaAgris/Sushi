using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector3 StartPosition { get; private set; }
    public Transform OriginalParent { get; private set; }
    private PlateController plateController;
    private bool isDragging = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        StartPosition = rectTransform.localPosition;
        OriginalParent = transform.parent;
        plateController = FindObjectOfType<PlateController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling(); // Bring the ingredient to the front
        canvasGroup.blocksRaycasts = false; // Disable raycasts on the ingredient
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Enable raycasts on the ingredient
        isDragging = false;

        // Check if the ingredient is dropped onto a plate
        if (eventData.pointerEnter != null)
        {
            PlateController plate = eventData.pointerEnter.GetComponent<PlateController>();
            if (plate != null)
            {
                plate.AddIngredient(this); // Notify the plate to add the ingredient
                return;
            }
        }

        // Reset the ingredient's position if not dropped on a plate
        transform.SetParent(OriginalParent);
        rectTransform.localPosition = StartPosition;

        // Notify the plate to remove the ingredient
        if (plateController != null)
        {
            plateController.RemoveIngredient(this);
        }
    }

    public bool IsDragging()
    {
        return isDragging;
    }
}
