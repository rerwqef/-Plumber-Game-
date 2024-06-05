using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPipe : MonoBehaviour
{
    PipelinePiece piece;
    private void Start()
    {
        piece = GetComponent<PipelinePiece>();
    }

    private void Update()
    {
        if(!GameManager.Instance.canPlay)return;
        if (piece.hasWater)
        {
            //gameComplited
            Invoke("Complited", 0.6f);
        }
    }
    void Complited()
    {
        GameManager.Instance.GameComplited();
    }
}
