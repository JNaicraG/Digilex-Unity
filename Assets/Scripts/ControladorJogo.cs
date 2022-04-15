    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class ControladorJogo : MonoBehaviour
{
    //Singleton 
    //Favor ignorar
    private static ControladorJogo _instance;
    public static ControladorJogo Instance {
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
    //Começa aqui//

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
    private void Start()
    {
        CarregarPalavras();

    }


    private void CarregarPalavras() {
        var stream = new StreamReader(loadWordListPath);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        EscolherPalavra();
    }

    private void EscolherPalavra()
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

}
