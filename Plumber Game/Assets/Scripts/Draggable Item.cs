using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "P";  // Tag for valid drop destinations
    Vector3 lastpos;
    PipelinePiece pipelinePiece;
    public GameObject connectionIndicator;  // Assign this in the Inspector

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        pipelinePiece = GetComponent<PipelinePiece>();
    }

    private void Start()
    {
        // Ensure the piece is slightly in front of other objects
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.01f);
    }

    void OnMouseDown()
    {
        lastpos = transform.position;
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;

        // Raycasting from mouse position to detect objects
        RaycastHit2D hitInfo = Physics2D.Raycast(MouseWorldPosition(), Vector2.zero);

        if (hitInfo.collider != null && hitInfo.collider.tag == destinationTag)
        {
            Transform destinationTransform = hitInfo.transform;

            // Always move to the destination position
            transform.position = destinationTransform.position + new Vector3(0, 0, -0.01f);

            // Check for valid connections and enable the indicator if connections are valid
            if (CheckValidConnections(destinationTransform))
            {
                if (connectionIndicator != null)
                {
                    connectionIndicator.SetActive(true);
                }
            }
        }
        else
        {
            // If dropped on a non-destination tag or empty space, return to last position
            transform.position = lastpos;
        }

        collider2d.enabled = true;
    }

    bool CheckValidConnections(Transform destinationTransform)
    {
        PipelinePiece destinationPiece = destinationTransform.GetComponent<PipelinePiece>();

        if (pipelinePiece != null && destinationPiece != null)
        {
            foreach (Transform connectionPoint in pipelinePiece.connectionPoints)
            {
                foreach (Transform destConnectionPoint in destinationPiece.connectionPoints)
                {
                    if (Vector3.Distance(connectionPoint.position, destConnectionPoint.position) < 0.1f)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}