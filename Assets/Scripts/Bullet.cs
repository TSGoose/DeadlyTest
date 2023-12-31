using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

namespace DeadlyTest.Architecture
{
    public class Bullet : MonoBehaviour
    {

        public Weapon weapon;
        public float checkRadius = 0.5f;
        public LayerMask Enemy;

        void OnTriggerEnter2D(Collider2D collision)
        {
            
            //hitInfo = Physics2D.Raycast(transform.position, transform.up, checkRadius, Enemy);
            //collision.gameObject.GetComponent<Player>().TakeDamage(weapon.Damage);
            if (collision != null)
            {
                Destroy(gameObject);
                if (collision.CompareTag("Enemy"))
                    collision.GetComponent<Enemy>().TakeDamage(weapon.Damage);
            }
           
        }
    }
}

