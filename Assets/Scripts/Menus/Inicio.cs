using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    public TextMeshProUGUI[] texto, topico;
    public TextMeshProUGUI voltarTexto;
    public GameObject menuInicial, menuConfig, menuPontos;
    public TMP_Dropdown qualidade, fonteTam;
    public Slider volume;
    public AudioMixer audioMixer;
    ConfiguracaoBean config = new ConfiguracaoBean();
    private int _nMenus = 3; //atualmenet menu inicial, config, pontuacao
    
    //Funçoes de UI
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
        if (menuConfig.activeInHierarchy) //se p menu config  for o aberto
        {
            menuConfig.SetActive(false); //desativa ele
            menuInicial.SetActive(true); //abre menu inicial
        }
        else if (menuPontos.activeInHierarchy) //se for a pontuaçao aberta
        {
            menuPontos.SetActive(false); //fecha ele
            menuInicial.SetActive(true); //abre inicial
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); //deixa o audio conforme volume selecionado
        config.volume = volume; //altera o volume guardado
        ControleSalvarJogo.SalvarConfig(config); //salva volume

    }

    public void SetQuality(int indexQualidade)
    {
        QualitySettings.SetQualityLevel(indexQualidade); //altera qualidade atual
        config.qualidadeIndex = indexQualidade; //guarda o index atual de qualidade
        ControleSalvarJogo.SalvarConfig(config); //salva
    }
    public void SetFonte(int tamanho)
    {
        ControladorFonte.Instance.FonteTamanho = tamanho; //muda o tamanho de fonte atual guardado
        ControladorFonte.Instance.FonteAlterada = true;
        ControladorFonte.Instance.IndexMudança = _nMenus;
        config.tamFonte = tamanho;  //guarda para salvar
        ControleSalvarJogo.SalvarConfig(config); //salva
        AlterarFonte();
    }

    public void SetNomeJogador(string nome)
    {
        config.nomeJogador.Replace(config.nomeJogador, nome);
        ControleSalvarJogo.SalvarConfig(config);
    }

    //Start
    private void Start()
    {
        CarregarQualidadeDropDown();
        CarregarVolume();
        CarregarTamanhoDropdown();
    }

    //Update()
    private void Update()
    {
        AlterarFonte(); //pra caso quando o ControleSave carregar uma config com tamanho de fonte diferente da que o jogo abrir
    }

    //Funçoes "normais"
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

    private void AlterarFonte()
    {
        if(ControladorFonte.Instance.FonteAlterada && ControladorFonte.Instance.IndexMudança > 0)
        {
            voltarTexto.fontSize = ControladorFonte.Instance.Texto;
            
            foreach (var n in texto)
                n.fontSize = ControladorFonte.Instance.Texto;
            
            foreach(var n in topico)
            n.fontSize = ControladorFonte.Instance.Topico;

            ControladorFonte.Instance.IndexMudança--;
            if (ControladorFonte.Instance.IndexMudança <= 0)
                ControladorFonte.Instance.FonteAlterada = false;    
        }
    }
}
