using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AtualizarValor : MonoBehaviour
{
    private Inventory info;
    public int evento;
    public Button aumenta,mantem,diminui,sim,nao;
    public GameObject fundo1bom, fundo2bom, fundo1ruim, fundo2ruim;
    private ProdInfo caixa1, caixa2, caixa3;
    private bool tamanho, estofado;
    void Start()
    {
        if (GameObject.FindWithTag("Loader") != null)
        {
            info = GameObject.FindGameObjectWithTag("Loader").GetComponent<Inventory>();
            evento = info.Evento;
            caixa1 = info.transform.GetChild(0).GetComponent<ProdInfo>();
            caixa2 = info.transform.GetChild(0).GetComponent<ProdInfo>();
            caixa3 = info.transform.GetChild(0).GetComponent<ProdInfo>();
        }
        aumenta.onClick.AddListener(RespostaAumento);
        mantem.onClick.AddListener(RespostaManter);
        diminui.onClick.AddListener(RespostaDiminuir);
        sim.onClick.AddListener(RepostaComEstofado);
        nao.onClick.AddListener(RepostaSemEstofado);
        switch (evento)
        {
            case 5:
                info.Demanda1+= 3;
                break;
            case 6:
                info.Demanda2+= 2;
                break;
            case 7:
                info.Demanda3++;
                break;
        }
        tamanho = false;
        estofado = false;
    }

    private void RespostaAumento()
    {
        if (evento == 3)
        {
            fundo1bom.SetActive(true);
            caixa1.Preco += 20;
            caixa2.Preco += 30;
            caixa3.Preco += 40;
            
        }
        else
        {
            fundo1ruim.SetActive(true);
            if (info.Demanda1 > 1)
                info.Demanda1--;
            if (info.Demanda2 > 1)
                info.Demanda2--;
            if (info.Demanda3 > 1)
                info.Demanda3--;
        }
        aumenta.enabled = false;
        mantem.enabled = false;
        diminui.enabled = false;
        tamanho = true;
    }
    private void RespostaManter()
    {
        if (evento != 3 && evento != 4)
        {
            fundo1bom.SetActive(true);
        }
        else {
            fundo1ruim.SetActive(true);
            caixa1.Preco -= 20;
            caixa2.Preco -= 30;
            caixa3.Preco -= 40;
        }
        aumenta.enabled = false;
        mantem.enabled = false;
        diminui.enabled = false;
        tamanho = true;
    }
    private void RespostaDiminuir()
    {
        if (evento == 4)
        {
            fundo1bom.SetActive(true);
            caixa1.Preco += 20;
            caixa2.Preco += 30;
            caixa3.Preco += 40;
        }
        else
        {
            fundo1ruim.SetActive(true);
            if (info.Demanda1 > 1)
                info.Demanda1--;
            if (info.Demanda2 > 1)
                info.Demanda2--;
            if (info.Demanda3 > 1)
                info.Demanda3--;
        }
        aumenta.enabled = false;
        mantem.enabled = false;
        diminui.enabled = false;
        tamanho = true;
    }

    private void RepostaComEstofado()
    {
        if (evento == 1)
        {
            fundo2bom.SetActive(true);
            caixa1.Preco += 40;
            caixa2.Preco += 60;
            caixa3.Preco += 80;
        }
        else
        {
            fundo2ruim.SetActive(true);
            if (info.Demanda1 > 1)
                info.Demanda1--;
            if (info.Demanda2 > 1)
                info.Demanda2--;
            if (info.Demanda3 > 1)
                info.Demanda3--;
        }
        sim.enabled = false;
        nao.enabled = false;
        estofado = true;
    }

    private void RepostaSemEstofado()
    {
        if (evento == 2 || evento == 5 || evento == 6 || evento == 7)
        {
            fundo2bom.SetActive(true);
            caixa1.Preco += 40;
            caixa2.Preco += 60;
            caixa3.Preco += 80;
        }
        else
        {
            fundo2ruim.SetActive(true);
            if (info.Demanda1 > 1)
                info.Demanda1--;
            if (info.Demanda2 > 1)
                info.Demanda2--;
            if (info.Demanda3 > 1)
                info.Demanda3--;
        }
        sim.enabled = false;
        nao.enabled = false;
        estofado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tamanho && estofado)
        {
            SceneManager.LoadScene(1);
        }
    }
}
