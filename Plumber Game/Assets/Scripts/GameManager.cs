using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool pause=false;
    public bool canPlay = true;
    public GameObject pausePannel;
    public GameObject losePannel;
    public GameObject winPannel;
    public static GameManager Instance;

  //  Result resultScript;
    // public int firstStarScore;
    // public int secondStarScore;


    /* public void Resukts(int val)
     {
         if (val >= secondStarScore)
         {
             resultScript.StarShow(3);         
         }
         else if (val <= firstStarScore)
         {
             resultScript.StarShow(2);
             //2
         }
         else
         {
             resultScript.StarShow(1);
         }
     }*/
    private void Start()
    {
       // resultScript = WinPannel.GetComponent<Result>();
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Pause()
    {
        pause=!pause;
        if (pause)
        {
            pausePannel.SetActive(true);
        }
        else
        {
            pausePannel.SetActive(false);                                                                                                  
        }
    }
  
    public void GameOver()
    {
        canPlay=false;
        losePannel.SetActive(true);
    }
    public void GameComplited()
    {
        canPlay=false;
       winPannel.SetActive(true );
      // Resukts(TimeLeft);  
    }
}
