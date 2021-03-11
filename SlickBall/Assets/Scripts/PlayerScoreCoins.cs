using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCoins : MonoBehaviour
{

    public GameObject gameMan;
    private Rigidbody rb;
    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       currentVelocity = rb.velocity;
        if (currentVelocity.y <= 0f)
            return;

        currentVelocity.y = 0f;

        rb.velocity = currentVelocity;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "coin"){
            GameObject.Find("score").GetComponent<ScoreScript>().scoreInt += 1;
            Destroy(other.gameObject);
        }
    }
    private  void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "enemy" || other.collider.tag == "roof"){
            gameMan.GetComponent<GameManager>().GameOver();
        }
    }
}
