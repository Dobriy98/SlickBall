using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdeptGame : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        if(Screen.width < 2436 && Screen.width > 1135){
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,4,-17);
        } else if(Screen.width <= 1135){
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,4,-18);
        }
    }
}
