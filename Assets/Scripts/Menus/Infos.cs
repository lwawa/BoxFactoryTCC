using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    // Start is called before the first frame update

    private static Infos instancia;
    private Inventory inv;
    private Inventory eu;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(this);
        }
        else if (instancia != this)
        {
            DestroyObject(gameObject);
            instancia = this;
        }
    }

    public void iniciar()
    {
        
        if (GameObject.FindWithTag("Trasition") != null)
        {
            inv = GameObject.FindGameObjectWithTag("Trasition").GetComponent<Inventory>();
            eu = this.GetComponent<Inventory>();
            inv.popular(eu.Nome, eu.Demanda1, eu.Demanda2, eu.Demanda3, eu.Dinheiro, eu.CustoEnvio, eu.DespesaFixa);
            //inv.transform.GetChild(0).gameObject = eu.transform.GetChild(0).gameObject;
        }
        else
        {
            print("Trasition não encontrada");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
