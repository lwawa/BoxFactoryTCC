using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestMenu : MonoBehaviour
{
    public TextMeshProUGUI caixaMadeira, caixaMadeiraR, caixaMetal;
    public int qcaixaMadeira, qcaixaMadeiraR, qcaixaMetal;
    public Inventory data;

    void Awake()
    {
        if (data != null)
        {
            int multiMadeira = Random.Range(1, 3);
            qcaixaMadeira = data.Demanda1 * multiMadeira;
            int multiMadeiraR = Random.Range(1, 2);
            qcaixaMadeiraR = data.Demanda2 * multiMadeiraR;
            int multiMetal = Random.Range(1, 1);
            qcaixaMetal = data.Demanda3 * multiMetal;
        }

    }

    void Update()
    {
        if (data != null)
        {
            caixaMadeira.text = qcaixaMadeira.ToString();
            caixaMadeiraR.text = qcaixaMadeiraR.ToString();
            caixaMetal.text = qcaixaMetal.ToString();
        }
    }
}
