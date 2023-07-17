namespace DeadlyTest.Architecture
{
    public class PlayerInteractor : Interactor
    {
        private PlayerRepository repository;

        public int Score => this.repository.Score;

        public PlayerInteractor(PlayerRepository repository)
        {
            this.repository = repository;
            this.repository.Save();
        }

        public void AddScore(object sender, int score)
        {
            this.repository.Score += score;
            this.repository.Save();
        }
        public void ClearScore()
        {
            this.repository.Score = 0;
            this.repository.Save();
        }
    }
}