using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menu;
    public Button pausar;
    public void Pausa()
    {
        ControladorJogo.Instance.JogoPausado = true; //Controlador sabe que jogo pausou
        pausar.interactable = false; //botao de Pausa nao e´ mais interagivel
        menu.SetActive(true); //menu de pausa fica visivel
        Debug.Log("Jogo Pausado");
        Time.timeScale = 0; //pausa tudo que for dependente de fisica ou tempo
    }   

    public void Resumir()
    {
        ControladorJogo.Instance.JogoPausado = false; //Controlador sabe que o jogo saiu do pause
        pausar.interactable = true; //botao Pausar volta a ser interagivel
        menu.SetActive(false); //esconde menu de pausa
        Debug.Log("Jogo em Resumo");
        Time.timeScale = 1; //volta tudo a funcionar que seja dependente de fisica ou tempo
    }

    public void VoltarMenu()
    {

    }

    public void VoltarInicio()
    {

    }

}
