using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/1502338/how-to-make-different-objects-spawn-on-in-grid-pat.html
public class CriarBlocos : MonoBehaviour
{

    //Confirmar funcionamento e modificar código para uso

    [Tooltip("Margem entre cada peça que será instanciada na grid (Mínimo 1.0)")]
    public float tileMargin;

    [Tooltip("Rows and cols for the map grid")]
    private int _myGrid;

    [Tooltip("Prefabs dimensions in Unity units")]
    public Vector3 tileDimensions;

    /*
    TileMargin - margem entre cada bloco
    MyGrid - quantidade de linhas (X) e colunas (Y)
    Tile Dimensions - escala dos blocos gerados em relação à eles mesmos. Deixar em 1.0.
    */

    [Tooltip("Objeto do Bloco de Respostas")]
    public GameObject blocoResp; //anteriormente PrefabTiles
    //o bloco de resposta

    [Tooltip("Objeto das Peças")]
    public GameObject peça; //anteriormente PrefabTiles
    //As peças

    // storing the map tiles in a list could be useful
    List<GameObject> respList = new List<GameObject>();

    // storing the map tiles in a list could be useful
    List<GameObject> peçaList = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        SpawnResposta();
        SpawnPeças();
        
        //efeito tremilique do código original
        //InvokeRepeating("FunkyTiles", 0f, 0.05f);
    }

    void CenterPos(float largura) //centralizar ela na própria largura em dada posição
    {
        //Posição atual
        Vector3 lastPos = transform.position;

        //horizontal diminui em 1/4 da largura da grid
        lastPos.x -= largura/4;
        //a horizontal, no caso, se refere à posição x do objeto no espaço
        //porque /4 ? Não faço a mínima ideia(ou ao menos correta), mas funcionou

        //Muda posição atual pra nova, centralizada nele mesmo
        transform.position = lastPos;
        //print("Largura medida: " + largura); //teste
    }
 
    //(ArrayList pal)
    void SpawnResposta() //Criar grid com blocos
    {
        //configuraç~~oes da grid
        ArrayList silabas = new ArrayList(); //Lista de silabas que sera carregada
        silabas = ControladorJogo.Instance.Silabas; //pegando silabas j´´a separadas
        _myGrid = ControladorJogo.Instance.nSilabas; //Configurando o tamanho horizontal da grid
        

        //for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
            for (int col = 1; col <= _myGrid; col++) // para cada linha até o número delimitado de linhas
            {
                {
                // spawns the tile/bloco
                GameObject theTile = Instantiate(blocoResp, transform); //o objeto a ser instanciado
                    theTile.GetComponent<BlocoResposta>().id = col; //dá id
                    theTile.GetComponent<BlocoResposta>().sil = silabas[col - 1].ToString(); //dá sílaba a ser mostrada
                    theTile.GetComponent<BlocoResposta>().AlterarTexto();
                    theTile.name = "Tile_" + col + "_";// + row; //nome do bloco gerado que será vvísivel no inspetor //pode ser substituído pelo id do bloco...nah           
                    theTile.transform.localPosition = new Vector3((col - 1) * tileDimensions.x * tileMargin, 0f,  tileDimensions.z);
                //A posição do bloco local (em relação ao pai no inspetor) = (x,y,z) -> ((coluna atual) * largura do bloco * margem, linha * altura do bloco, o z não faz diferença, sinceramente)

                // stores the tile in the List
                respList.Add(theTile);
            }
        }
        //print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta

        //centralizar
        float largura = (tileDimensions.x + tileMargin) * _myGrid; //largura vai ser (tamanho.x + margem) * número de linhas
        if (largura != 0) //confirmando se n foi criado uma grid nula
            CenterPos(largura);
    }

    //a mesma coisa mas para as peças
    private void SpawnPeças()
    {
        //configuraç~~oes da grid
        ArrayList silabas = new ArrayList(); //Lista de silabas que sera carregada
        silabas = ControladorJogo.Instance.Silabas; //pegando silabas j´´a separadas
        _myGrid = ControladorJogo.Instance.nSilabas; //Configurando o tamanho horizontal da grid


        //for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
        for (int col = 1; col <= _myGrid; col++) // para cada linha até o número delimitado de linhas
        {
            {
                // spawns the tile/bloco
                GameObject theTile = Instantiate(peça, transform); //o objeto a ser instanciado
                theTile.GetComponent<Peça>().id = col; //dá id
                theTile.GetComponent<Peça>().sil = silabas[col - 1].ToString(); //dá sílaba a ser mostrada
                theTile.GetComponent<Peça>().AlterarTexto();
                theTile.name = "Tile_" + col + "_";// + row; //nome do bloco gerado que será vvísivel no inspetor //pode ser substituído pelo id do bloco...nah           
                theTile.transform.localPosition = new Vector3((col - 1) * tileDimensions.x * tileMargin, 0f, tileDimensions.z);
                //A posição do bloco local (em relação ao pai no inspetor) = (x,y,z) -> ((coluna atual) * largura do bloco * margem, linha * altura do bloco, o z não faz diferença, sinceramente)
                //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
                float x = Random.Range(0, Screen.width);
                float y = Random.Range(0, Screen.height);
                theTile.transform.localPosition = new Vector3(x, y, 0);
                //theTile.transform.localPosition = 
                // stores the tile in the List
                peçaList.Add(theTile);
            }
        }
        //print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta

    }

    //Ignorar
    // just for some extra fun ;)
    void FunkyTiles()
    {
        int n = Random.Range(0, respList.Count);
        GameObject theTile = respList[n];
        Vector3 temp = theTile.transform.localPosition;
        temp.y = Random.Range(-0.25f, 0.25f);
        theTile.transform.localPosition = temp;
    }
    
}
