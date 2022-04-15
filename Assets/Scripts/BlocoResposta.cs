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
    private bool blocoCorreto = false;






    public void AlterarTexto()
    {
        if (sil != null)
            textMP.text = sil;
        else
            Debug.Log("Silaba vazia, nao pode ser usada para gerar Bloco de Resposta");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peça"))
        {
            GameObject obj = collision.gameObject;
            if (obj.GetComponent<Peça>().id == id)
                blocoCorreto = true;
            else
                blocoCorreto = false;
        }
    }
}
