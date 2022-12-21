using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusProcessBar : MonoBehaviour
{
    public PopupProcess info;
    public GameObject progressBar;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        progressBar.transform.localScale = new Vector2(getSizeBar(info.progress, info.maxProgress), progressBar.transform.localScale.y);
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
