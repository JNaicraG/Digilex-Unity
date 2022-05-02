using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuContinuar : MonoBehaviour
{
    public GameObject menuContinuar;
    public void Sim()
    {
        //Destroi os objetos existentes
        foreach(var n in CriarBlocos.peçaList)
        {
            Destroy(n);
        }
        foreach (var n in CriarBlocos.respList)
        {
            Destroy(n);
        }

        //limpa os objetos atuais das listas
        CriarBlocos.respList.Clear();
        CriarBlocos.peçaList.Clear();

        //reescolhe palavra chave
        ControladorJogo.Instance.EscolherPalavra();
        ControladorJogo.Instance.ContinuarJogo = true;
        //continuar jogo
        menuContinuar.SetActive(false);
        ControladorJogo.Instance.JogoPausado = false;
    }


    public void Nao()
    {
        ControladorJogo.Instance._continuarJogo = false;
        ControladorJogo.Instance.JogoPausado = false;
        menuContinuar.SetActive(false);
        //sair do jogo
    }
}
