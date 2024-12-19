using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject SaveScorePanel;
    public GameObject newScore;
    public void ReLoad()
    {
        SceneManager.LoadScene(1);   
    }
    public void Continue()
    {
        PlayerBackEvent.Trigger();
        newScore.SetActive(false);
        SaveScorePanel.SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
