using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBelt : MonoBehaviour
{
    public GameObject popUpBox;
    public float maxProgress;
    public float progress, progress2;
    public Button ok;
    public GameObject item, item2;
    public GameObject inst, inst2;
    //public Animator animator;
    //public TMP_Text txt;

    public void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (item.transform.childCount > 0)
        {
            if (item.transform.GetChild(0).name.Equals("vazio"))
            {
                Destroy(item.transform.GetChild(0).gameObject);
                progress = 0;
            }
        }
        if (item2.transform.childCount > 0)
        {
            if (item2.transform.GetChild(0).name.Equals("vazio"))
            {
                Destroy(item2.transform.GetChild(0).gameObject);
                progress2 = 0;
            }
        }
        if (progress < maxProgress)
        {
            progress += Time.deltaTime * 5;
        }
        else
        {
            if (item.transform.childCount == 0)
            {
                GameObject instancia = Instantiate(inst, item.transform.position, item.transform.rotation) as GameObject;
                instancia.transform.name = "Madeira";
                instancia.transform.SetParent(item.transform);
                instancia.SetActive(true);
            }

        }

        if (progress2 < maxProgress)
        {
            progress2 += Time.deltaTime;
        }
        else
        {
            if (item2.transform.childCount == 0)
            {
                GameObject instancia2 = Instantiate(inst2, item2.transform.position, item2.transform.rotation) as GameObject;
                instancia2.transform.name = "Metal";
                instancia2.transform.SetParent(item2.transform);
                instancia2.SetActive(true);
            }

        }

    }

    public void PopUp()
    {
        popUpBox.SetActive(true);
        ok.onClick.AddListener(PopOut);
    }

    public void PopOut()
    {
        popUpBox.SetActive(false);
    }
}
