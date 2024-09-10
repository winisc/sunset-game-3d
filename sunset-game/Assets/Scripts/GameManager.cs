using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool startarDia;
    public Animator animCamera;
    public GameObject cameraInicial;
    // Start is called before the first frame update
    void Start()
    {
        startarDia = true;
        player.SetActive(false);
        StartCoroutine(AtivarCamera());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AtivarCamera()
    {
        yield return new WaitForSeconds(3);
        animCamera.SetBool("ativarCamera", true);
        yield return new WaitForSeconds(5f);
        player.SetActive(true);
        yield return new WaitForSeconds(.2f);
        cameraInicial.SetActive(false);

    }
}
