using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float score = 0;
    public float timer;
    private float waitTimer = 15f;
    private float startSpeed;
    private float gameSpeed;
    public Text scoreText;
    public int scoreInt = 0;
    private SpawnEnemy spawner;
    public GameObject player;

    private GameObject spawnerObj;
    private GameObject floor;
    private GameObject roof;

    public GameObject speedUp;
    public bool paused = false;

    public int count;


    private void Start()
    {
        startSpeed = 0.05f;
        gameSpeed = 0.012f;
        Debug.Log("Start");
        player.GetComponent<MoveObj>().speed = startSpeed;
        spawnerObj = GameObject.Find("spawner");
        spawnerObj.GetComponent<MoveObj>().speed = startSpeed;
        floor = GameObject.Find("floor");
        floor.GetComponent<MoveObj>().speed = startSpeed;
        roof = GameObject.Find("roof");
        roof.GetComponent<MoveObj>().speed = startSpeed;
        spawner = GameObject.Find("spawner").GetComponent<SpawnEnemy>();
        spawner.waitTime = 5f;
        timer = 0;
        count = 0;
    }
    void Update()
    {
        if (!paused)
        {
            score += Time.deltaTime;
            timer += Time.deltaTime;
            scoreText.text = scoreInt.ToString();
            if (count < 7)
            {
                if (timer > waitTimer)
                {
                    StartCoroutine(SpeedUp());
                    count += 1;
                    //Debug.Log(count);
                    timer = timer - waitTimer;
                    PlusSpeed(gameSpeed);

                    if(spawner.waitTime > 1.5f)
                    {
                        //Debug.Log(spawner.waitTime);
                    spawner.waitTime -= 0.5f;
                    }
                }
            }
        }
    }

    private void PlusSpeed(float speed)
    {
        player.GetComponent<MoveObj>().speed += speed;
        spawner.GetComponent<MoveObj>().speed += speed;
        floor.GetComponent<MoveObj>().speed += speed;
        roof.GetComponent<MoveObj>().speed += speed;
    }
    IEnumerator SpeedUp()
    {
        speedUp.SetActive(true);
        yield return new WaitForSeconds(2f);
        speedUp.SetActive(false);
    }
}
