using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguracaoBean
{
    public string nomeJogador;
    public int tamFonte, qualidadeIndex;
    public float volume;
    public ConfiguracaoBean(){}
    public ConfiguracaoBean(string nomeJogador, float volume, int tamFonte, int qualidadeIndex){
        this.nomeJogador = nomeJogador;
        this.volume = volume;
        this.tamFonte = tamFonte;
        this.qualidadeIndex = qualidadeIndex;
}
    public ConfiguracaoBean(ConfiguracaoBean config)
    {
        this.nomeJogador = config.nomeJogador;
        this.volume = config.volume;
        this.tamFonte = config.tamFonte;
        this.qualidadeIndex = config.qualidadeIndex;
    }
}
