using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 screenPoint = new Vector3(); //pega posição do mouse
    Vector3 offset = new Vector3(); //distância da posição atual até onde o mouse está apontando
    int id;
    public float xLimite, yLimite; //limites horizontal e vertical do nível

    private void OnMouseDown() //logo que o mouse é clicado
    {
        /*
            var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 offset = new Vector2();
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));*/

        screenPoint = Camera.main.WorldToScreenPoint(transform.position); //pega posição do mouse

        //pega a distância da posição atual para o posição do mouse em relação a câmera //talvez não precise do screePoint por ser 2D // testar depois
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

   

    private void OnMouseDrag() //quando o mouse é arrastado
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); //nova posição do mouse
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset; //posição que a peça terá de mover -> em relação à câmera + até o mouse
        
        curPosition.x = Mathf.Clamp(curPosition.x, -xLimite, xLimite); //pos horizontal
        curPosition.y = Mathf.Clamp(curPosition.y, -yLimite, yLimite); //pos vertical
        //não precisa necessariamente separar em x e y, eu só achei mais fácil pra escrever e ler
        //Mathf.Clamp vai limitar a posição da peça entre os limites estabelecidos -> se a nova posição for fora dos limites, segura ela nestes limites estabelecidos
        
        transform.position = curPosition; //finalmente, a posição atual da peça será movida para a posição calculada
    }


    //Não precisa usar

    /*
    void ManterNoEspaço()
    {
        var pos = transform.position; //pega posição atual
        if (pos.x > xLimite || pos.x < -xLimite) //verifica se está dentro dos limites horizontais //X
            transform.position = new Vector2(xLimite, pos.y); //atribui limite 
        //falta o -xLimite, tem que ser separado

        if (pos.y > yLimite || pos.y < -yLimite) //mesma coisa aqui com Y //vertical
            transform.position = new Vector2(pos.x, yLimite);
    }

    private void Update()
    {
       // ManterNoEspaço();
    } */
}


