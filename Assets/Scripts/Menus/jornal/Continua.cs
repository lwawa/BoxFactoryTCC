using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continua : MonoBehaviour
{
    private Button botao;
    // Start is called before the first frame update
    private void Start()
    {
        botao = this.GetComponent<Button>();
        botao.onClick.AddListener(continua);
    }
    public void continua()
    {
        SceneManager.LoadScene(3);
    }
}
