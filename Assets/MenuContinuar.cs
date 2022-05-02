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
        Debug.Log("ENTRAMOS NO BOT�O SIM");
        foreach(var n in CriarBlocos.pe�aList)
        {
            Debug.Log("DESTR�I PE�A");
            Destroy(n);
        }
        foreach (var n in CriarBlocos.respList)
        {
            Debug.Log("DESTR�I Resposta");
            Destroy(n);
        }
        Debug.Log("Sa�mos dos loops");
        //limpa os objetos atuais das listas
        CriarBlocos.respList.Clear();
        CriarBlocos.pe�aList.Clear();
        Debug.Log("Limpado as listas");

        menuContinuar.SetActive(false);
        Debug.Log("MENU, PORQUE VOC� NAO MORREU??????");
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
