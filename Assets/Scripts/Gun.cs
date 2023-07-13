using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab; // ссылка на префаб пули
    public Weapon weapon;
    public Transform StartPoint; // ссылка на точку, откуда будет вылетать пуля
    private float rotate = 1f;
    private float ReloadTime;
    private float ShotTime;
    public int Bullets;
    public int BulletsMagazine;
    private bool isReloading;


    private void Start()
    {
        ShotTime = weapon.ShotTime;
        ReloadTime = weapon.ReloadTime;
        BulletsMagazine = weapon.BulletsCountMagazine;
        Bullets = weapon.BulletsCountAll;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotate = -1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotate = 1f;
        }

        if (Input.GetKey(KeyCode.R))
            isReloading = true;

        if (isReloading) 
            Reload();

        if (ShotTime <= 0 && !isReloading) 
        {
            if (Input.GetKey(KeyCode.H))
            {
                if (BulletsMagazine <= 0) isReloading = true;
                else 
                {
                    ShotTime = weapon.ShotTime;
                    BulletsMagazine--;
                    if (rotate == 1f)
                    {
                        GameObject Bullet = Instantiate(BulletPrefab, StartPoint.position, StartPoint.rotation);
                        Bullet.GetComponent<Rigidbody2D>().AddForce(StartPoint.right * weapon.Speed, ForceMode2D.Impulse);
                    }
                    else {

                        GameObject Bullet = Instantiate(BulletPrefab, StartPoint.position, StartPoint.rotation);
                        Bullet.GetComponent<Rigidbody2D>().AddForce(StartPoint.right * (-weapon.Speed), ForceMode2D.Impulse);
                    } 
                }
            } 
        }
        else ShotTime -= Time.deltaTime;
    }

    void Reload()
    {
        if (Bullets > 0)
            if (ReloadTime > 0) ReloadTime -= Time.deltaTime;
            else
            {
                Bullets += BulletsMagazine;
                ReloadTime = weapon.ReloadTime;
                if (Bullets > weapon.BulletsCountMagazine)
                    BulletsMagazine = weapon.BulletsCountMagazine;
                else
                    BulletsMagazine = Bullets;
                Bullets -= weapon.BulletsCountMagazine;
                isReloading = false;
            }
    }
}
