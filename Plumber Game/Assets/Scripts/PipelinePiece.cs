using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinePiece : MonoBehaviour
{
    public List<Transform> connectionPoints;

    void Awake()
    {
        // Initialize the list if it's not set in the Inspector
        if (connectionPoints == null)
            connectionPoints = new List<Transform>();
    }
}