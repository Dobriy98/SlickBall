using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public float speed = 5;
    private RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update(){
        if(rect.offsetMin.y != 0){
            rect.offsetMin += new Vector2(rect.offsetMin.x, speed);
            rect.offsetMax += new Vector2(rect.offsetMax.x, speed);
        }
    }
}
