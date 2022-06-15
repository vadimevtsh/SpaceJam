using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class that is responsible for placing crystal into the ship
/// </summary>
public class YellowCrystall : Collidable
{
    public GameObject crystallPrefab;
    public GameObject miniMap;
    public GameObject iconToPickUp;
    public Item item;

    private readonly string _message = "You don't have any crystalls.";
    private readonly int _fontSize = 25;
    private float _cooldown = 3.0f;
    private Vector3 _posToSpawnText = new Vector3(-13.169f, -2.9f, -1);
    private float _lastShow;

    /// <summary>
    /// Method that places crystal into the ship.
    /// </summary>
    /// <param name="coll">Collision</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            if (!Inventory.instance.CheckItem("oxygenCrystall"))
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
                    iconToPickUp.SetActive(false);
                    Instantiate(Resources.Load<GameObject>("Prefabs/yellowCristal"), new Vector3(-13.169f, -2.95f, 0), Quaternion.identity);
                    // check wheter it is set or not
                    miniMap.SetActive(true);
                    //remove from inv
                    Inventory.instance.Remove(item);
                }
            }
        }
    }
}
