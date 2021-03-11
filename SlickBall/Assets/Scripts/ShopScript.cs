using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopScript : MonoBehaviour
{
    public GameObject playerPref;
    public GameObject circles;
    public GameObject[] cirArr;
    public int saveInt;
    public Text scoreValue;
    public Button randCol;
    public GameObject resetValues;
    public GameObject defultMat;
    public AudioSource audioS;
    public AudioClip changeColorAudio;
    public AudioClip changeColorAudio2;

    private void Start()
    {
        if(Screen.width < 2436 && Screen.width > 1135){
            circles.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
            circles.transform.position = new Vector3(circles.transform.position.x, -0.4f, circles.transform.position.z);
        } else if(Screen.width <= 1135){
                        circles.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            circles.transform.position = new Vector3(circles.transform.position.x, -0.5f, circles.transform.position.z);
        }
        saveInt = PlayerPrefs.GetInt("OpenCir", 0);

        for (int i = 0; i <= saveInt; i++)
        {
            cirArr[i].SetActive(true);
        }
        if (PlayerPrefs.GetString("MatName") == "")
        {
            playerPref.GetComponent<MeshRenderer>().material = defultMat.GetComponent<MeshRenderer>().sharedMaterial;
        }
        else
        {
            GameObject.Find(PlayerPrefs.GetString("MatName")).transform.localScale += new Vector3(0.3f,0.3f,0.3f);
            playerPref.GetComponent<MeshRenderer>().material = GameObject.Find(PlayerPrefs.GetString("MatName")).GetComponent<MeshRenderer>().sharedMaterial;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.gameObject.tag == "circles")
                {
                    audioS.PlayOneShot(changeColorAudio);
                    if (PlayerPrefs.GetString("MatName") != ""){
                        GameObject.Find(PlayerPrefs.GetString("MatName")).transform.localScale -= new Vector3(0.3f,0.3f,0.3f);
                    }
                    PlayerPrefs.SetString("MatName", hit.collider.name);
                    ChangeMat(hit.collider.name);
                }
            }
        }

    }

    void ChangeMat(string name)
    {
        GameObject.Find(PlayerPrefs.GetString("MatName")).transform.localScale += new Vector3(0.3f,0.3f,0.3f);
        playerPref.GetComponent<MeshRenderer>().material = GameObject.Find(name).GetComponent<MeshRenderer>().sharedMaterial;
    }

    public void RandomColor()
    {
        if(cirArr[9].activeSelf){
            resetValues.SetActive(true);
            randCol.interactable = false;
            Debug.Log("Collection is full");
        } else {
        if(PlayerPrefs.GetInt("Score") >= 100){
                audioS.PlayOneShot(changeColorAudio2);
                PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score", 0) - 100);
        scoreValue.text = PlayerPrefs.GetInt("Score").ToString();

        PlayerPrefs.SetInt("OpenCir", PlayerPrefs.GetInt("OpenCir") + 1);
        saveInt = PlayerPrefs.GetInt("OpenCir", 0);
        GameObject visibleCir = cirArr[saveInt];
        visibleCir.SetActive(true);
        visibleCir.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", Random.ColorHSV());
        }
        }
    }

    public void ResetCollection(){
        for (int i = 1; i < cirArr.Length; i++)
        {
            cirArr[i].SetActive(false);
        }
        playerPref.GetComponent<MeshRenderer>().material = defultMat.GetComponent<MeshRenderer>().sharedMaterial;
        resetValues.SetActive(false);
        randCol.interactable = true;
        PlayerPrefs.SetInt("OpenCir",0);
        PlayerPrefs.SetString("MatName", "");
    }
}
