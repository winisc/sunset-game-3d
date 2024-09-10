using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    public GameObject textInteragir;
    public GameObject[] textBau;

    private TrocaDeItens trocaDeItens;
    public bool podePegarOculos;
    public bool podePegarLanterna;
    public bool podePegarAmuleto;
    public bool podePegarChave;
    public bool podePegarBau;

    public bool abriuBau;

    public bool podeEntrarPorao;
    public bool podeSairPorao;

    public bool taDentroDoPorao;

    public GameObject fade;
    public Animator fadeAnim;

    public bool podeAbrirCarta;
    public GameObject carta;
    public bool cartaAberta;

    public GameObject chaveModelDrop;

    public GameObject lanternaModelDrop;
    public GameObject[] amuletoModelDrop;

    public bool fecharBau;

    private SolPosition solPosition;

    public GameObject luzPorao;

    [Header("Audio")]

    public AudioSource[] efeitoSonoro;

    public bool[] tocarEfeitoSonoro;
    // Start is called before the first frame update
    void Start()
    {
        solPosition = FindObjectOfType<SolPosition>();
        trocaDeItens = FindObjectOfType<TrocaDeItens>();
        textInteragir.SetActive(false);

        textBau[0].SetActive(false);
        textBau[1].SetActive(false);

        taDentroDoPorao = false;
        podeSairPorao = false;
        
        podeAbrirCarta = false;
        podePegarBau = false;

        fade.SetActive(false);
        carta.SetActive(false);

        lanternaModelDrop.SetActive(true);

        amuletoModelDrop[0].SetActive(true);
        amuletoModelDrop[1].SetActive(false); 
        amuletoModelDrop[2].SetActive(false);

        abriuBau = false;
        fecharBau = false;

        luzPorao.SetActive(false);

        tocarEfeitoSonoro[0] = false;
        tocarEfeitoSonoro[1] = false;
        tocarEfeitoSonoro[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        AdquirirItem();
        EntrarPorao();
        AbrirCarta();
        VerificarBau();
        AberturaDePorao();
    }

    private void AberturaDePorao()
    {
        if(solPosition.timer >= 2.0f && !tocarEfeitoSonoro[1])
        {
            efeitoSonoro[1].Play();
            tocarEfeitoSonoro[1] = true;
        }

        if(solPosition.timer >= 2.2f && !tocarEfeitoSonoro[2])
        {
            efeitoSonoro[2].Play();
            luzPorao.SetActive(true);
            tocarEfeitoSonoro[2] = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Car") && !trocaDeItens.possuiItem[1])
        {
            textInteragir.SetActive(true);
            podePegarOculos = true;
        }

        if(collision.CompareTag("Porao"))
        {
            if(solPosition.timer >= 2.2f)
            {
                textInteragir.SetActive(true);
                podeEntrarPorao = true;
            }
        }

        if(collision.CompareTag("PoraoInt"))
        {
            textInteragir.SetActive(true);
            podeSairPorao = true;
        }

        if(collision.CompareTag("Carta") && !cartaAberta)
        {
            textInteragir.SetActive(true);
            podeAbrirCarta = true;
        }

        if(collision.CompareTag("Lanterna") && !trocaDeItens.possuiItem[0])
        {
            textInteragir.SetActive(true);
            podePegarLanterna = true;
        }

        if(collision.CompareTag("Amuleto"))
        {
            textInteragir.SetActive(true);
            podePegarAmuleto = true;
        }

        if(collision.CompareTag("Chave") && !trocaDeItens.possuiItem[2])
        {
            textInteragir.SetActive(true);
            podePegarChave = true;
        }

        if(collision.CompareTag("Bau") && !abriuBau)
        {
            textBau[0].SetActive(true);
            podePegarBau = true;
            trocaDeItens.abrirBau = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Car"))
        {
            textInteragir.SetActive(false);
            podePegarOculos = false;
        }

        if(collision.CompareTag("Porao"))
        {
            textInteragir.SetActive(false);
            podeEntrarPorao = false;
        }

        if(collision.CompareTag("PoraoInt"))
        {
            textInteragir.SetActive(false);
            podeSairPorao = false;
        }

        if(collision.CompareTag("Carta"))
        {
            textInteragir.SetActive(false);
            podeAbrirCarta = false;
            carta.SetActive(false);
            cartaAberta = false;
        }

        if(collision.CompareTag("Lanterna"))
        {
            textInteragir.SetActive(false);
            podePegarLanterna = false;
        }

        if(collision.CompareTag("Amuleto"))
        {
            textInteragir.SetActive(false);
            podePegarAmuleto = false;
        }

        if(collision.CompareTag("Chave"))
        {
            textInteragir.SetActive(false);
            podePegarChave = false;
        }

        if(collision.CompareTag("Bau"))
        {
            textBau[0].SetActive(false);
            podePegarBau = false;
            trocaDeItens.abrirBau = false;
        }
    }

    private void VerificarBau()
    {
        if(trocaDeItens.bauFoiAberto && !fecharBau)
        {
            textBau[0].SetActive(false);
            textBau[1].SetActive(true);
            abriuBau = true;
            podePegarBau = false;
            trocaDeItens.abrirBau = false;

            trocaDeItens.possuiItem[2] = false;
            trocaDeItens.itemAtivo[2] = false;
            trocaDeItens.imageItemAtivo[2].enabled = false;
            trocaDeItens.itemModelo[2].SetActive(false);
            trocaDeItens.itemUI[2].SetActive(false);
            ItensBau();
            fecharBau = true;
        }
    }

    private void AdquirirItem()
    {
        if(Input.GetKey(KeyCode.E) && podePegarOculos && !trocaDeItens.possuiItem[1])
        {
            trocaDeItens.possuiItem[1] = true;
            trocaDeItens.pegouItem[1] = true;
            StartCoroutine(trocaDeItens.ItemAdicionadoText());
            textInteragir.SetActive(false);
            podePegarOculos = false;
        }

        if(Input.GetKey(KeyCode.E) && podePegarLanterna && !trocaDeItens.possuiItem[0])
        {
            trocaDeItens.possuiItem[0] = true;
            trocaDeItens.pegouItem[0] = true;
            StartCoroutine(trocaDeItens.ItemAdicionadoText());
            textInteragir.SetActive(false);
            podePegarLanterna = false;

            lanternaModelDrop.SetActive(false);
        }

        if(Input.GetKey(KeyCode.E) && podePegarChave && !trocaDeItens.possuiItem[2])
        {
            trocaDeItens.possuiItem[2] = true;
            trocaDeItens.pegouItem[2] = true;
            StartCoroutine(trocaDeItens.ItemAdicionadoText());
            textInteragir.SetActive(false);
            podePegarChave = false;

            chaveModelDrop.SetActive(false);
        }

        if(Input.GetKey(KeyCode.E) && podePegarAmuleto)
        {   
            trocaDeItens.pegouItem[3] = true;
            trocaDeItens.possuiItem[3] = true;
            StartCoroutine(trocaDeItens.AmuletoAdicionadoText());
            textInteragir.SetActive(false);
            trocaDeItens.countAmuleto ++;
            if(trocaDeItens.countAmuleto == 1) 
            {
                amuletoModelDrop[0].SetActive(false);
                amuletoModelDrop[1].SetActive(true);
            }
            else if(trocaDeItens.countAmuleto == 2)
            {
                amuletoModelDrop[1].SetActive(false);
                amuletoModelDrop[2].SetActive(true);
            }
            podePegarAmuleto = false;

            efeitoSonoro[0].Play();
        }
    }

    public void ItensBau()
    {
        trocaDeItens.pegouItem[3] = true;
        trocaDeItens.possuiItem[3] = true;
        StartCoroutine(trocaDeItens.AmuletoAdicionadoText());
        textInteragir.SetActive(false);
        trocaDeItens.countAmuleto ++;

        trocaDeItens.pegouBateria = true;
        StartCoroutine(trocaDeItens.BateriaAdicionadoText());
    }

    private void EntrarPorao()
    {
        if(Input.GetKey(KeyCode.E) && podeEntrarPorao && !taDentroDoPorao)
        {
            this.transform.position = new Vector3(158.7f, 2.6f,-59f);
            textInteragir.SetActive(false);
            StartCoroutine(DentroDoPorao());
            fade.gameObject.SetActive(true);
            fadeAnim.Play("fade");
        }
        else if(Input.GetKey(KeyCode.E) && podeSairPorao && taDentroDoPorao)
        {
            this.transform.position = new Vector3(25.1543f, 1.5817f,23.59711f);
            textInteragir.SetActive(false);
            StartCoroutine(ForaDoPorao());
            fade.gameObject.SetActive(true);
            fadeAnim.Play("fade");
        }
    }

    private IEnumerator DentroDoPorao()
    {
        //Adicionar sound
        fade.gameObject.SetActive(true);
        fadeAnim.Play("fade");
        yield return new WaitForSeconds(3.3f);
        taDentroDoPorao = true;
        fade.gameObject.SetActive(false);
    }

    private IEnumerator ForaDoPorao()
    {
        //Adicionar sound
        fade.gameObject.SetActive(true);
        fadeAnim.Play("fade");
        yield return new WaitForSeconds(3.3f);
        taDentroDoPorao = false;
        fade.gameObject.SetActive(false);
    }

    private void AbrirCarta()
    {
        if(Input.GetKey(KeyCode.E) && podeAbrirCarta)
        {
            carta.SetActive(true);
            cartaAberta = true;

            textInteragir.SetActive(false);
            podeAbrirCarta = false;

        }
        
        if(Input.GetKey(KeyCode.Escape) && cartaAberta)
        {
            carta.SetActive(false);
            cartaAberta = false;
            podeAbrirCarta = true;
        }
    }

}
