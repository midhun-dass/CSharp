namespace ConsoleSingletonDI.Singleton
{
    public class Singleton
    {
        private static Singleton? instance;
        public int counter = 100;

        private Singleton()
        {
            ++counter;
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}