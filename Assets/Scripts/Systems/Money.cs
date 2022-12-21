using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI tDinheiro;
    private float dinheiro;
    public Inventory data;
    // Start is called before the first frame update
    void Start()
    {
        tDinheiro = this.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (data != null) {
            dinheiro = data.getDinheiro();
            tDinheiro.text = dinheiro.ToString("0000.00");
        }
    }
}
