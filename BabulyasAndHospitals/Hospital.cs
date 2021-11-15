using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabulyasAndHospitals
{
    class Hospital
    {
        public ushort ID;
        public List<DiseasType> Diseases = new List<DiseasType>();
        public ushort Size;
        public List<Babulya> Patients;
        public Hospital(ushort HospitalID, List<DiseasType> DiseasesList, ushort HospitalSize)
        {
            ID = HospitalID;
            Diseases = DiseasesList;
            Size = HospitalSize;
            Patients = new List<Babulya>(Size);
        }
        public override string ToString()
        {
            string result = ID.ToString() + " ";
            foreach (DiseasType Disease in Diseases)
            {
                result += Disease + " ";
            }
            result += "Заполненность больницы " + Patients.Count + " ";
            if (Size != 0)
                result += 100 * (Convert.ToDouble(Patients.Count) / Convert.ToDouble(Size)) + "%";
            else result += "В больнице нет мест";
            return result;
        }

        public static Stack<Hospital> InputInfoAboutHospital()
        {
            Stack<Hospital> Hospitals = new Stack<Hospital>();
            Console.Write("Введите количество больниц: ");
            ushort.TryParse(Console.ReadLine(), out ushort hospital_num);
            for (int i = 0; i < hospital_num; i++)
            {
                Console.Write("Введите ID больницы:");
                ushort.TryParse(Console.ReadLine(), out ushort hospital_id);
                Console.WriteLine("Выберите и введите болезни, которые лечатся в данной больнице из предложенного списка:");
                Console.WriteLine("Arthritis \nAlzheimers\nAtherosclerosis\nSenile dementia\nСoronary heart\nArterial hypertension\nHypoacusis");
                Console.WriteLine("Чтобы завершить выбор болезней введите exit!");
                List<DiseasType> HospitalDis = new List<DiseasType>();
                bool flag = true;
                while (flag)
                {
                    string disease = Convert.ToString(Console.ReadLine()).ToLower();
                    switch (disease)
                    {
                        case "arthritis":
                            HospitalDis.Add(DiseasType.Arthritis);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "alzheimers":
                            HospitalDis.Add(DiseasType.Alzheimers);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "atherosclerosis":
                            HospitalDis.Add(DiseasType.Atherosclerosis);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "senile dementia":
                            HospitalDis.Add(DiseasType.Senile_dementia);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "coronary heart":
                            HospitalDis.Add(DiseasType.Сoronary_heart);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "arterial hypertension":
                            HospitalDis.Add(DiseasType.Arterial_hypertension);
                            Console.WriteLine("Болезнь успешно добавлена в список!");
                            break;
                        case "hypoacusis":
                            HospitalDis.Add(DiseasType.Hypoacusis);
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
                Console.Write("Введите вместимость больницы:");
                ushort.TryParse(Console.ReadLine(), out ushort hospital_size);
                Hospitals.Push(new Hospital(hospital_id, HospitalDis, hospital_size));
            }
            return Hospitals;
        }

        public bool CanAddBabulya(Babulya patient)
        {
            if (Patients.Count >= Size)
            {
                return false;
            }
            else
            {
                if (patient.diseases.Count > 0)
                {
                    int numberGrannyDiseases = 0;
                    foreach (DiseasType disease in Diseases)
                    {
                        foreach (DiseasType grannyDisease in patient.diseases)
                        {
                            if (grannyDisease == disease)
                            {
                                numberGrannyDiseases++;
                            }
                        }
                    }
                    double part = (double)numberGrannyDiseases / (double)patient.diseases.Count;
                    if (part > 0.5)
                    {
                        Patients.Add(patient);
                        return true;
                    }
                    else return false;
                }
                else
                {
                    Patients.Add(patient);
                    return true;
                }
            }
        }
    }
}
