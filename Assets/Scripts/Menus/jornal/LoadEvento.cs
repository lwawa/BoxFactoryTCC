using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadEvento : MonoBehaviour
{
    private Inventory info;
    public TextMeshProUGUI tDescricao, tNome;
    private string descricao, nome;

    void Start()
    {
        if (GameObject.FindWithTag("Loader") != null)
        {
            info = GameObject.FindGameObjectWithTag("Loader").GetComponent<Inventory>();


            int evento = Random.Range(1, 7);

            switch (evento)
            {
                case 1:
                    nome = "Caixas com estofamento";
                    descricao = "Empresas estão querendo transferir objetos mais delicados precisam de caixas com estofamento";
                    break;
                case 2:
                    nome = "Chega de estofamento";
                    descricao = "Empresas não precisam de proteção extra para seus produtos, estofamento está ultrapassado";
                    break;
                case 3:
                    nome = "Objetos maiores!!";
                    descricao = "Empresas estão precisando de caixas maiores para transportar seus produtos";
                    break;
                case 4:
                    nome = "Objetos menores!!";
                    descricao = "Empresas estão precisando de caixas menores para transportar seus produtos";
                    break;
                case 5:
                    nome = "Caixas simples estão em alta";
                    descricao = "Empresas querem as classicas caixas comuns";
                    break;
                case 6:
                    nome = "Madeira mais resistente";
                    descricao = "Empresas querem caixas de madeira porém precisam delas mais resistentes";
                    break;
                case 7:
                    nome = "Caixa super resistente";
                    descricao = "Empresas querem caixas realmente muito Resistentes, talvez um pouco de metal possa ajudar";
                    break;
            }

            tDescricao.text = descricao;
            tNome.text = nome;
            info.Evento = evento;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
