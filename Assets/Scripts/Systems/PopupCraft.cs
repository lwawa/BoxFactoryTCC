using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupCraft : MonoBehaviour
{
    public GameObject popUpBox;
    public float maxProgress;
    public float progress;
    public Button ok;
    public Button produzir;
    public List<GameObject> craftslots;
    public GameObject output;
    public GameObject caixa1, caixa2, caixa3;
    public GameObject vazio;
    public bool producing;
    private string material;
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
                if(material.Equals("M1"))
                {   
                    GameObject instancia = Instantiate(caixa1, output.transform.position, output.transform.rotation) as GameObject;
                    instancia.transform.name = "Caixa1";
                    instancia.transform.SetParent(output.transform);
                    instancia.SetActive(true);
                }
                if (material.Equals("M2")){
                    GameObject instancia = Instantiate(caixa2, output.transform.position, output.transform.rotation) as GameObject;
                    instancia.transform.name = "Caixa2";
                    instancia.transform.SetParent(output.transform);
                    instancia.SetActive(true);
                }
                if (material.Equals("M3"))
                {
                    GameObject instancia = Instantiate(caixa3, output.transform.position, output.transform.rotation) as GameObject;
                    instancia.transform.name = "Caixa3";
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
            if (output.transform.GetChild(0).transform.name == "vazio")
            {
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
        int madeira = 0;
        int metal = 0;

        foreach(GameObject slot in craftslots)
        {
            if (slot.transform.childCount > 0)
            {
                if (output.transform.childCount == 0)
                {
                    if (slot.transform.GetChild(0).CompareTag("Processado"))
                    {
                        material = slot.transform.GetChild(0).gameObject.name;
                        switch (material) {
                            case "Tabua":
                                print("tauba");
                                madeira++;
                                break;
                            case "Metal":
                                metal++;
                                break;
                        }
                    }
                }
            }
        }
        print("5");
        if (madeira + metal >= 2)
        {
            foreach (GameObject slot in craftslots)
            {
                if (slot.transform.childCount > 0)
                {
                    DestroyImmediate(slot.transform.GetChild(0).gameObject);
                    GameObject instancia = Instantiate(vazio, slot.transform.position, slot.transform.rotation) as GameObject;
                    instancia.transform.name = "vazio";
                    instancia.transform.SetParent(slot.transform);
                    instancia.SetActive(true);
                    if (madeira == 2)
                    {
                        material = "M1";
                    }
                    if (madeira == 3)
                    {
                        material = "M2";
                    }
                    if (madeira == 2 && metal == 1){
                        material = "M3";
                    }

                }
            }
            producing = true;
        }
    }

    public void PopOut()
    {
        popUpBox.SetActive(false);
    }
}
