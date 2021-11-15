using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabulyasAndHospitals
{
    class Babulya
    {
        public string name;
        public byte age;
        public List<DiseasType> diseases = new List<DiseasType>();

        public Babulya(string name, byte age, List<DiseasType> DiseasesList)
        {
            this.name = name;
            this.age = age;
            diseases = DiseasesList;
        }

        public static Queue<Babulya> InputInfoAboutBabulyas()
        {
            Queue<Babulya> Babulyas = new Queue<Babulya>();
            Console.Write("Введите количество бабуль: ");
            ushort.TryParse(Console.ReadLine(), out ushort bab_num);
            for (int i = 0; i < bab_num; i++)
            {
                Console.Write("Введите имя бабули: ");
                string babulya_name = "";
                try
                {
                    babulya_name = Convert.ToString(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод.Введите строку!");
                }
                Console.Write("Введите возраст бабули: ");
                byte.TryParse(Console.ReadLine(), out byte babulya_age);
                Console.WriteLine("Выберите и введите болезни, которые есть у бабули из предложенного списка:");
                Console.WriteLine("Arthritis \nAlzheimers\nAtherosclerosis\nSenile dementia\nСoronary heart\nArterial hypertension\nHypoacusis");
                Console.WriteLine("Чтобы завершить выбор болезней введите exit!");
                List<DiseasType> BabulyasDis = new List<DiseasType>();
                bool flag = true;
                while (flag)
                {
                    string b_disease = Convert.ToString(Console.ReadLine()).ToLower();
                    switch (b_disease)
                    {
                        case "arthritis":
                            BabulyasDis.Add(DiseasType.Arthritis);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "alzheimers":
                            BabulyasDis.Add(DiseasType.Alzheimers);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "atherosclerosis":
                            BabulyasDis.Add(DiseasType.Atherosclerosis);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "senile dementia":
                            BabulyasDis.Add(DiseasType.Senile_dementia);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "coronary heart":
                            BabulyasDis.Add(DiseasType.Сoronary_heart);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "arterial hypertension":
                            BabulyasDis.Add(DiseasType.Arterial_hypertension);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "hypoacusis":
                            BabulyasDis.Add(DiseasType.Hypoacusis);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        default:
                            Console.WriteLine("Данной болезни нет в предложенном списке. Пожалуйста, введите болезнь из списка.");
                            break;
                        case "exit":
                            flag = false;
                            break;
                    }
                }
                Babulyas.Enqueue(new Babulya(babulya_name, babulya_age, BabulyasDis));
            }
            return Babulyas;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
