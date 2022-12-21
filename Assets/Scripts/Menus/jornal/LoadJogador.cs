using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadJogador : MonoBehaviour
{
    private Inventory info;
    public TextMeshProUGUI tEmpresa, tNome;
    public TextMeshProUGUI tRecebimento, tPagamento, tPrvistos, tLucro;

    void Start()
    {
        if (GameObject.FindWithTag("Loader") != null)
        {
            info = GameObject.FindGameObjectWithTag("Loader").GetComponent<Inventory>();
            tEmpresa.text = info.Empresa;
            tNome.text = info.Nome;
            tRecebimento.text = info.Recebimentos.ToString("0.00");
            tPagamento.text = info.Pagamentos.ToString("0.00");
            tPrvistos.text = info.DespesaFixa.ToString("0.00");
            //tLucro.text = (info.Recebimentos - info.Pagamentos).ToString("0.00");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
