using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnim : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(), 1f);
    }
}
