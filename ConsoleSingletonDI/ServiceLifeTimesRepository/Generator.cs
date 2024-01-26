using ConsoleSingletonDI.Interface;

namespace ConsoleSingletonDI.ServiceLifeTimesRepository
{
    public class Generator : IGenerator
    {
        private int _counter;

        public Generator()
        {
            _counter = 0;
        }

        public int GenerateId()
        {
            return ++_counter;
        }

    }
}