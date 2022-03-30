using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/1502338/how-to-make-different-objects-spawn-on-in-grid-pat.html
public class Grid : MonoBehaviour
{

    //Confirmar funcionamento e modificar c�digo para uso

    [Tooltip("Margem entre cada pe�a que ser� instanciada na grid (M�nimo 1.0)")]
    public float tileMargin;

    [Tooltip("Rows and cols for the map grid")]
    public Vector2 myGrid;

    [Tooltip("Prefabs dimensions in Unity units")]
    public Vector3 tileDimensions;

    /*
    TileMargin - margem entre cada bloco
    MyGrid - quantidade de linhas (X) e colunas (Y)
    Tile Dimensions - escala dos blocos gerados em rela��o � eles mesmos. Deixar em 1.0.
    */

    [Tooltip("Populate with all the prefabs used to generate map")]
    public GameObject[] prefabTiles;
    //o bloco de resposta

    // storing the map tiles in a list could be useful
    List<GameObject> mapList = new List<GameObject>();
    //tava no c�digo original, mas de fato, pode ser �til


    // Use this for initialization
    void Start()
    {
        CreateMap();
        //efeito tremilique do c�digo original
        //InvokeRepeating("FunkyTiles", 0f, 0.05f);
    }

    void CenterPos(float largura) //centralizar ela na pr�pria largura em dada posi��o
    {
        //Posi��o atual
        Vector3 lastPos = transform.position;

        //horizontal diminui em 1/4 da largura da grid
        lastPos.x -= largura/4;
        //a horizontal, no caso, se refere � posi��o x do objeto no espa�o
        //porque /4 ? N�o fa�o a m�nima ideia(ou ao menos correta), mas funcionou

        //Muda posi��o atual pra nova, centralizada nele mesmo
        transform.position = lastPos;
        //print("Largura medida: " + largura); //teste
    }
    
    void CreateMap() //Criar grid com blocos
    {
        float largura = 0.0f;
        for (int row = 1; row <= myGrid.y; row++) //coluna (no nosso caso 1, mas vai que)
            for (int col = 1; col <= myGrid.x; col++) // para cada linha at� o n�mero delimitado de linhas
            {
                {
                // choose a random prefab tile
                int n = Random.Range(0, prefabTiles.Length); //nesse caso, como s� tem o bloco de resposta, s� vai puxar ele
                GameObject thePrefab = prefabTiles[n];
                //Inclusive, esse c�digo s� vai usar um �nico prefab, mudar para n�o ser lista depois, s� GameObject thePrefab; e tirar esse c�digo

                // spawns the tile/bloco
                GameObject theTile = Instantiate(thePrefab, transform); //o piso vai ser o bloco ///d� pra encurtar as �ltimas 3 linhas de c�digo, inclusive, j� que vai ser s� o bloco
                theTile.name = "Tile_" + col + "_" + row; //nome do bloco gerado que ser� vv�sivel no inspetor //pode ser substitu�do pelo id do bloco...nah
                theTile.transform.localPosition = new Vector3((col - 1) * tileDimensions.x * tileMargin, 0f, (row - 1) * tileDimensions.z);
                    //A posi��o do bloco local (em rela��o ao pai no inspetor) = (x,y,z) -> ((coluna atual) * largura do bloco * margem, linha * altura do bloco, o z n�o faz diferen�a, sinceramente)

                    
                    
                // stores the tile in the List
                mapList.Add(theTile);
            }
        }
        print(mapList.Count + " tiles in the map"); //confirmar se gerou a quantia correta

        //centralizar
        largura = (tileDimensions.x + tileMargin) * myGrid.x; //largura vai ser (tamanho.x + margem) * n�mero de linhas
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
    
    //eu posso s� usar uma refer�ncia de posi��o e ir pra l� direto n�
    /*
    void CenterPos() //tentar centralizar a grid criada em rela��o ao pr�prio tamanho com a posi��o dela no espa�o
    {
        //largura do grid vai ser igual � largura do bloco de resposta
        float largura = prefabTiles[0].transform.localScale.x;

        //multiplicado pela quantidade de blocos
        largura *= myGrid.x;
        /* camera.main.ScreenToWorldPoint -> pega um ponto saindo da camera em (x,y,z)
         * Screen.Width/2 e Screen.height/2 pega o ponto central da camera (tamb�m poderia ser (0.5f , 0.5f, -----) no lugar
         * -largura ao quadrado me deu a metade para 10, mas t� errado
         *
        Vector3 centerPos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - (largura * largura), Screen.height / 2, Camera.main.nearClipPlane));

        //virar a posi��o para a centralizada
        transform.position = centerPos;

        ///////////IGNORAR///////////
        /*   
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        this.transform.position = centerPos;*/
        //escala do emptyobj -> tamanho
        //Vector3 objectSize = transform.localScale; //Vector3.Scale(transform.localScale, GetComponent().mesh.bounds.size);

        //posi��o dele com deslocamento no eixo x referente a metade do pr�prio tamanho, para centralizar
        //Vector3 centerPos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - (objectSize.x / 2), Screen.height / 2, Camera.main.nearClipPlane));

        //alterar a posi��o do gameobj atual para a centralizada
   // } */
}
