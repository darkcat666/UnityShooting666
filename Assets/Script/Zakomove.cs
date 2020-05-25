using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zakomove : MonoBehaviour
{
    private Rigidbody2D rigidbody2_2;

    private void Start()
    {
        rigidbody2_2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Zako_move", 2.0f, 1);
    }

    public void Zako_A1Shoot()
    {
        rigidbody2_2.AddForce(new Vector2(0, 0.4f), ForceMode2D.Impulse);
    }

    public void Zako_move()
    {
        transform.Translate(0, -0.1f, 0);
    }
}
