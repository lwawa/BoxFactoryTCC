using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //dados a serem salvos
    public string nome, empresa;
    private int demanda1 = 5, demanda2 = 3, demanda3 = 1;
    public float dinheiro = 100;
    private float recebimentos, pagamentos, despesaFixa;
    private float custoEnvio = 100;
    private int evento = 0;
    
    //sistema

    //sistema de inventario
    private GameObject mouseItem;

    public int Demanda1 { get => demanda1; set => demanda1 = value; }
    public int Demanda2 { get => demanda2; set => demanda2 = value; }
    public int Demanda3 { get => demanda3; set => demanda3 = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Empresa { get => empresa; set => empresa = value; }
    public float Dinheiro { get => dinheiro; set => dinheiro = value; }
    public float CustoEnvio { get => custoEnvio; set => custoEnvio = value; }
    public float Recebimentos { get => recebimentos; set => recebimentos = value; }
    public float Pagamentos { get => pagamentos; set => pagamentos = value; }
    public float DespesaFixa { get => despesaFixa; set => despesaFixa = value; }
    public int Evento { get => evento; set => evento = value; }

    public void Awake()
    {
        recebimentos = 0;
        pagamentos = 0;
        if (!this.CompareTag("Loader"))
        {
            if (GameObject.FindWithTag("Loader") != null)
            {
                Infos info = GameObject.FindGameObjectWithTag("Loader").GetComponent<Infos>();
                info.iniciar();
            }
        }
    }

    public void Trasmit()
    {
        if (GameObject.FindWithTag("Loader") != null)
        {
            Inventory inv = GameObject.FindGameObjectWithTag("Loader").GetComponent<Inventory>();
            inv.popular(this.Nome, this.Demanda1, this.Demanda2, this.Demanda3, this.Dinheiro, this.CustoEnvio, this.despesaFixa);
            inv.recebimentos = this.recebimentos;
            inv.pagamentos = this.pagamentos;
        }
    }

    public void DragItem(GameObject button)
    {
        if (!button.name.Equals("vazio"))
        {
            mouseItem = button;
            mouseItem.transform.position = Input.mousePosition;
        }
        
    }

    public void DropItem(GameObject button)
    {
        if (mouseItem != null)
        {
            if (!button.transform.parent.CompareTag("OnlyTakeSlot"))
            {
                if ((mouseItem.transform.parent.CompareTag("OnlyTakeSlot") && button.name.Equals("vazio")) || !mouseItem.transform.parent.CompareTag("OnlyTakeSlot")) {
                    Transform aux = mouseItem.transform.parent;
                    mouseItem.transform.SetParent(button.transform.parent);
                    button.transform.SetParent(aux);
                }
            }
        }
    }

    public float getDinheiro()
    {
        return dinheiro;
    }

    
    public void AddDinheiro(float dinheiro)
    {
        this.recebimentos += dinheiro;
        this.dinheiro += dinheiro;
    }

    public void RmvDinheiro(float dinheiro)
    {
        this.pagamentos += dinheiro;
        this.dinheiro -= dinheiro;
    }

    public void popular(string nome, int demanda1, int demanda2, int demanda3, float dinheiro, float custoEnvio, float despesaFixa)
    {
        this.nome = nome;
        this.demanda1 = demanda1;
        this.demanda2 = demanda2;
        this.demanda3 = demanda3;
        this.dinheiro = dinheiro;
        this.custoEnvio = custoEnvio;
        this.despesaFixa = despesaFixa;
    }


}
