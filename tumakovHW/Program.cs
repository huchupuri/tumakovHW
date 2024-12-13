using System;
using tumakovHW;
namespace zhk
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<Resident> stackToZina = new Stack<Resident>();
            List<Queue<Resident>> windows = new List<Queue<Resident>>
        {
            new Queue<Resident>(), // Первое окно: проблемы с отоплением
            new Queue<Resident>(), // Второе окно: проблемы с оплатой
            new Queue<Resident>()  // Третье окно: все остальные
        };

            // Добавим нескольких жителей в стек к Зине
            stackToZina.Push(new Resident("Иван Иванов", "12 3456",
                new Problem { Number = 1, Description = "Отопление не работает" }, new Temperament { Scandalousness = 6, Intelligence = 1 }));

            stackToZina.Push(new Resident("Мария Петрова", "65 4321",
                new Problem { Number = 2, Description = "Ошибка в оплате" }, new Temperament { Scandalousness = 3, Intelligence = 1 }));

            stackToZina.Push(new Resident("Сергей Сидоров", "12 09789",
                new Problem { Number = 3, Description = "Вопрос по договору" }, new Temperament { Scandalousness = 8, Intelligence = 0 }));

            
            while (stackToZina.Count > 0)
            {
                Resident resident = stackToZina.Pop();

                int windowIndex;
                if (resident.temperament.Intelligence == 0)
                {
                    Random random = new Random();
                    windowIndex = random.Next(0, 3);
                }
                else
                {
                    switch (resident.problem.Number)
                    {
                        case 1:
                            windowIndex = 0;
                            break;
                        case 2:
                            windowIndex = 1;
                            break;
                        default:
                            windowIndex = 2;
                            break;
                    }
                }

                if (resident.temperament.Scandalousness >= 5)
                {
                    int skips;
                    do
                    {
                        Console.WriteLine($"{resident.name} скандалист. Сколько человек он обгоняет?");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out skips) && skips < windows.Count));

                    Queue<Resident> tempQueue = new Queue<Resident>();
                    for (int i = 0; i < skips && windows[windowIndex].Count > 0; i++)
                    {
                        tempQueue.Enqueue(windows[windowIndex].Dequeue());
                    }
                    windows[windowIndex].Enqueue(resident);
                    while (tempQueue.Count > 0)
                    {
                        windows[windowIndex].Enqueue(tempQueue.Dequeue());
                    }
                }
                else
                {
                    windows[windowIndex].Enqueue(resident);
                }
            }

            for (int i = 0; i < windows.Count; i++)
            {
                Console.WriteLine($"Окно {i + 1}:");
                foreach (var resident in windows[i])
                {
                    Console.WriteLine($"{resident.name} с проблемой: {resident.problem.Description}");
                }
            }
        }
    }
}
