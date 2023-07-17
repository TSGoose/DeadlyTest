using UnityEngine;

namespace DeadlyTest.Architecture 
{
    public class PlayerRepository : Repository
    {

        private const string KEY = "PLAYER_KEY";
        public int Score { get; set; }
        public override void Initialize()
        {
            this.Score = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, this.Score);
        }
    }
}