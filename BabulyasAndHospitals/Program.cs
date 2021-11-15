using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabulyasAndHospitals
{
    class Program
    {
        static void PutInHospital(Queue<Babulya> Babulyas, Stack<Hospital> hospitals)
        {
            while (Babulyas.Count != 0)
            {
                Babulya babulya = Babulyas.Dequeue();
                bool flag = false;
                foreach (Hospital H in hospitals)
                {
                    flag = H.CanAddBabulya(babulya);
                    if (flag)
                    {
                        Console.WriteLine("Бабуля " + babulya + " попала в больницу " + H.ID);
                        break;
                    }
                }
                if (!flag)
                    Console.WriteLine("Бабуля " + babulya + " осталась на улице плакать");
            }

        }
        static void Main(string[] args)
        {
            Queue<Babulya> Babulyas = Babulya.InputInfoAboutBabulyas();
            Stack<Hospital> Hospitals = Hospital.InputInfoAboutHospital();
            PutInHospital(Babulyas, Hospitals);
            foreach (Babulya B in Babulyas)
            {
                Console.WriteLine(B);
            }
            foreach (Hospital H in Hospitals)
            {
                Console.WriteLine(H);
            }
        }
    }
}
