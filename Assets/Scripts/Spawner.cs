using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeadlyTest.Architecture
{
    public class Spawner : MonoBehaviour
    {
        public float timeBeforeSpawn;
        public float timePause, pause;
        public GameObject EnemyPrefab;
        public Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
            pause = timePause + timeBeforeSpawn;
        }

        // Update is called once per frame
        void Update()
        {
            if (timeBeforeSpawn <= 0) ShowSpawner();
            else timeBeforeSpawn -= Time.deltaTime;
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
