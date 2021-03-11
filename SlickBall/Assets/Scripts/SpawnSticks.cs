using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSticks : MonoBehaviour
{
    [SerializeField]
    private int intStick = 0;
    [SerializeField]
    private int lastStick = 0;

    //public bool destroyed = false;
    private bool firstStick = false;

    public GameObject stickUp;
    public GameObject stickForward;
    public GameObject stickDown;

    private GameObject upStick;
    private GameObject forwardStick;
    private GameObject downStick;
    [SerializeField]
    private bool onGround = false;
    //public bool destrDownStick = false;
    private bool checkPos = false;

    private GameObject lastPos;

    public StickCol stickCol;

    public bool paused = false;
    public AudioSource audioS;
    public AudioClip stickSpawnAudio;

    private Swipes swipeScript;

    private void Start()
    {
        intStick = 0;
        stickCol = GetComponent<StickCol>();
        swipeScript = GameObject.Find("spawner").GetComponent<Swipes>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "floor")
        {
            onGround = true;
            intStick = 0;
            Debug.Log("On Ground");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "floor")
        {
            onGround = false;
            //destrDownStick = false;
        }
    }
    public void StickUp(bool destroyed)
    {
        if(!paused){
            audioS.PlayOneShot(stickSpawnAudio);
        if (intStick == 0)
        {
                Vector3 FirstStick = new Vector3(gameObject.transform.position.x + 3.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                upStick = Instantiate(stickUp, FirstStick, Quaternion.Euler(0, 0, 45));
                lastPos = upStick;
                firstStick = true;
                checkPos = false;
            }
            LastStick(destroyed);
            if (intStick == 1)
        {
            lastStick = 1;
                Vector3 pos = lastPos.transform.position + new Vector3(2.83f, 2.83f, 0);
                if (!DestroyStick(pos))
                {
                    upStick = Instantiate(stickUp, pos, Quaternion.Euler(0, 0, 45));
                    checkPos = false;
                }
            }

        if (intStick == 2)
        {
            lastStick = 2;
                Vector3 pos = lastPos.transform.position + new Vector3(3.35f, 1.38f, 0);
                if (!DestroyStick(pos))
                {
                    upStick = Instantiate(stickUp, pos, Quaternion.Euler(0, 0, 45));
                    checkPos = false;
                }
            }

        if (intStick == 3)
        {
            lastStick = 3;
                Vector3 pos = lastPos.transform.position + new Vector3(2.7f, 0, 0);
                if (!DestroyStick(pos))
                {
                    upStick = Instantiate(stickUp, pos, Quaternion.Euler(0, 0, 45));
                    checkPos = false;
                }
            }
            if (!checkPos)
            {
                intStick = 1;
            }
        firstStick = false;
        }
    }
    public void StickForward(bool destroyed)
    {
        if(!paused){
            if (!onGround)
            {
            audioS.PlayOneShot(stickSpawnAudio);
            LastStick(destroyed);
        if (intStick == 1)
        {
            lastStick = 1;
                    Vector3 pos = lastPos.transform.position + new Vector3(3.35f, 1.38f, 0);
                    if (!DestroyStick(pos))
                    {
                        forwardStick = Instantiate(stickForward, pos, Quaternion.Euler(0, 0, 0));
                        checkPos = false;
                    }
                }
        if (intStick == 2)
        {
            lastStick = 2;
                    Vector3 pos = lastPos.transform.position + new Vector3(4, 0, 0);
                    if (!DestroyStick(pos))
                    {
                        forwardStick = Instantiate(stickForward, pos, Quaternion.Euler(0, 0, 0));
                        checkPos = false;
                    }
        }
        if (intStick == 3)
        {
            lastStick = 3;
                    Vector3 pos = lastPos.transform.position + new Vector3(3.35f, -1.38f, 0);
                    if (!DestroyStick(pos))
                    {
                        forwardStick = Instantiate(stickForward, pos, Quaternion.Euler(0, 0, 0));
                        checkPos = false;
                    }
        }
                if (!checkPos)
                {
                    intStick = 2;
                }
            }
        }
    }
    public void StickDown(bool destroyed)
    {
        if(!paused){
            if (!onGround)
            {
            audioS.PlayOneShot(stickSpawnAudio);
            LastStick(destroyed);
            if (intStick == 1)
        {
            lastStick = 1;
                    Vector3 pos = lastPos.transform.position + new Vector3(2.7f, 0, 0);
                    if (!DestroyStick(pos))
                    {
                        downStick = Instantiate(stickDown, pos, Quaternion.Euler(0, 0, -45));
                        checkPos = false;
                    }
        }
        if (intStick == 2)
        {
            lastStick = 2;
                    Vector3 pos = lastPos.transform.position + new Vector3(3.35f, -1.38f, 0);
                    if (!DestroyStick(pos))
                    {
                        downStick = Instantiate(stickDown, pos, Quaternion.Euler(0, 0, -45));
                        checkPos = false;
                    }
                }
        if (intStick == 3)
        {
            lastStick = 3;
                    Vector3 pos = lastPos.transform.position + new Vector3(2.83f, -2.83f, 0);
                    if (!DestroyStick(pos))
                    {
                        downStick = Instantiate(stickDown, pos, Quaternion.Euler(0, 0, -45));
                        checkPos = false;
                    }
        }
                if (!checkPos)
                {
                    intStick = 3;
                }
            }
        }
    }

    public void LastStick(bool destroyed)
    {
        if (!firstStick)
        {
            if (destroyed)
            {
                intStick = lastStick;
                swipeScript.destroyed = false;
            }
            else
            {
        GameObject[] lastPosArr = GameObject.FindGameObjectsWithTag("stick");
        lastPos = lastPosArr[lastPosArr.Length - 1];
            }
        }
    }

    private bool DestroyStick(Vector3 stickPos)
    {
        bool check = false;
        if(stickPos.y <= -6.3f || stickPos.y >= 6.6f)
        {
            check = true;
            checkPos = true;
        }
        return check;
    }
}
