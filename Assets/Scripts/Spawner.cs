using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeadlyTest.Architecture
{
    public class Spawner : MonoBehaviour
    {
        public float timeSleep;
        public float timePause, pause;
        public GameObject EnemyPrefab;
        public Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
            pause = timePause;
        }

        // Update is called once per frame
        void Update()
        {
            if (timeSleep <= 0) ShowSpawner();
            else timeSleep -= Time.deltaTime;
            spawnEnemies();
        }

        void ShowSpawner()
        {
            anim.Play("spawn");
        }

        void spawnEnemies()
        {
            if (pause <= 0)
            {
                Instantiate(EnemyPrefab, transform.position, transform.rotation);
                pause = timePause;
            }
            else
                pause -= Time.deltaTime;
        }
    }
}
