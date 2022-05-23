using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSpaceShip : Collidable
{
    public GameObject iconToPickUp;
    public GameObject SpaceMan;

    public EstinguishingFire barSlider;
    public bool isFire = true;
    public GameObject fire;

    private Vector3 posToTeleport;

    private float cooldown = 3.0f;
    private float lastshow;
    private Vector3 posToSpawnAText = new Vector3(1.626f, 0.425f, -1);

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "spaceman")
        {
            iconToPickUp.SetActive(true);

            if (isFire && Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e"))
            {
                barSlider.gameObject.SetActive(true);
                barSlider.estinguishingFire();
                if (barSlider.slider.value <= 0)
                {
                    Destroy(fire);
                    isFire = false;
                    barSlider.gameObject.SetActive(false);
                }
            }

            if (isFire && !Inventory.instance.CheckItem("fireEstinguisher") && Input.GetKey("e") && (Time.time - lastshow > cooldown))
            {
                lastshow = Time.time;
                GameManager.instance.showText("U don't have a firethrower", 20, Color.white, posToSpawnAText, Vector3.zero, cooldown);
            }

            posToTeleport = new Vector3(-12.996f, -3.699989f, -1f);
            if (Input.GetKeyDown("e") && isFire == false)
            {
                SpaceMan.transform.position = posToTeleport;
            }
        }
        
    }
}
