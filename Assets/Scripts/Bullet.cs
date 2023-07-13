using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Weapon weapon;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Действия при столкновении с объектом
        Debug.Log("Столкновение с объектом: " + collision.name);

        // Уничтожение пули после столкновения
        Destroy(gameObject);
    }
}

