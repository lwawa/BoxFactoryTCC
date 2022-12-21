using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centralizer : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (transform.parent.position - transform.position) * 5 * Time.deltaTime;
    }
}
