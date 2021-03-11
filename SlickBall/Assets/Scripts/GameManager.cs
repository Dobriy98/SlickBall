
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text highScore;
    public Text highScore1;

    public GameObject tapToPlay;
    public GameObject player;

    public GameObject spawner;
    public GameObject score;
    public GameObject pauseBtn;

    public Text scoreValue;

    public GameObject tapToStartPan;

    public GameObject gameOverPanel;
    public GameObject gamePausedPanel;

    public GameObject speedUp;

    public GameObject[] materials;


    private void Start() {
        //Ads GooglePlay
        Advertisement.Initialize("3393451", false);


        // Reset PlayerPrefs

        // PlayerPrefs.SetInt("OpenCir",0);
        // PlayerPrefs.SetString("MatName", "");
        //PlayerPrefs.SetInt("Score", 0);
        // PlayerPrefs.SetInt("AdCount",0);
        // PlayerPrefs.SetInt("HighScore", 0);

        if(highScore){
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScore1.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void GameStart(){
        Time.timeScale = 1;
        pauseBtn.SetActive(true);
        player.SetActive(true);
        tapToPlay.SetActive(false);
        score.SetActive(true);
        spawner.SetActive(true);

        if (PlayerPrefs.GetString("MatName") == "")
        {
            player.GetComponent<MeshRenderer>().material = materials[0].GetComponent<MeshRenderer>().sharedMaterial;
        }
        else
        {
        for (int i = 0; i < materials.Length; i++)
        {
            if (PlayerPrefs.GetString("MatName") == materials[i].name)
            {
                player.GetComponent<MeshRenderer>().material = materials[i].GetComponent<MeshRenderer>().sharedMaterial;
            }
        }
        }

    }

    public void GameOver(){
        Time.timeScale = 0;
        /*PlayerPrefs.SetInt("AdCount",PlayerPrefs.GetInt("AdCount",0)+1);
       if(PlayerPrefs.GetInt("AdCount") == 3){
            PlayerPrefs.SetInt("AdCount",0);
            Ads();
        }*/
        player.GetComponent<MoveObj>().enabled = false;

        GameObject.Find("spawner").GetComponent<MoveObj>().enabled = false;
        GameObject.Find("floor").GetComponent<MoveObj>().enabled = false;
        GameObject.Find("roof").GetComponent<MoveObj>().enabled = false;

        player.GetComponent<SpawnSticks>().paused = true;

        gameOverPanel.SetActive(true);
        score.SetActive(false);
        tapToPlay.SetActive(false);
        speedUp.SetActive(false);

        scoreValue.text = score.GetComponent<ScoreScript>().scoreText.text;
        pauseBtn.SetActive(false);
        int number = score.GetComponent<ScoreScript>().scoreInt;
        if(number > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", number);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        PlayerPrefs.SetInt("Score", number + PlayerPrefs.GetInt("Score", 0));
        Destroy(player);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void GamePause(){
        player.GetComponent<MoveObj>().enabled = false;

        GameObject.Find("spawner").GetComponent<MoveObj>().enabled = false;
        GameObject.Find("floor").GetComponent<MoveObj>().enabled = false;
        GameObject.Find("roof").GetComponent<MoveObj>().enabled = false;

        player.GetComponent<SpawnSticks>().paused = true;
        spawner.GetComponent<Swipes>().enabled = false;
        pauseBtn.SetActive(false);
        gamePausedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameResume(){
        player.GetComponent<MoveObj>().enabled = true;

        GameObject.Find("spawner").GetComponent<MoveObj>().enabled = true;
        GameObject.Find("floor").GetComponent<MoveObj>().enabled = true;
        GameObject.Find("roof").GetComponent<MoveObj>().enabled = true;

        player.GetComponent<SpawnSticks>().paused = false;
        spawner.GetComponent<Swipes>().enabled = true;
        pauseBtn.SetActive(true);
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
    }

   public void Ads(){
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
   }
}
