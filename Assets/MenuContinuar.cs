using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuContinuar : MonoBehaviour
{
    public GameObject menuContinuar;
    public void Sim()
    {
        Time.timeScale = 1;
        //Destroi os objetos existentes
        Debug.Log("ENTRAMOS NO BOTÃO SIM");
        foreach(var n in CriarBlocos.peçaList)
        {
            Debug.Log("DESTRÓI PEÇA");
            Destroy(n);
        }
        foreach (var n in CriarBlocos.respList)
        {
            Debug.Log("DESTRÓI Resposta");
            Destroy(n);
        }
        Debug.Log("Saímos dos loops");
        //limpa os objetos atuais das listas
        CriarBlocos.respList.Clear();
        CriarBlocos.peçaList.Clear();
        Debug.Log("Limpado as listas");

        menuContinuar.SetActive(false);
        Debug.Log("MENU, PORQUE VOCÊ NAO MORREU??????");
        //reescolhe palavra chave
        ControladorJogo.Instance.EscolherPalavra();
        ControladorJogo.Instance.ContinuarJogo = true;
        //continuar jogo
        ControladorJogo.Instance.JogoPausado = false;
        Debug.Log("ACABAMOS O SIM");
    }


    public void Nao()
    {
        Time.timeScale = 1;
        ControladorJogo.Instance._continuarJogo = false;
        ControladorJogo.Instance.JogoPausado = false;
        menuContinuar.SetActive(false);
        //sair do jogo
    }
}
