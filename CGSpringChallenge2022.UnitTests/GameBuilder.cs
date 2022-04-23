namespace CGSpringChallenge2022.UnitTests
{
    public class GameBuilder
    {
        public const int TEST_BASE_X = 5;
        public const int TEST_BASE_Y = 10;
        public const int TEST_HERO_COUNT = 3;

        private int _x;
        private int _y;

        public GameBuilder()
        {
            _x = TEST_BASE_X;
            _y = TEST_BASE_Y;
        }

        public void WithPosition(int x, int y) => (_x, _y) = (x, y);

        public Game Build()
        {
            string[] data = $"{_x} {_y}".Split(' ');
            return new Game(data, TEST_HERO_COUNT);
        }
    }
}
