using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinePiece : MonoBehaviour
{

    [System.Serializable]
    public class Point
    {
        public Transform pointTransform;
        public Vector2 rayDirection;
    }
    public bool hasWater=false;
    public List<Point> points = new List<Point>();
    public bool isConnected = false;
    public bool isEndPipe=false;
    public bool isStartPipe=false;
    public string connectableTag = "Pipe";
    public LayerMask layerMask; // Layer mask to filter raycast hits
    public GameObject waterFill;
    DraggableItem draggableItem;

   
    private void Start()
    {
        CheckConnections();
        if(!isEndPipe)
        draggableItem = GetComponent<DraggableItem>();
    }
    void Update()
    {
        if (!GameManager.Instance.canPlay) return;
        if (isStartPipe||isEndPipe || draggableItem.isPlaced)                                                                                                                                                               
        {
            CheckConnections();
        }
        else
        {
            isConnected = false;
            hasWater = false;
        }
            

        if (hasWater)
        {
            AddWaterConnectio(true);
        }
        else if(!hasWater)                         
        {
            AddWaterConnectio(false);
        }
      
    }
   public void ReliseWater()
    {
        hasWater = false;
    }
  void   AddWaterConnectio(bool val)
    {
        waterFill.SetActive(val);
    }
   public void CheckConnections()
    {
        isConnected = false;

        foreach (Point point in points)
        {
            // Cast a ray from the point in the specified direction with layer mask
            RaycastHit2D hit = Physics2D.Raycast(point.pointTransform.position, point.rayDirection, 0.3f, layerMask);

            // Debug ray to visualize in the scene view
            Debug.DrawRay(point.pointTransform.position, point.rayDirection * 0.3f, Color.red);

            // Check if the ray hit a collider with the specified tag
            if (hit.collider != null && hit.collider.CompareTag(connectableTag))
            {
                if(hit.collider.gameObject.GetComponentInParent<PipelinePiece>() != null)
                {
                    Debug.Log(hit.collider.gameObject.GetComponentInParent<PipelinePiece>().hasWater);

                    if (hit.collider.gameObject.GetComponentInParent<PipelinePiece>().hasWater) {
                        hasWater = true;

                    }
                    else
                    {
                        hasWater = false;


                    }

                }
                isConnected = true;
                break;
            }
            else
            {
                hasWater = false;


            }
        }
    }
}
