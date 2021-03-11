using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGAnim : MonoBehaviour
{
        
    public Material[] BGs;
    int rand, rand2;
    float speed;

    private void Start()
    {
        rand = Random.Range(0, BGs.Length);
        //rand2 = Random.Range(0, BGs.Length - 1);
        RenderSettings.skybox = BGs[rand];
        //StartCoroutine("ChengeInt");
    }

    /*private void Update()
    {
        speed = Time.deltaTime / 10;
        RenderSettings.skybox.Lerp(BGs[rand], BGs[rand2], speed);
    }

    IEnumerator ChengeInt()
    {
        while (true)
        {
            Debug.Log(rand + "  " + rand2);
        yield return new WaitForSeconds(30f);
            RenderSettings.skybox = BGs[rand2];
            speed = 0;
            rand = rand2;
            rand2 = Random.Range(0, BGs.Length - 1);
        }
    }
    private void ChengeMat()
    {
    }*/
}
