using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupSend : MonoBehaviour
{
    public GameObject popUpBox;
    public float maxProgress;
    public float progress;
    public Button btClose;
    public Button btSend;
    public List<GameObject> listaSlot = new List<GameObject>();
    //public GameObject inst;
    public Inventory inventario;
    public RequestMenu request;
    public GameObject vazio;
    public TextMeshProUGUI custo;
    private bool vendeu, voltando;
    private float custoEnvio;
    //public Animator animator;
    //public TMP_Text txt;

    public void Start()
    {
        custoEnvio = inventario.CustoEnvio;
        custo.text = custoEnvio.ToString("000.00");
    }

    private void FixedUpdate()
    {
        if (voltando)
        {

            if (progress < maxProgress)
            {
                progress += Time.deltaTime;

            }
            else
            {
                voltando = false;
                btSend.enabled = true;
                progress = 0;
            }
        }
        
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        btClose.onClick.AddListener(PopOut);
        btSend.onClick.AddListener(Send);
    }

    public void Send()
    {
        foreach (GameObject slot in listaSlot)
        {
            GameObject item = slot.transform.GetChild(0).gameObject;
            if (item.CompareTag("Produto"))
            {
                ProdInfo produto = item.GetComponent<ProdInfo>();
                switch (item.transform.name)
                {
                    case "Caixa1":
                        if (request.qcaixaMadeira > 0)
                        {
                            inventario.AddDinheiro(produto.Preco);
                            DestroyImmediate(slot.transform.GetChild(0).gameObject);
                            request.qcaixaMadeira--;
                        }
                        break;
                    case "Caixa2":
                        if (request.qcaixaMadeiraR > 0)
                        {
                            inventario.AddDinheiro(produto.Preco);
                            DestroyImmediate(slot.transform.GetChild(0).gameObject);
                            request.qcaixaMadeiraR--;
                        }
                        break;
                    case "Caixa3":
                        if (request.qcaixaMetal > 0)
                        {
                            inventario.AddDinheiro(produto.Preco);
                            DestroyImmediate(slot.transform.GetChild(0).gameObject);
                            request.qcaixaMetal--;
                        }
                        break;
                }
                GameObject instancia = Instantiate(vazio, slot.transform.position, slot.transform.rotation) as GameObject;
                instancia.transform.name = "vazio";
                instancia.transform.SetParent(slot.transform);
                instancia.SetActive(true);
                vendeu = true;
                btSend.enabled = false;
            }
        }
        if (vendeu) {
            inventario.RmvDinheiro(custoEnvio);
            vendeu = false;
            voltando = true;
        }
    }

    public void PopOut()
    {
        popUpBox.SetActive(false);
    }
}
