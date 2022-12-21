using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupProcess : MonoBehaviour
{
    public GameObject popUpBox;
    public float maxProgress;
    public float progress;
    public Button ok;
    public Button produzir;
    public GameObject slot;
    public GameObject output;
    public GameObject tabua;
    public bool producing;
    private string material;
    public GameObject inst;
    //public Animator animator;
    //public TMP_Text txt;

    public void Start()
    {
        producing = false;
    }

    private void FixedUpdate()
    {
        if (producing)
        {
            if (progress < maxProgress)
            {
                progress += Time.deltaTime * 5;
            }
            else
            {
                if(material.Equals("Madeira"))
                {   
                    GameObject instancia = Instantiate(tabua, output.transform.position, output.transform.rotation) as GameObject;
                    instancia.transform.name = "Tabua";
                    instancia.transform.SetParent(output.transform);
                    instancia.SetActive(true);
                }
                producing = false;
                progress = 0;
                /*if (item.transform.childCount == 0)
                {
                    GameObject instancia = Instantiate(inst, item.transform.position, item.transform.rotation) as GameObject;
                    instancia.transform.SetParent(item.transform);
                    instancia.SetActive(true);
                }*/

            }
        }
        if (output.transform.childCount > 0)
        {
            if (output.transform.GetChild(0).transform.name == "vazio") {
                DestroyImmediate(output.transform.GetChild(0).gameObject);
            }
        }
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        ok.onClick.AddListener(PopOut);
        produzir.onClick.AddListener(Produzir);
    }

    public void Produzir()
    {
        if(slot.transform.childCount > 0)
        {
            if (output.transform.childCount == 0)
            {
                if (slot.transform.GetChild(0).CompareTag("MateriaPrima"))
                {
                    producing = true;
                    material = slot.transform.GetChild(0).gameObject.name;
                    DestroyImmediate(slot.transform.GetChild(0).gameObject);
                    GameObject instancia = Instantiate(inst, slot.transform.position, slot.transform.rotation) as GameObject;
                    instancia.transform.name = "vazio";
                    instancia.transform.SetParent(slot.transform);
                    instancia.SetActive(true);
                }
                else
                {
                    
                }
            }
            else
            {

            }
        }
    }

    public void PopOut()
    {
        popUpBox.SetActive(false);
    }
}
