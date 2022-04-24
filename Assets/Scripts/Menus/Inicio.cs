using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    public GameObject menuInicial, menuConfig, menuPontos;
    public Dropdown qualidade, fonteTam;
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

    private void Start()
    {
        qualidade.value = QualitySettings.GetQualityLevel();
        qualidade.RefreshShownValue();
    }
}
