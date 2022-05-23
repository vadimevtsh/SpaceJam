using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMan : MonoBehaviour
{
    private Vector3 moveDelta;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    public Vector2 moveSpeed;

    public O2Bar myBar;
    public float maxOxygen;
    public float currentOxygen;
    public float defaultOxygenRaiseDown;

    private string[] collidableNames = new string[6] { "bottleFloor", "EnterSpaceShip", "QuitSpaceShip", "ToMaxOxygen", "fireKillerInSnow", "yellowCristal" };
    public GameObject myText;

    void Start()
    {
        defaultOxygenRaiseDown = 5;
        maxOxygen = 100;
        currentOxygen = maxOxygen;
        myBar.SetMaxOxygen(maxOxygen);

        moveSpeed = new Vector2(0.9f, 0.9f);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime * moveSpeed.y), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * moveSpeed.y, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime * moveSpeed.x), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime * moveSpeed.x, 0, 0);
        }

        changeLevelOfOxygen();
    }

    private void changeLevelOfOxygen()
    {
        if (currentOxygen >= maxOxygen)
            currentOxygen = 100;
        currentOxygen -= defaultOxygenRaiseDown * Time.deltaTime;
        myBar.SetOxygen(currentOxygen);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (checkCollisionExit(other))
        {
            myText.SetActive(false);
            if (other.collider.name == "QuitSpaceShip")
            {
                myText.SetActive(false);
                defaultOxygenRaiseDown = 5; 
            }
        }
        
    }

    private bool checkCollisionExit(Collision2D coll)
    {
        foreach (string str in collidableNames)
            if (coll.collider.name == str)
                return true;
        return false;
    }
}
