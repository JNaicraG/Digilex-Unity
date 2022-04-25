using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    public GameObject menuInicial, menuConfig, menuPontos;
    public Dropdown qualidade, fonteTam;
    public Slider volume;
    public AudioMixer audioMixer;
    
    public void Config()
    {
        menuInicial.SetActive(false);
        menuConfig.SetActive(true);
    }

    public void Pontuacao()
    {
        menuInicial.SetActive(false);
        menuPontos.SetActive(true);
    }

    public void Voltar()
    {
        if (menuConfig.activeInHierarchy)
        {
            menuConfig.SetActive(false);
            menuInicial.SetActive(true);
        }
        else if (menuPontos.activeInHierarchy)
        {
            menuPontos.SetActive(false);
            menuInicial.SetActive(true);
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int indexQualidade)
    {
        QualitySettings.SetQualityLevel(indexQualidade);
    }
    public void SetFonte(int tamanho)
    {
        ControladorFonte.Instance.FonteTamanho = tamanho;
    }

    //Start
    private void Start()
    {
        CarregarQualidadeDropDown();
        CarregarVolume();
        CarregarTamanhoDropdown();
    }

    private void CarregarQualidadeDropDown()
    {
        qualidade.value = QualitySettings.GetQualityLevel();
        qualidade.RefreshShownValue();
    }

    private void CarregarVolume()
    {
        float a = 0;
        audioMixer.GetFloat("volume",out a);
        volume.value = a;
    }

    private void CarregarTamanhoDropdown()
    {
        fonteTam.value = ControladorFonte.Instance.FonteTamanho;
        fonteTam.RefreshShownValue();
    }
}
