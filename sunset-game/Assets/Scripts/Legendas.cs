using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Legendas : MonoBehaviour
{

    public string[] textoLegenda;
    public TextMeshProUGUI textLegenda;
    public GameObject legenda;
    // Start is called before the first frame update
    void Start()
    {
        textoLegenda[0] = "O que aconteceu aqui?";
        textoLegenda[1] = "Parece que bati em algo, mas... nao tinha nada na minha frente.";
        textoLegenda[3] = "Por que o sol está tão forte assim hoje ? Machuca os meus olhos.";
        textoLegenda[2] = "Preciso econtrar um jeito de sair daqui logo.";
        textoLegenda[4] = "Acho melhor pegar meu óculos de sol no porta luvas do carro.";

        StartCoroutine(LegendasIniciais());
    
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LegendasIniciais()
    {
        textLegenda.text = "";
        yield return new WaitForSeconds(3);
        textLegenda.text = textoLegenda[0];
        yield return new WaitForSeconds(4);
        textLegenda.text = textoLegenda[1];
        yield return new WaitForSeconds(4);
        textLegenda.text = textoLegenda[2];
        yield return new WaitForSeconds(4);
        textLegenda.text = "";
        yield return new WaitForSeconds(3);
        textLegenda.text = textoLegenda[3];
        yield return new WaitForSeconds(4);
        textLegenda.text = textoLegenda[4];
        yield return new WaitForSeconds(4);
        textLegenda.text = "";
    }
}
