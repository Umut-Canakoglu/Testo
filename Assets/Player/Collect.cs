using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int score;
    private Rigidbody2D rb;
    private Transform transform;
    public LayerMask itemLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    void Update() {
        Collider2D[] itemColliders = Physics2D.OverlapBoxAll(rb.position, transform.localScale*4, rb.rotation, itemLayer);
        if (Input.GetKeyDown(KeyCode.E) && itemColliders.Length > 0)
        {
            foreach(Collider2D itemCollider in itemColliders)
            {
                string nameOf = itemCollider.gameObject.name;
                if (nameOf == "Dumble")
                {
                    itemCollider.gameObject.GetComponent<DumbleEffect>().SlowDown();
                } else if (nameOf == "Lamb")
                {
                    itemCollider.gameObject.GetComponent<LambEffect>().FieldOfView();
                }else if (nameOf == "Clock")
                {
                    itemCollider.gameObject.GetComponent<ClockEffect>().TimeSlow();
                }else if (nameOf == "Painting")
                {
                    itemCollider.gameObject.GetComponent<PaintingEffect>().PositionSwitch();
                }else if (nameOf == "Shades")
                {
                    itemCollider.gameObject.GetComponent<ShadeEffect>().StainsOnScreen();
                }else if (nameOf == "Duck")
                {
                    itemCollider.gameObject.GetComponent<DuckEffect>().AnnoyingSound();
                }else if (nameOf == "Sock")
                {
                    itemCollider.gameObject.GetComponent<SockEffect>().SockMonsterSpawn();
                }else if (nameOf == "Cup")
                {
                    itemCollider.gameObject.GetComponent<CupEffect>().TrapsSpawn();
                }else if (nameOf == "Book")
                {
                    itemCollider.gameObject.GetComponent<BookEffect>().WriteText();
                }else if (nameOf == "Cube")
                {
                    itemCollider.gameObject.GetComponent<CubesEffect>().CubeMonsterSpawn();
                }else if (nameOf == "Hat")
                {
                    itemCollider.gameObject.GetComponent<HatEffect>().ControlChange();
                }else if (nameOf == "TeddyBear")
                {
                    itemCollider.gameObject.GetComponent<TeddyBearEffect>().TeddyBearMonsterSpawn();
                }
            }
        }

    }
}
