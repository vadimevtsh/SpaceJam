using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is a class that represents entering the ship.
/// </summary>
public class EnterSpaceShip : Collidable
{
    public GameObject iconToPickUp;
    public GameObject SpaceMan;

    public ExtinguishingFire barSlider;
    private bool _isFire = true; 
    public GameObject fire;

    private Vector3 _posToTeleport; // coordinates to teleport to after entering the ship

    private float _cooldown = 3.0f;
    private float _lastShow;
    private Vector3 _posToSpawnText = new Vector3(1.626f, 0.425f, -1); // coordinates to show message to after extinguishing the fire

    /// <summary>
    /// Method that represents extinguishing fire.
    /// </summary>
    private void ExtinguishFire()
    {
        barSlider.gameObject.SetActive(true);
        barSlider.ExtinguishingOccurredFire();

        if (barSlider.slider.value <= 0)
        {
            Destroy(fire);
            _isFire = false;
            barSlider.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Method that represents showing message, when you don't have a firethrower.
    /// </summary>
    private void ShowMessage()
    {
        _lastShow = Time.time;
        GameManager.instance.ShowText("U don't have a firethrower", 20, Color.white, _posToSpawnText, Vector3.zero, _cooldown);
    }

    /// <summary>
    /// Method that represents collision with the ship.
    /// </summary>
    /// <param name="coll">Collider.</param>
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            iconToPickUp.SetActive(true);

            if (_isFire && Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e"))
            {
                // function for extinguishing fire
                ExtinguishFire();
            }
            // if you dont have fireextinguisher
            if (_isFire && !Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e") && (Time.time - _lastShow > _cooldown))
            {
                ShowMessage();
            }

            _posToTeleport = new Vector3(-12.996f, -3.699989f, -1f);

            if (Input.GetKeyDown("e") && _isFire == false)
            {
                SpaceMan.transform.position = _posToTeleport;
            }
        }
        
    }
}
