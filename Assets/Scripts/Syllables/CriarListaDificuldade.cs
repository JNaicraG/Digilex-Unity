using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CriarListaDificuldade : MonoBehaviour
{
    public string loadWordListPath;
    public string listafacil;
    private List<string> _listaPalavras = new List<string>();

    private List<string> _listaDificuldade = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CarregarPalavras();
    }


    private void CarregarPalavras()
    {
        ArrayList _silabas = new ArrayList();
        var stream = new StreamReader(loadWordListPath);
        while (!stream.EndOfStream)
            _listaPalavras.Add(stream.ReadLine());
        Syllable syl = new Syllable();
        foreach(var n in _listaPalavras)
        {
            _silabas = syl.word2syllables(n);
            if(_silabas.Count >= 6 &&_silabas.Count>=4)
            {
                _listaDificuldade.Add(n);
            }
            //if(syl.word2syllables);
        }
        //string path = "Assets/Prefab/Lista de Palavras/ListaFacil.txt";// Application.persistentDataPath + "/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(listafacil, true);
        foreach(var n in _listaDificuldade)
        {
            writer.WriteLine(n.ToString());

        }
        writer.Close();
        StreamReader reader = new StreamReader(listafacil);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();


    }

}
