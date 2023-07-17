using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

namespace DeadlyTest.Architecture
{
    public class GameInterface : MonoBehaviour
    {
        private PlayerRepository playerRepository;
        public PlayerInteractor playerInteractor;


        public Player player;
        private Gun gun;
        public GameObject line_hp;
        public GameObject left_hp;
        public GameObject right_hp;
        public GameObject line_bullets;
        public GameObject left_bullets;
        public GameObject right_bullets;
        public GameObject bullets_null;
        private int hp;
        private int max_hp;
        private int bullets;
        private int max_bullets;
        private float size;
        private float positionX;
        private float positionX_right;
        private float positionX_bullets;
        private float positionX_bullets_right;

        public int player_score;

        void Start()
        {
            this.playerRepository = new PlayerRepository();
            this.playerRepository.Initialize();

            this.playerInteractor = new PlayerInteractor(this.playerRepository);
            this.playerInteractor.Initialize();
            gun = player.gun;
            max_hp = player.max_hp;
            max_bullets = gun.weapon.BulletsCountMagazine;
            size = line_hp.transform.localScale.x;
            positionX = line_hp.transform.localPosition.x;
            positionX_right = right_hp.transform.localPosition.x;
            positionX_bullets = line_bullets.transform.localPosition.x;
            positionX_bullets_right = right_bullets.transform.localPosition.x;
            player_score = this.playerRepository.Score;
        }

        void Update()
        {
            player_score = this.playerRepository.Score;
            hp = player.hp;
            bullets = gun.BulletsMagazine;
            SetHp();
            SetBullets();
        }

        void SetHp()
        {
            if (max_hp > 0)
            {
                line_hp.transform.localScale = new Vector2((float)hp / max_hp * size, line_hp.transform.localScale.y);
                line_hp.transform.localPosition = new Vector2(positionX - (1 - (float)hp / max_hp) * line_hp.GetComponent<RectTransform>().sizeDelta.x / 2, line_hp.transform.localPosition.y);
                right_hp.transform.localPosition = new Vector2(positionX_right - (1 - (float)hp / max_hp) * line_hp.GetComponent<RectTransform>().sizeDelta.x, line_hp.transform.localPosition.y);
            }
        }

        void SetBullets()
        {
            if (bullets > 0)
            {
                bullets_null.SetActive(false);
                line_bullets.transform.localScale = new Vector2((float)bullets / max_bullets * size, line_bullets.transform.localScale.y);
                line_bullets.transform.localPosition = new Vector2(positionX_bullets - (1 - (float)bullets / max_bullets) * line_bullets.GetComponent<RectTransform>().sizeDelta.x / 2, line_bullets.transform.localPosition.y);
                right_bullets.transform.localPosition = new Vector2(positionX_bullets_right - (1 - (float)bullets / max_bullets) * line_bullets.GetComponent<RectTransform>().sizeDelta.x, line_bullets.transform.localPosition.y);
            }
            else
            {
                bullets_null.SetActive(true);
            }
        }

        public void IncreaseScore(int count)
        {
            player_score += count;
        }
    }
}