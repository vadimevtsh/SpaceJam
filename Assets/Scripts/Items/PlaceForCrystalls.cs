using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for placing crystal into the ship
/// </summary>
public class PlaceForCrystalls : Collidable
{
    public GameObject miniMap;
    public GameObject iconToPickUp;
    public Item yellowCrystall;
    public Item blackCrystall;
    public Item redCrystall;


    private readonly string _message = "You don't have any crystalls.";
    private readonly int _fontSize = 25;
    private float _cooldown = 3.0f;
    private Vector3 _posToSpawnText = new Vector3(-13.169f, -2.9f, -1);
    private float _lastShow;

    private bool _isYellowCrystall;
    private bool _isBlackCrystall;
    private bool _isRedCrystall;

    private void CheckCrystallsInInventory()
    {
        if (Inventory.instance.CheckItem("oxygenCrystall"))
            _isYellowCrystall = true;
        else
            _isYellowCrystall = false;

        if (Inventory.instance.CheckItem("blackCrystall"))
            _isBlackCrystall = true;
        else
            _isBlackCrystall = false;

        if (Inventory.instance.CheckItem("redCrystall"))
            _isRedCrystall = true;
        else
            _isRedCrystall = false;

    }

    /// <summary>
    /// Method that places crystalls into the ship.
    /// </summary>
    /// <param name="coll">Collision</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            CheckCrystallsInInventory();

            if (!_isYellowCrystall && !_isBlackCrystall && !_isRedCrystall)
            {
                if (Time.time - _lastShow > _cooldown && Input.GetKeyDown("e"))
                {
                    _lastShow = Time.time;
                    GameManager.instance.ShowText(_message, _fontSize, Color.red, _posToSpawnText, Vector3.zero, _cooldown);
                }
            }
            else
            {
                iconToPickUp.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    if (_isYellowCrystall)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/yellowCristal"), new Vector3(-13.2f, -2.95f, 0), Quaternion.identity);
                        _isYellowCrystall = false;
                        Inventory.instance.Remove(yellowCrystall);
                    }

                    else if (_isBlackCrystall)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/blackCristal"), new Vector3(-13.369f, -2.95f, 0), Quaternion.identity);
                        _isBlackCrystall = false;
                        Inventory.instance.Remove(blackCrystall);
                    }
                    else if (_isRedCrystall)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/redCristal"), new Vector3(-13.031f, -2.95f, 0), Quaternion.identity);
                        _isBlackCrystall = false;
                        Inventory.instance.Remove(redCrystall);
                    }
                    
                    iconToPickUp.SetActive(false);

                    // check wheter the minimap is set or not
                    if (!miniMap.activeSelf)
                        miniMap.SetActive(true);
                }
            }
        }
    }
}
