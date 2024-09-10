using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrocaDeItens : MonoBehaviour
{

    [Header("Oculos")]

    public Animator animOculos;
    public Image efeitoOculosEscuro;

    [Header("Bateria")]
    public float timerBateria = 30;
    public GameObject bateriaLanternaUI;
    public Image[] nivelBateriaUI;
    public int nivelBateria;

    [Header("Itens")]
    public GameObject hudItens;
    public GameObject[] itemUI;
    public bool[] possuiItem;
    public bool[] itemAtivo;
    public Image[] imageItemAtivo;
    public GameObject[] itemModelo;
    public GameObject[] usarItem;
    public bool[] efeitoDoItem;

    public GameObject[] textAdicinouItem;
    public bool[] pegouItem;

    public bool pegouBateria;

    public GameObject bateria9v;

    [Header("Amuleto")]
    public GameObject hudAmuletos;
    public Image[] amuletoCount;
    public bool abrirBau;
    public int countAmuleto;
    public bool bauFoiAberto;


    private DamagedEnemy damagedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        damagedEnemy = FindObjectOfType<DamagedEnemy>();

        abrirBau = false;
        bauFoiAberto = false;

        possuiItem[0] = false;
        possuiItem[1] = false;
        possuiItem[2] = false;

        hudItens.SetActive(false);
        itemUI[0].SetActive(false);
        itemUI[1].SetActive(false);
        itemUI[2].SetActive(false);

        itemAtivo[0] = false;
        itemAtivo[1] = false;
        itemAtivo[2] = false;

        imageItemAtivo[0].enabled = false;
        imageItemAtivo[1].enabled = false;
        imageItemAtivo[2].enabled = false;

        itemModelo[0].SetActive(false);
        itemModelo[1].SetActive(false);
        itemModelo[2].SetActive(false);

        usarItem[0].SetActive(false);
        usarItem[1].SetActive(false);
        usarItem[2].SetActive(false);

        efeitoDoItem[0] = false;
        efeitoDoItem[1] = false;
        efeitoDoItem[2] = false;

        bateriaLanternaUI.SetActive(false);

        timerBateria = 30;

        pegouItem[0] = false;
        pegouItem[1] = false;
        pegouItem[2] = false;
        pegouItem[3] = false;

        hudAmuletos.SetActive(false);

        countAmuleto = 0;

        pegouBateria = false;
        bateria9v.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TrocarItem();
        AtualizarUI();
        AtivarItem();
        BateriaLanterna();
        VerificarItensPossuidos();
    }

    private void VerificarItensPossuidos()
    {
        if(possuiItem[0])
        {
            hudItens.SetActive(true);
            itemUI[0].SetActive(true);
        }

        if(possuiItem[1])
        {
            hudItens.SetActive(true);
            itemUI[1].SetActive(true);
        }

        if(possuiItem[2])
        {
            hudItens.SetActive(true);
            itemUI[2].SetActive(true);
        }
    }
    private void TrocarItem()
    {
        if(Input.GetKey(KeyCode.Alpha1) && possuiItem[0] && !efeitoDoItem[1]) 
        {
            bateriaLanternaUI.SetActive(true);
            itemAtivo[0] = true;
            itemAtivo[1] = false;
            itemAtivo[2] = false;
            itemModelo[0].SetActive(true);
            itemModelo[1].SetActive(false);
            itemModelo[2].SetActive(false);
        }
        else if(Input.GetKey(KeyCode.Alpha1) && !possuiItem[0] && !efeitoDoItem[1]) 
        {
            bateriaLanternaUI.SetActive(false);
            imageItemAtivo[0].enabled = true;
            imageItemAtivo[1].enabled = false;
            imageItemAtivo[2].enabled = false;
            itemAtivo[0] = false;
            itemAtivo[1] = false;
            itemAtivo[2] = false;
            itemModelo[0].SetActive(false);
            itemModelo[1].SetActive(false);
            itemModelo[2].SetActive(false);
        }
        else if(Input.GetKey(KeyCode.Alpha2) && possuiItem[1] && !efeitoDoItem[0])
        {
            bateriaLanternaUI.SetActive(false);
            itemAtivo[0] = false;
            itemAtivo[1] = true;
            itemAtivo[2] = false;
            itemModelo[0].SetActive(false);
            itemModelo[1].SetActive(true);
            itemModelo[2].SetActive(false);
        }
        else if(Input.GetKey(KeyCode.Alpha2) && !possuiItem[1] && !efeitoDoItem[0])
        {
            bateriaLanternaUI.SetActive(false);
            imageItemAtivo[0].enabled = false;
            imageItemAtivo[1].enabled = true;
            imageItemAtivo[2].enabled = false;
            itemAtivo[0] = false;
            itemAtivo[1] = false;
            itemAtivo[2] = false;
            itemModelo[0].SetActive(false);
            itemModelo[1].SetActive(false);
            itemModelo[2].SetActive(false);
        }
        else if(Input.GetKey(KeyCode.Alpha3) && possuiItem[2] && !efeitoDoItem[0] && !efeitoDoItem[1])
        {
            bateriaLanternaUI.SetActive(false);
            itemAtivo[0] = false;
            itemAtivo[1] = false;
            itemAtivo[2] = true;
            itemModelo[0].SetActive(false);
            itemModelo[1].SetActive(false);
            itemModelo[2].SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Alpha3) && !possuiItem[2] && !efeitoDoItem[0] && !efeitoDoItem[1])
        {
            bateriaLanternaUI.SetActive(false);
            imageItemAtivo[0].enabled = false;
            imageItemAtivo[1].enabled = false;
            imageItemAtivo[2].enabled = true;
            itemAtivo[0] = false;
            itemAtivo[1] = false;
            itemAtivo[2] = false;
            itemModelo[0].SetActive(false);
            itemModelo[1].SetActive(false);
            itemModelo[2].SetActive(false);
        }
    }

    private void AtualizarUI()
    {
        if(itemAtivo[0])
        {
            imageItemAtivo[0].enabled = true;
            imageItemAtivo[1].enabled = false;
            imageItemAtivo[2].enabled = false;

            if(pegouBateria)
            {
                bateria9v.SetActive(true);
            }
            else
            {
                bateria9v.SetActive(false);
            }
        }
        else if(itemAtivo[1])
        {
            imageItemAtivo[0].enabled = false;
            imageItemAtivo[1].enabled = true;
            imageItemAtivo[2].enabled = false;

            bateria9v.SetActive(false);
        }
        else if(itemAtivo[2])
        {
            imageItemAtivo[0].enabled = false;
            imageItemAtivo[1].enabled = false;
            imageItemAtivo[2].enabled = true;

            bateria9v.SetActive(false);
        }
        
        if(possuiItem[3])
        {
            hudAmuletos.SetActive(true);
            if(countAmuleto == 1)
            {
                amuletoCount[0].color = new Color(0, 1, 0);
            }
            else if(countAmuleto == 2)
            {
                amuletoCount[1].color = new Color(0, 1, 0);
            }
            else if(countAmuleto == 3)
            {
                amuletoCount[2].color = new Color(0, 1, 0);
            }
        }
    }

    private void AtivarItem()
    {
        if(itemAtivo[0]) //Lanterna
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(!efeitoDoItem[0])
                {
                    if(timerBateria > 0)
                    {
                        usarItem[0].SetActive(true);
                        efeitoDoItem[0] = true;
                    }
                }
                else
                {
                    damagedEnemy.dentro = false;
                    usarItem[0].SetActive(false);
                    efeitoDoItem[0] = false;
                }
            }

            if(pegouBateria)
            {
                if(Input.GetKey(KeyCode.G))
                {
                    if(timerBateria < 30)
                    {
                        timerBateria = 30;
                        pegouBateria = false;
                        bateria9v.SetActive(false);
                    }
                }
            }
        }

        if(itemAtivo[1]) //Oculos
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(!efeitoDoItem[1])
                {
                    usarItem[1].SetActive(true);
                    efeitoDoItem[1] = true;
                    animOculos.SetBool("ativou", true);
                    animOculos.SetBool("desativou", false);
                    StartCoroutine (UsarOculosEscuro());
                }
                else
                {
                    usarItem[1].SetActive(false);
                    efeitoDoItem[1] = false;
                    animOculos.SetBool("ativou", false);
                    animOculos.SetBool("desativou", true);
                    efeitoOculosEscuro.enabled = false;
                }
            }
        }

        if(itemAtivo[2]) //Chave
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(abrirBau)
                {
                    bauFoiAberto = true;
                }
            }
        }
    }

    IEnumerator UsarOculosEscuro()
    {
        yield return new WaitForSeconds(.6f);
        efeitoOculosEscuro.enabled = true;
    }

    private void BateriaLanterna()
    {
        if(itemAtivo[0])
        {
            if(efeitoDoItem[0])
            {
                timerBateria -= Time.deltaTime;
            }

            if(timerBateria > 20)
            {
                nivelBateria = 3;
                nivelBateriaUI[0].enabled = true;
                nivelBateriaUI[1].enabled = true;
                nivelBateriaUI[2].enabled = true;

                nivelBateriaUI[0].color = new Color(0,1,0);
                nivelBateriaUI[1].color = new Color(0,1,0);
                nivelBateriaUI[2].color = new Color(0,1,0);
            }
            else if(timerBateria <= 20 && timerBateria > 10)
            {
                nivelBateria = 2;
                nivelBateriaUI[0].enabled = true;
                nivelBateriaUI[1].enabled = true;
                nivelBateriaUI[2].enabled = false;

                nivelBateriaUI[0].color = new Color(1, 1, 0);
                nivelBateriaUI[1].color = new Color(1, 1, 0);
            }
            else if(timerBateria <= 10 && timerBateria > 4)
            {
                nivelBateria = 1;
                nivelBateriaUI[0].enabled = true;
                nivelBateriaUI[1].enabled = false;
                nivelBateriaUI[2].enabled = false;

                 nivelBateriaUI[0].color = new Color(1, 0, 0);
            }
            else if(timerBateria <= 3 && timerBateria > 2 && efeitoDoItem[0])
            {
                StartCoroutine(PiscarLanterna());
            }
            else if(timerBateria <= 0)
            {
                nivelBateria = 0;
                timerBateria = 0;
                nivelBateriaUI[0].enabled = false;
                nivelBateriaUI[1].enabled = false;
                nivelBateriaUI[2].enabled = false;
                efeitoDoItem[0] = false;
                usarItem[0].SetActive(false);
            }
        }

        if(nivelBateria == 0)
        {
            nivelBateriaUI[0].enabled = false;
            nivelBateriaUI[1].enabled = false;
            nivelBateriaUI[2].enabled = false;
            efeitoDoItem[0] = false;
            usarItem[0].SetActive(false);
        }
    }

    IEnumerator PiscarLanterna()
    {   
        nivelBateriaUI[0].enabled = false;
        usarItem[0].SetActive(false);
        yield return new WaitForSeconds(1);
        usarItem[0].SetActive(true);
        nivelBateriaUI[0].enabled = true;
        yield return new WaitForSeconds(.5f);
        usarItem[0].SetActive(false);
        yield return new WaitForSeconds(.2f);
        nivelBateriaUI[0].enabled = true;
    }


    public IEnumerator ItemAdicionadoText()
    {

        if(pegouItem[0])
        {
            textAdicinouItem[0].SetActive(true);
            yield return new WaitForSeconds(6);
            textAdicinouItem[0].SetActive(false);
            pegouItem[0] = false;
        }

        if(pegouItem[1])
        {
            textAdicinouItem[1].SetActive(true);
            yield return new WaitForSeconds(6);
            textAdicinouItem[1].SetActive(false);
            pegouItem[1] = false;
        }

        if(pegouItem[2])
        {
            textAdicinouItem[2].SetActive(true);
            yield return new WaitForSeconds(6);
            textAdicinouItem[2].SetActive(false);
            pegouItem[2] = false;
        }

    }

    public IEnumerator AmuletoAdicionadoText()
    {
        if(pegouItem[3])
        {
            textAdicinouItem[3].SetActive(true);
            yield return new WaitForSeconds(6);
            textAdicinouItem[3].SetActive(false);
            pegouItem[3] = false;
        }
    }

    public IEnumerator BateriaAdicionadoText()
    {
        if(pegouBateria)
        {
            textAdicinouItem[4].SetActive(true);
            yield return new WaitForSeconds(6);
            textAdicinouItem[4].SetActive(false);
        }
    }
}
