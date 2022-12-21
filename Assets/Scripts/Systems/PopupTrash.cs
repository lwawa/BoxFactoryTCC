using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupTrash : MonoBehaviour
{
    public GameObject popUpBox;
    public Button btDestroy;
    public GameObject inst;
    public List<GameObject> listaSlot = new List<GameObject>();
    //public Animator animator;
    //public TMP_Text txt;

    public void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        btDestroy.onClick.AddListener(Destroy);
    }

    public void Destroy()
    {
        foreach (GameObject slot in listaSlot)
        {
            if (slot.transform.childCount > 0)
            {
                if (!slot.transform.GetChild(0).name.Equals("vazio"))
                {
                    DestroyImmediate(slot.transform.GetChild(0).gameObject);
                    if (slot.transform.childCount == 0)
                    {
                        GameObject instancia = Instantiate(inst, slot.transform.position, slot.transform.rotation) as GameObject;
                        instancia.transform.name = "vazio";
                        instancia.transform.SetParent(slot.transform);
                        instancia.SetActive(true);
                    }
                    
                }
            }
        }
        popUpBox.SetActive(false);
    }

    public void PopOut()
    {
        popUpBox.SetActive(false);
    }
}
