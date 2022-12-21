using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSlot : MonoBehaviour
{

    public GameObject item;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.childCount > 0)
        {
            item = this.gameObject.transform.GetChild(0).gameObject;
            if (item.name.Equals("nulo"))
            {
                Destroy(this.gameObject.transform.GetChild(0));
            }
        }
    }
}
