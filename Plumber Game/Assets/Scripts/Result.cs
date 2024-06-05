using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
   

    public GameObject[] stars;
    public void StarShow(int num)
    {
      for(int i=0;i<num;i++) 
        {
            stars[i].gameObject.SetActive(true);
        
        }                                                                     
    }
}
