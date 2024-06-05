using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject levelsPannel;
    public  void ShowLevelPannel()
    {
        levelsPannel.SetActive(true);
    }
   public void CloseLevelPannel()
    {
        levelsPannel.SetActive(false);
    }
    public void StartGame(int index)
    {
        SceneManager.LoadScene(index);
    }
}
