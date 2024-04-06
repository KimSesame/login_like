using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCharacters : MonoBehaviour
{
    public float health = 50;
    public float shield = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Monster hit(-{damage})! ({health})");

        if (health <= 0)
        {
            Debug.Log("Monster died!");
            Destroy(gameObject);
        }
    }
}
