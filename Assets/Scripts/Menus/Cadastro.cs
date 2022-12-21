using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cadastro : MonoBehaviour
{
    private Button botao;
    public GameObject popup;

    void Start()
    {
        botao = this.GetComponent<Button>();
        botao.onClick.AddListener(cadastrar);
    }

    private void cadastrar()
    {
        popup.SetActive(true);
    }

}
