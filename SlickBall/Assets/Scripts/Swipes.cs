using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Swipes : MonoBehaviour
{
    private SpawnSticks script;

    private Vector2 startPos;
    private Vector2 endPos;

    public bool destrDownStick = false;
    //public bool destrUpStick = false;
    public bool destroyed = false;

    public StickCol stickCol;
    private void Start()
    {
        script = GameObject.Find("player").GetComponent<SpawnSticks>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    endPos = touch.position;
                    Vector2 direction = endPos - startPos;
                    if (direction.x < 30 && direction.x > -30 && direction.y < 30 && direction.y > -30)
                    {
                        //Debug.Log(direction);
                    }
                    else
                    {
                        Swipe();
                    }
                    break;
            }
        }
    }
    private void Swipe()
    {
        Vector2 swipe = startPos - endPos;
        string dir = GetDragDirection(swipe);
        switch (dir)
        {
            case "Up":
                script.StickUp(destroyed);
                destrDownStick = false;
                break;
            case "Down":
                if (!destrDownStick)
                {
                script.StickDown(destroyed);
                }
                break;
            case "Right":
                if (!destrDownStick)
                {
                script.StickForward(destroyed);
                }
                break;
        }
    }
    private string GetDragDirection(Vector2 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        string draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? draggedDir = "Left" : draggedDir = "Right";
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? draggedDir = "Down" : draggedDir = "Up";
        }
        return draggedDir;
    }
    //Доделать
    private bool CanOrNot(bool destr)
    {
        bool can = false;
        if (!destr)
        {
            can = true;
        }
        return can;
    }
}


