using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMMenu : MonoBehaviour
{
    public Text mainScore;

    public GameObject shopPanel;
    public GameObject allCircles;
    public GameObject scrollObj;
    private void Start()
    {
        if (mainScore)
        {
            mainScore.text = PlayerPrefs.GetInt("Score", 0).ToString();
        }
    }

    public void TapToStart()
    {
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }
    public void Shop()
    {
        allCircles.SetActive(true);
        shopPanel.SetActive(true);
        scrollObj.SetActive(true);
    }
    public void CloseShop()
    {
        allCircles.SetActive(false);
        shopPanel.SetActive(false);
        scrollObj.SetActive(false);
    }
}
