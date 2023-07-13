using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public GameObject BulletPrefab; // ссылка на префаб пули
    public Transform StartPoint; // ссылка на точку, откуда будет вылетать пуля
    public float vel = 7f; // сила выстрела
    public float rotate = 1f;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotate = -1f;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            rotate = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (rotate == 1f)
            {
                GameObject Bullet = Instantiate(BulletPrefab, StartPoint.position, StartPoint.rotation);
                Bullet.GetComponent<Rigidbody2D>().AddForce(StartPoint.right * vel, ForceMode2D.Impulse);
            }
            else{
                
                GameObject Bullet = Instantiate(BulletPrefab, StartPoint.position, StartPoint.rotation);
                Bullet.GetComponent<Rigidbody2D>().AddForce(StartPoint.right * (-vel), ForceMode2D.Impulse);
            }
        }
    }
}
