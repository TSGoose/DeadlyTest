using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeadlyTest.Architecture
{
    public class DeadScreen : MonoBehaviour
    {
        private int player_score;
        public Text text_score;

        private PlayerRepository playerRepository;
        public PlayerInteractor playerInteractor;

        void Start()
        {
            this.playerRepository = new PlayerRepository();
            this.playerRepository.Initialize();

            this.playerInteractor = new PlayerInteractor(this.playerRepository);

            player_score = this.playerRepository.Score;
            text_score.text = player_score.ToString();

        }

        void Update()
        {

        }

        public void StartButtonClick()
        {
            Scenes.OpenGame();
        }

        public void MenuButtonClick()
        {
            Scenes.OpenMenu();
        }
    }
}