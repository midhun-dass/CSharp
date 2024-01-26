using ConsoleSingletonDI.Interface;

namespace ConsoleSingletonDI.ServiceLifeTimesRepository
{
    public class Consumer : IConsumer
    {
        private readonly IGenerator _generator;
        public Consumer(IGenerator generator)
        {
            _generator = generator;
        }

        public void DisplayNextId()
        {
            int nextId = _generator.GenerateId();
            Console.WriteLine($"Next ID: {nextId}");
        }
    }
}