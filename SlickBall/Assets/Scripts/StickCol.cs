using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickCol : MonoBehaviour
{
    private SpawnSticks player;
    private Swipes swipeScript;
    private Button forwardBtn;
    private Button downBtn;
    public AudioClip crash;
    private AudioSource audioS;
    private Camera mainCam;

    private void Start() {
        player = GameObject.Find("player").GetComponent<SpawnSticks>();
        swipeScript = GameObject.Find("spawner").GetComponent<Swipes>();
        //forwardBtn = GameObject.Find("ButtonForward").GetComponent<Button>();
        //downBtn = GameObject.Find("ButtonDown").GetComponent<Button>();
        audioS = GameObject.Find("audio").GetComponent<AudioSource>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "enemy"){
            audioS.PlayOneShot(crash);
            Debug.Log("Destroyed");
            Destroy(gameObject);
            swipeScript.destroyed = true;
        }
        /*else if(other.collider.tag == "roof")
        {
            if (gameObject.name == "stickUp(Clone)")
            {
                audioS.PlayOneShot(crash);
                //Destroy(gameObject);
                //swipeScript.destrUpStick = true;
            }
        }*/
        else if(other.collider.tag == "floor"){
            if(gameObject.name == "stickDown(Clone)"){
                Debug.Log("1");
                swipeScript.destrDownStick = true;
            }
        }
    }
    private void Update()
    {
        Vector3 point = mainCam.WorldToViewportPoint(transform.position);
        if(point.x < -0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
