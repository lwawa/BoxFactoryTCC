using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class btJogar : MonoBehaviour
{
    private Button botao;
    public string nome, empresa;
    public TextMeshProUGUI tNome, tEmpresa;

    void Start()
    {
        
        botao = this.GetComponent<Button>();
        botao.onClick.AddListener(iniciarJogo);
    }
    private void iniciarJogo()
    {
        nome = tNome.text;
        empresa = tEmpresa.text;
        if (GameObject.FindWithTag("Loader") != null)
        {
            Inventory info = GameObject.FindGameObjectWithTag("Loader").GetComponent<Inventory>();
            info.Empresa = empresa;
            info.Nome = nome;
            SceneManager.LoadScene(1);
        }
    }

}