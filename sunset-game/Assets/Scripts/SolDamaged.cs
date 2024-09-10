using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolDamaged : MonoBehaviour
{
    SolPosition solPosition;
    public float damaged;

    public bool oculosOn;

    public GameObject[] baixaVisao;
    public bool[] visaoDanificada;
    public bool[] startLegenda;

    public TrocaDeItens trocaDeItens;

    private Legendas legendas;
    // Start is called before the first frame update
    void Start()
    {
        solPosition = FindObjectOfType<SolPosition>();
        trocaDeItens = FindObjectOfType<TrocaDeItens>();
        legendas = FindObjectOfType<Legendas>();
        damaged = 0;
        oculosOn = false;

        baixaVisao[0].SetActive(false);
        baixaVisao[1].SetActive(false);

        visaoDanificada[0] = false;
        visaoDanificada[1] = false;

        startLegenda[0] = false;
        startLegenda[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        OculosControll();
        ControleDeDano();
    }

    private void ControleDeDano()
    {
        if((solPosition.timer >= 0.76f && solPosition.timer <= 2.2f) && !oculosOn )
        {
            damaged += Time.deltaTime;
            if(damaged >= 12 && damaged < 24)
            {
                visaoDanificada[0] = true;
                baixaVisao[0].SetActive(true);

                if(visaoDanificada[0] && !startLegenda[0])
                {
                    StartCoroutine(LegendasDamagedSol1());
                    visaoDanificada[0] = false;
                    startLegenda[0] = true;
                }
            }
            else if(damaged >= 24)
            {
                visaoDanificada[1] = true;
                damaged = 24;
                baixaVisao[0].SetActive(false);
                baixaVisao[1].SetActive(true);

                if(visaoDanificada[0] && !startLegenda[1])
                {
                    StartCoroutine(LegendasDamagedSol2());
                    visaoDanificada[1] = false;
                    startLegenda[1] = true;
                }
            }
        }
    }

    private IEnumerator LegendasDamagedSol1()
    {                
        legendas.textLegenda.text = "Meus olhos doeem!";
        yield return new WaitForSeconds(1.5f);
        legendas.textLegenda.text = "";
    }

    private IEnumerator LegendasDamagedSol2()
    {                
        legendas.textLegenda.text = "Meu deus, não consigo enxergar nada. Que dor!!";
        yield return new WaitForSeconds(3);
        legendas.textLegenda.text = "";
    }

    private void OculosControll()
    {
        if(trocaDeItens.efeitoDoItem[1])
        {
            oculosOn = true;
            damaged = 0;
        }
        else if(!trocaDeItens.efeitoDoItem[1])
        {
            oculosOn = false;
        }

    }
}
