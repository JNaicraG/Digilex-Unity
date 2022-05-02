    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class ControladorJogo : MonoBehaviour
{
    //private List<GameObject> _blocosResp = new List<GameObject>();
    //public List<GameObject> BlocoResp { get =>_blocosResp; }
    //public GameObject blocoResp;
    public bool _continuarJogo = false;
    public bool ContinuarJogo { get => _respostasCorretas; set => _respostasCorretas = value; }
    public GameObject menuContinuar;
    private bool _respostasCorretas = false;
    public bool RespostasCorretas { get => _respostasCorretas; set => _respostasCorretas = value; }
    //Variaveis//
    [Tooltip("Caminho que a lista de palavras a ser utilizada está")]
    public string loadWordListPath;
    private List<string> _listaPalavras = new List<string>();
    private string _palavraChave;
    public string PalavraChave
    {
        get
        {
            //Some other code
            return _palavraChave;
        }
        set
        {
        }
    }
    private ArrayList _silabas = new ArrayList();
    public ArrayList Silabas
    {
        get
        {
            //Some other code
            return _silabas;
            
        }
        set
        {
        }
    }

    private int _nSilabas = 0; //numero de silabas
    public int nSilabas
    {
        get
        {
            return _nSilabas;
        }
        set { }
    }

    private bool _jogoPausado = false;
    public bool JogoPausado { get => _jogoPausado; set => _jogoPausado = value; }

    //Void Start//
    private void Start()
    {
        CarregarPalavras();

    }

    private void Update()
    {
        ConfirmarRespostas();
    }


    //Funçoes//
    private void JogoAcabou()
    {
        if (!_continuarJogo)
        {
            //salvar score atual
            //voltar ao menu inicial
            Debug.Log("JOGO ACABOU");
        }
    }
    private void ConfirmarRespostas()
    {
        List<GameObject> blocos = CriarBlocos.respList; //lista de blocos respostas existentes
        int tam = blocos.Count; //tamanho da lista / quantas silabas tem
        int corretos = 0; //numero de peças posicionadas corretamente
        foreach (var n in blocos) //para cada bloco
        {
            if (n.GetComponent<BlocoResposta>().BlocoCorreto) //verificar se resposta e peça batem
                corretos++; //adiciona como correto
        }
        if (corretos == tam) //se bater o numero de respostas corretas com blocos existentes
        {
            _jogoPausado = true;
            menuContinuar.SetActive(true);
        }
        corretos = 0;
        //_respostasCorretas = true; //acabar o jogo
    }



    private void CarregarPalavras() {
        var stream = new StreamReader(loadWordListPath);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        EscolherPalavra();
    }

    public void EscolherPalavra()
    {
        int nMax = _listaPalavras.Count;
        _palavraChave = _listaPalavras[Random.Range(0, nMax)];
        //Debug.Log("Palavra-Chave escolhida: " + _palavraChave);
        SepararSilaba();
    }

    private void SepararSilaba()
    {
        if (_palavraChave != null)
        {
            Syllable syl = new Syllable();
            _silabas = syl.word2syllables(_palavraChave.ToLower());
            _nSilabas = _silabas.Count;
            /*foreach (var n in _silabas)
                Debug.Log("Silaba escolhida: " + n.ToString());*/
        }
        else
            Debug.Log("Palavra Chave ainda nao foi escolhida");
    }




    //Singleton 
    //Favor ignorar
    private static ControladorJogo _instance;
    public static ControladorJogo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ControladorJogo)) as ControladorJogo;
                //Debug.LogError("ControladorJogo é Null / não existe");
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
    //

}
