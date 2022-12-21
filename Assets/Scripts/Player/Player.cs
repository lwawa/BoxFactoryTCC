using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public FixedJoystick move;
    public Button bt;
    private Animator an;
    private Rigidbody2D rb;
    private float moveH, moveV, speedMove = 1000;
    private Vector2 direction;
    private SpriteRenderer sr;
    private string menuSelector;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        bt.gameObject.SetActive(false);
        //bt.enabled = false;
    }

    void Update()
    {
        direction = new Vector2(move.Horizontal, move.Vertical);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + direction * speedMove * Time.fixedDeltaTime);
        if (move.Horizontal != 0 | move.Vertical != 0)
            an.SetBool("Andando", true);
        else
        {
            an.SetBool("Andando", false);
        }
        if(move.Horizontal > 0)
        {
            this.sr.flipX = false;
        }else if (move.Horizontal < 0)
        {
            this.sr.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Belt"))
        {
            menuSelector = "Belt";
            bt.gameObject.SetActive(true);
            bt.onClick.AddListener(openPopup);
            //bt.enabled = true;
        }
        if (collision.gameObject.CompareTag("Send"))
        {
            menuSelector = "Send";
            bt.gameObject.SetActive(true);
            bt.onClick.AddListener(openPopup);
        }
        if (collision.gameObject.CompareTag("Trash"))
        {
            menuSelector = "Trash";
            bt.gameObject.SetActive(true);
            bt.onClick.AddListener(openPopup);
        }
        if (collision.gameObject.CompareTag("Process"))
        {
            menuSelector = "Process";
            bt.gameObject.SetActive(true);
            bt.onClick.AddListener(openPopup);
        }
        if (collision.gameObject.CompareTag("Craft"))
        {
            menuSelector = "Craft";
            bt.gameObject.SetActive(true);
            bt.onClick.AddListener(openPopup);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Belt") || collision.gameObject.CompareTag("Send") || collision.gameObject.CompareTag("Trash") || collision.gameObject.CompareTag("Process") || collision.gameObject.CompareTag("Craft"))
        {
            bt.gameObject.SetActive(false);
        }
    }

    private void openPopup()
    {
        GameObject pop = GameObject.FindGameObjectWithTag("PopupManager");
        switch (menuSelector)
        {
            case "Belt":
                pop.GetComponent<PopupBelt>().PopUp();
                break;
            case "Send":
                pop.GetComponent<PopupSend>().PopUp();
                break;
            case "Trash":
                pop.GetComponent<PopupTrash>().PopUp();
                break;
            case "Process":
                pop.GetComponent<PopupProcess>().PopUp();
                break;
            case "Craft":
                pop.GetComponent<PopupCraft>().PopUp();
                break;
        }
        
    }
}
