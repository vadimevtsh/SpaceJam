using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that is responsible for the main character.
/// </summary>
public class SpaceMan : MonoBehaviour
{
    private Vector3 _moveDelta;
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _hit;
    public GameObject iconToPickUp;

    private Vector2 _moveSpeed;

    public O2Bar myBar;

    private float _maxOxygen;
    private float _currentOxygen;
    private float _defaultOxygenRaiseDown;

    private string[] _collidableNames = new string[8] { "bottleFloor", "EnterSpaceShip", "QuitSpaceShip", "ToMaxOxygen", "fireKillerInSnow", "yellowCristal", "blackCristal", "redCristal" }; // list of strings put in another class

    public float MaxOxygen
    {
        get => _maxOxygen;

        set => _maxOxygen = value;
    }

    public float CurrentOxygen
    {
        get => _currentOxygen;

        set => _currentOxygen = value;
    }

    public float DefaultOxygenRaiseDown
    {
        get => _defaultOxygenRaiseDown;

        set => _defaultOxygenRaiseDown = value;
    }
    void Start()
    {
        _defaultOxygenRaiseDown = 5;
        _maxOxygen = 100;
        _currentOxygen = _maxOxygen;
        myBar.SetMaxOxygen(_maxOxygen);

        _moveSpeed = new Vector2(0.9f, 0.9f);
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
            Mathf.Abs(_moveDelta.y * Time.deltaTime * _moveSpeed.y), LayerMask.GetMask("Actor", "Blocking"));

        if (_hit.collider == null)
        {
            transform.Translate(0, _moveDelta.y * Time.deltaTime * _moveSpeed.y, 0);
        }

        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime * _moveSpeed.x), LayerMask.GetMask("Actor", "Blocking"));

        if (_hit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime * _moveSpeed.x, 0, 0);
        }

        ChangeLevelOfOxygen();
    }

    /// <summary>
    /// Method that changes the oxygen level.
    /// </summary>
    private void ChangeLevelOfOxygen()
    {
        if (_currentOxygen >= _maxOxygen)
            _currentOxygen = 100;
        _currentOxygen -= _defaultOxygenRaiseDown * Time.deltaTime;
        myBar.SetOxygen(_currentOxygen);
    }

    /// <summary>
    /// Method that sets oxygen raise down back to normal when character leaves the ship.
    /// </summary>
    /// <param name="other">Collider</param>
    private void OnCollisionExit2D(Collision2D other)
    {
        if (CheckCollisionExit(other))
        {
            iconToPickUp.SetActive(false);
            if (other.collider.name == "QuitSpaceShip")
            {
                iconToPickUp.SetActive(false);
                _defaultOxygenRaiseDown = 5;
            }
        }

    }
    /// <summary>
    /// Method that checks if collision happens with one of the items
    /// </summary>
    /// <param name="coll">Collider</param>
    /// <returns></returns>
    private bool CheckCollisionExit(Collision2D coll)
    {
        foreach (string str in _collidableNames)
            if (coll.collider.name == str)
                return true;
        return false;
    }
}
