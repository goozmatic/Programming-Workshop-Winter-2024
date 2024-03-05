using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTraits : MonoBehaviour
{
    public float Speed;
    public float DespawnTime;
    public bool HasPlayerSpawned;

    private void Start()
    {
        InvokeRepeating("LifetimeOut", DespawnTime, 0.0f);
    }

    void Update()
    {
        ProjectileMovement();
    }

    void ProjectileMovement()
    {
        if (HasPlayerSpawned)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        else if(!HasPlayerSpawned)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && HasPlayerSpawned)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && !HasPlayerSpawned)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void LifetimeOut()
    {
         Destroy(gameObject);
    }
}
