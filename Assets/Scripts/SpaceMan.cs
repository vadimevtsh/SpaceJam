using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMan : MonoBehaviour
{
    private Vector3 _moveDelta;
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _hit;

    public Vector2 moveSpeed;

    public O2Bar myBar;
    public float maxOxygen;
    public float currentOxygen;
    public float defaultOxygenRaiseDown;

    private string[] _collidableNames = new string[6] { "bottleFloor", "EnterSpaceShip", "QuitSpaceShip", "ToMaxOxygen", "fireKillerInSnow", "yellowCristal" };
    public GameObject myText;

    void Start()
    {
        defaultOxygenRaiseDown = 5;
        maxOxygen = 100;
        currentOxygen = maxOxygen;
        myBar.SetMaxOxygen(maxOxygen);

        moveSpeed = new Vector2(0.9f, 0.9f);
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _moveDelta = new Vector3(x, y, 0);

        if (_moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime * moveSpeed.y), LayerMask.GetMask("Actor", "Blocking"));

        if (_hit.collider == null)
        {
            transform.Translate(0, _moveDelta.y * Time.deltaTime * moveSpeed.y, 0);
        }

        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime * moveSpeed.x), LayerMask.GetMask("Actor", "Blocking"));

        if (_hit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime * moveSpeed.x, 0, 0);
        }

        ChangeLevelOfOxygen();
    }

    private void ChangeLevelOfOxygen()
    {
        if (currentOxygen >= maxOxygen)
            currentOxygen = 100;
        currentOxygen -= defaultOxygenRaiseDown * Time.deltaTime;
        myBar.SetOxygen(currentOxygen);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (CheckCollisionExit(other))
        {
            myText.SetActive(false);
            if (other.collider.name == "QuitSpaceShip")
            {
                myText.SetActive(false);
                defaultOxygenRaiseDown = 5; 
            }
        }
        
    }

    private bool CheckCollisionExit(Collision2D coll)
    {
        foreach (string str in _collidableNames)
            if (coll.collider.name == str)
                return true;
        return false;
    }
}
