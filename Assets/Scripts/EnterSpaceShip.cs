using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSpaceShip : Collidable
{
    public GameObject iconToPickUp;
    public GameObject SpaceMan;

    public ExtinguishingFire barSlider;
    private bool _isFire = true; // was public
    public GameObject fire;

    private Vector3 _posToTeleport;

    private float _cooldown = 3.0f;
    private float _lastShow;
    private Vector3 _posToSpawnText = new Vector3(1.626f, 0.425f, -1);

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            iconToPickUp.SetActive(true);

            if (_isFire && Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e"))
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

            if (_isFire && !Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e") && (Time.time - _lastShow > _cooldown))
            {
                _lastShow = Time.time;
                GameManager.instance.ShowText("U don't have a firethrower", 20, Color.white, _posToSpawnText, Vector3.zero, _cooldown);
            }

            _posToTeleport = new Vector3(-12.996f, -3.699989f, -1f);

            if (Input.GetKeyDown("e") && _isFire == false)
            {
                SpaceMan.transform.position = _posToTeleport;
            }
        }
        
    }
}
