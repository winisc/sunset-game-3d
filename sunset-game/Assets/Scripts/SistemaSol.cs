using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSol : MonoBehaviour
{
    public Light lightSol;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        lightSol = GetComponent<Light>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PassarOTempo();
    }

    private void PassarOTempo()
    {
        if(gameManager.startarDia)
        {
            lightSol.intensity -= 0.01386f*Time.deltaTime;
        }
    }
}
