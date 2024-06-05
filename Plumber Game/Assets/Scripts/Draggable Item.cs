using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "P"; // Tag for valid drop destinations
    Vector3 lastpos;
   // PipelinePiece pipelinePiece; // You can uncomment this if needed
   [SerializeField] LayerMask placinglayer;
    [SerializeField] LayerMask pipeLayer;
    public bool isPlaced = true;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     

[SerializeField ]   SpriteRenderer EmptyPipe;
 [SerializeField]   SpriteRenderer filledPipe;
[SerializeField]    SpriteRenderer BackGRoundSpirte;
    Collider2D col;
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
      //   pipelinePiece = GetComponent<PipelinePiece>();
    }

    private void Start()
    {
        // Ensure the piece is slightly in front of other objects
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.01f);
    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.canPlay) return;
        
            lastpos = transform.position;
            offset = transform.position - MouseWorldPosition();
        
      
    }

    void OnMouseDrag()
    {
        if (!GameManager.Instance.canPlay) return;
        // pipelinePiece.ReliseWater();
        IncreaseSortingLayers(true);
       isPlaced=false;
        transform.position = MouseWorldPosition() + offset;
    }
    void IncreaseSortingLayers(bool m)
    {
     
        if (m)
        {
            EmptyPipe.sortingOrder = 7;
            filledPipe.sortingOrder = 8;
            BackGRoundSpirte.sortingOrder = 6;
        }
        else
        {
            EmptyPipe.sortingOrder = 4;
            filledPipe.sortingOrder = 5;
            BackGRoundSpirte.sortingOrder = 3;
        }
       
    }
    void OnMouseUp()
    {
        if (!GameManager.Instance.canPlay) return;
        collider2d.enabled = false;

      
        RaycastHit2D hitInfoPipe = Physics2D.Raycast(MouseWorldPosition(), Vector2.zero, Mathf.Infinity, pipeLayer);

        if (hitInfoPipe.collider != null)
        {
          
            Vector3 otherPipeLastPos = hitInfoPipe.transform.position;
            hitInfoPipe.transform.position = lastpos;
            transform.position = otherPipeLastPos;
        }
        else
        {
            
            RaycastHit2D hitInfoPlacingLayer = Physics2D.Raycast(MouseWorldPosition(), Vector2.zero, Mathf.Infinity, placinglayer);

            if (hitInfoPlacingLayer.collider != null && hitInfoPlacingLayer.collider.tag == destinationTag)
            {
                Transform destinationTransform = hitInfoPlacingLayer.transform;

               
                transform.position = destinationTransform.position + new Vector3(0, 0, -0.01f);

            }
            else
            {
               
                transform.position = lastpos;
            }
        }

        collider2d.enabled = true;
        isPlaced = true;
        IncreaseSortingLayers(false);
        // pipelinePiece.CheckConnections(); //  bug, so it remains commented out
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}