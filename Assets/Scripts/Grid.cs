using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/1502338/how-to-make-different-objects-spawn-on-in-grid-pat.html
public class Grid : MonoBehaviour
{

    //Confirmar funcionamento e modificar código para uso

    [Tooltip("Margem entre cada peça que será instanciada na grid (Mínimo 1.0)")]
    public float tileMargin;

    [Tooltip("Rows and cols for the map grid")]
    public Vector2 myGrid;

    [Tooltip("Prefabs dimensions in Unity units")]
    public Vector3 tileDimensions;

    /*
    TileMargin - margem entre cada bloco
    MyGrid - quantidade de linhas (X) e colunas (Y)
    Tile Dimensions - escala dos blocos gerados em relação à eles mesmos. Deixar em 1.0.
    */

    [Tooltip("Populate with all the prefabs used to generate map")]
    public GameObject[] prefabTiles;
    //o bloco de resposta

    // storing the map tiles in a list could be useful
    List<GameObject> mapList = new List<GameObject>();
    //tava no código original, mas de fato, pode ser útil


    // Use this for initialization
    void Start()
    {
        CreateMap();
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
    
    void CreateMap() //Criar grid com blocos
    {
        float largura = 0.0f;
        for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
            for (int col = 1; col <= myGrid.x; col++) // para cada linha até o número delimitado de linhas
            {
                {
                // choose a random prefab tile
                int n = Random.Range(0, prefabTiles.Length); //nesse caso, como só tem o bloco de resposta, só vai puxar ele
                GameObject thePrefab = prefabTiles[n];
                //Inclusive, esse código só vai usar um único prefab, mudar para não ser lista depois, só GameObject thePrefab; e tirar esse código

                // spawns the tile/bloco
                GameObject theTile = Instantiate(thePrefab, transform); //o piso vai ser o bloco ///dá pra encurtar as últimas 3 linhas de código, inclusive, já que vai ser só o bloco
                theTile.name = "Tile_" + col + "_" + row; //nome do bloco gerado que será vvísivel no inspetor //pode ser substituído pelo id do bloco...nah
                theTile.transform.localPosition = new Vector3((col - 1) * tileDimensions.x * tileMargin, 0f, (row - 1) * tileDimensions.z);
                    //A posição do bloco local (em relação ao pai no inspetor) = (x,y,z) -> ((coluna atual) * largura do bloco * margem, linha * altura do bloco, o z não faz diferença, sinceramente)

                    
                    
                // stores the tile in the List
                mapList.Add(theTile);
            }
        }
        print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta

        //centralizar
        largura = (tileDimensions.x + tileMargin) * myGrid.x; //largura vai ser (tamanho.x + margem) * número de linhas
        if (largura != 0) //vai que
            CenterPos(largura);
    }

    //Ignorar

    // just for some extra fun ;)
    void FunkyTiles()
    {
        int n = Random.Range(0, mapList.Count);
        GameObject theTile = mapList[n];
        Vector3 temp = theTile.transform.localPosition;
        temp.y = Random.Range(-0.25f, 0.25f);
        theTile.transform.localPosition = temp;
    }
    
    //eu posso só usar uma referência de posição e ir pra lá direto né
    /*
    void CenterPos() //tentar centralizar a grid criada em relação ao próprio tamanho com a posição dela no espaço
    {
        //largura do grid vai ser igual à largura do bloco de resposta
        float largura = prefabTiles[0].transform.localScale.x;

        //multiplicado pela quantidade de blocos
        largura *= myGrid.x;
        /* camera.main.ScreenToWorldPoint -> pega um ponto saindo da camera em (x,y,z)
         * Screen.Width/2 e Screen.height/2 pega o ponto central da camera (também poderia ser (0.5f , 0.5f, -----) no lugar
         * -largura ao quadrado me deu a metade para 10, mas tá errado
         *
        Vector3 centerPos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - (largura * largura), Screen.height / 2, Camera.main.nearClipPlane));

        //virar a posição para a centralizada
        transform.position = centerPos;

        ///////////IGNORAR///////////
        /*   
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        this.transform.position = centerPos;*/
        //escala do emptyobj -> tamanho
        //Vector3 objectSize = transform.localScale; //Vector3.Scale(transform.localScale, GetComponent().mesh.bounds.size);

        //posição dele com deslocamento no eixo x referente a metade do próprio tamanho, para centralizar
        //Vector3 centerPos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - (objectSize.x / 2), Screen.height / 2, Camera.main.nearClipPlane));

        //alterar a posição do gameobj atual para a centralizada
   // } */
}
