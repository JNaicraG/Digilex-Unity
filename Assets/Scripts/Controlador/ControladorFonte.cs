using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFonte : MonoBehaviour
{


    private void Start()
    {
        SetTamanhoInicial();
    }

    private int _fonteTamanho;
    public int FonteTamanho { get => _fonteTamanho; set => _fonteTamanho = value; }
    private int _topico,_texto,_titulo,_botao, _pe�a;
    public int Topico { get => _topico; set { } }
    public int Texto { get => _texto; set { } }
    public int Titulo { get => _titulo; set { } }
    public int Botao { get => _botao; set { } }
    public int Pe�a { get => _pe�a; set { } }
    private void Tamanho()
    {
        switch (_fonteTamanho)
        {
            case 0:
                _topico = 14;
                _texto = 12;
                _titulo = 18;
                _botao = 8;
                _pe�a = 36;
                break;
            case 1:
                _topico = 18;
                _texto = 16;
                _titulo = 22;
                _botao = 12;
                _pe�a = 40;
                break;
            case 2:
                _topico = 22;
                _texto = 20;
                _titulo = 26;
                _botao = 16;
                _pe�a = 44;
                break;
            case 3:
                _topico = 26;
                _texto = 24;
                _titulo = 30;
                _botao = 20;
                _pe�a = 48;
                break;
        }
    }


    //Fun�oes
    private void SetTamanhoInicial() {
        ConfiguracaoBean config = new ConfiguracaoBean();
        config = ControleSalvarJogo.CarregarConfig();
        _fonteTamanho = config.tamFonte;
    }



    //Singleton 
    //Favor ignorar
    private static ControladorFonte _instance;
    public static ControladorFonte Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ControladorFonte)) as ControladorFonte;
                //Debug.LogError("ControladorJogo � Null / n�o existe");
            }
            return _instance;
        }
        private set { }
    }

    

    private void Awake()
    {
        // Deletar instancia desse script que nao seja ele mesmo (evitar duplicatas)
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
