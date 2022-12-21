using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI tMinutos, tHoras;
    public float minutos, horas;

    // Start is called before the first frame update
    void Start()
    {
        horas = 12;
        minutos = 0;
        tMinutos.text = minutos.ToString("00");
        tHoras.text = horas.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        minutos += Time.deltaTime;
        if (minutos >= 59)
        {
            horas++;
            minutos = 0;
        }
        tMinutos.text = ":" + minutos.ToString("00");
        tHoras.text = horas.ToString("00");
        if (horas == 17)
        {
            if (GameObject.FindWithTag("Trasition") != null)
            {
                Inventory inv = GameObject.FindGameObjectWithTag("Trasition").GetComponent<Inventory>();
                inv.Trasmit();
                SceneManager.LoadScene(2);
            }
        }
    }
}
