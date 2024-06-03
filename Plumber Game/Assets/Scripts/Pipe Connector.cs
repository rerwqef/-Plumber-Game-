using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnector : MonoBehaviour
{
    public string connectedTag;
    public string disconnectedTag;
    public GameObject pipeFilledSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(connectedTag))
        {
            gameObject.tag = connectedTag;
            pipeFilledSprite.SetActive(true);
        }
        else if (other.CompareTag(disconnectedTag))
        {
            gameObject.tag = disconnectedTag;
            pipeFilledSprite.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(connectedTag))
        {
            gameObject.tag = connectedTag;
            pipeFilledSprite.SetActive(true);
        }
        else if (other.CompareTag(disconnectedTag))
        {
            gameObject.tag = disconnectedTag;
            pipeFilledSprite.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.tag = disconnectedTag;
        pipeFilledSprite.SetActive(false);
    }
}