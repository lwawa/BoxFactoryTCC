using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusLoadBar2 : MonoBehaviour
{
    public PopupBelt info;
    public GameObject progressBar;
    public GameObject item;
    public GameObject teste;
    public GameObject prefab;


    private void Start()
    {
        //teste = Instantiate(prefab);
    }

    private void FixedUpdate()
    {
        progressBar.transform.localScale = new Vector2(getSizeBar(info.progress2, info.maxProgress), progressBar.transform.localScale.y);
    }

    public float getSizeBar(float minV, float maxV)
    {
        return minV / maxV;
    }

    public int getPercentBar(float minV, float maxV, int factor)
    {
        return Mathf.RoundToInt(getSizeBar(minV,maxV)*factor);
    }
}
