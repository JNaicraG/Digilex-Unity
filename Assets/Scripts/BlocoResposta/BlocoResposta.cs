using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlocoResposta : MonoBehaviour
{
    [Tooltip("ID da sílaba")]
    public int id;
    [Tooltip("Sílaba que será exibida")]
    public string sil;
    [Tooltip("O texto da própria peça (Text TMP)")]
    public TextMeshPro textMP;
    // Start is called before the first frame update
    private bool _blocoCorreto = false;
    public bool BlocoCorreto { get => _blocoCorreto; }
    [Tooltip("Tempo para peça tomar posiçao do bloco de resposta correto ao entrar na colisao")]
    public float tempoLerp;





    public void AlterarTexto()
    {
        if (sil != null)
            textMP.text = sil;
        else
            Debug.Log("Silaba vazia, nao pode ser usada para gerar Bloco de Resposta");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peça")) //se o objeto que entrou atualmente no bloco for do tipo PEÇA
        {
            GameObject obj = collision.gameObject;
            if (obj.GetComponent<Peça>().id == id) //se o id/silaba for correto
            {
                Debug.Log("Bloco Correto");
                Debug.Log("Silaba Bloco: " + sil);
                Debug.Log("Silaba Peça: " + obj.GetComponent<Peça>().sil);
                _blocoCorreto = true; //bloco/peça correto
                obj.transform.position = Vector3.Lerp(obj.transform.position, transform.position, tempoLerp); //a posiçao dele se torna a deste bloco
            }
            else
                _blocoCorreto = false;
        }
    }
}
