using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
    // Действия при столкновении с объектом
    Debug.Log("Столкновение с объектом: " + collision.gameObject.name);

    // Уничтожение пули после столкновения
    Destroy(gameObject);
    }
}

