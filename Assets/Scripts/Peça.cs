using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Peça : MonoBehaviour
{
    [Tooltip("ID da sílaba")]
    public int id;
    [Tooltip("Sílaba que será exibida")]
    public string sil;
    [Tooltip("O texto da própria peça (Text TMP)")]
    public TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = sil;
    }
}
