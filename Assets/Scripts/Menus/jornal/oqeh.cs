using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oqeh : MonoBehaviour
{
    public void fecharDica()
    {
        GameObject pop = this.gameObject;
        pop.SetActive(false);
    }

    public void abrirDica()
    {
        GameObject pop = this.gameObject;
        pop.SetActive(true);
    }
}
