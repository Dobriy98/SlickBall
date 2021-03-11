using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public GameObject floor;
    private Vector3 offset;  

    void Start () 
    {        
        offset = transform.position - floor.transform.position;
    }

    void LateUpdate () 
    {        
        transform.position = floor.transform.position + offset;
    }
}
