using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 screenPoint = new Vector3(); //pega posi��o do mouse
    Vector3 offset = new Vector3(); //dist�ncia da posi��o atual at� onde o mouse est� apontando
    int id;
    public float xLimite, yLimite; //limites horizontal e vertical do n�vel

    private void OnMouseDown() //logo que o mouse � clicado
    {
        /*
            var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 offset = new Vector2();
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));*/

        screenPoint = Camera.main.WorldToScreenPoint(transform.position); //pega posi��o do mouse

        //pega a dist�ncia da posi��o atual para o posi��o do mouse em rela��o a c�mera //talvez n�o precise do screePoint por ser 2D // testar depois
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

   

    private void OnMouseDrag() //quando o mouse � arrastado
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); //nova posi��o do mouse
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset; //posi��o que a pe�a ter� de mover -> em rela��o � c�mera + at� o mouse
        
        curPosition.x = Mathf.Clamp(curPosition.x, -xLimite, xLimite); //pos horizontal
        curPosition.y = Mathf.Clamp(curPosition.y, -yLimite, yLimite); //pos vertical
        //n�o precisa necessariamente separar em x e y, eu s� achei mais f�cil pra escrever e ler
        //Mathf.Clamp vai limitar a posi��o da pe�a entre os limites estabelecidos -> se a nova posi��o for fora dos limites, segura ela nestes limites estabelecidos
        
        transform.position = curPosition; //finalmente, a posi��o atual da pe�a ser� movida para a posi��o calculada
    }


    //N�o precisa usar

    /*
    void ManterNoEspa�o()
    {
        var pos = transform.position; //pega posi��o atual
        if (pos.x > xLimite || pos.x < -xLimite) //verifica se est� dentro dos limites horizontais //X
            transform.position = new Vector2(xLimite, pos.y); //atribui limite 
        //falta o -xLimite, tem que ser separado

        if (pos.y > yLimite || pos.y < -yLimite) //mesma coisa aqui com Y //vertical
            transform.position = new Vector2(pos.x, yLimite);
    }

    private void Update()
    {
       // ManterNoEspa�o();
    } */
}


