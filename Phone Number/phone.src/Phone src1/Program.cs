
namespace Create_Read_Update_Delete
{
    internal class Program
    {
        public static List<string> PhoneNumbers = new List<string>();
        public static void DataSeed()
        {

        }
        public static string Language = "uz";
        static void Main(string[] args)
        {
            ChooseLanguage();
            DataSeed();
            StartFrontEnd();
        }
        public static void ChooseLanguage()
        {
            Console.WriteLine("Choose Language : \n 1. Uzbek\n 2. English");
            Console.Write("Enter : ");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Language = "uz";
            }
            else
            {
                Language = "en";
            }
            Console.Clear();
        }
        public static void StartFrontEnd()
        {
            while (true)
            {
                Console.WriteLine(Language == "uz" ? "1 Raqam qo'shish : " : "1 Add number : ");
                Console.WriteLine(Language == "uz" ? "2 Raqam o'chirish : " : "2 Delete number : ");
                Console.WriteLine(Language == "uz" ? "3 Raqam yangilash : " : "3 Update number : ");
                Console.WriteLine(Language == "uz" ? "4 Raqamni ko'rsatish : " : "4 Read number : ");
                Console.Write(Language == "uz" ? "Tanlang : " : "Choose : ");

                var option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option == 1)
                {
                    Console.Write(Language == "uz" ? "Yangi raqamni kiriting : " : "Enter new number : ");
                    var newNumbers = Console.ReadLine();
                    newNumbers = AddPlusSign(newNumbers);
                    var index = AddNumber(newNumbers);

                    if (index == -1)
                    {
                        Console.WriteLine(Language == "uz" ? "raqam qo'shilmadi" : "Number not added");
                    }
                    else
                    {
                        Console.WriteLine(Language == "uz" ? "raqam qo'shildi" : "new phone number added");
                    }

                }
                else if (option == 2)
                {
                    Console.Write(Language == "uz" ? "O'chirmoqchi bo'lgan raqamni kiriting : " : "Enter delete number : ");
                    var PhoneNumbers = Console.ReadLine();
                    PhoneNumbers = AddPlusSign(PhoneNumbers);
                    var boolResponse = DeleteNumber(PhoneNumbers);

                    if (boolResponse is true)
                    {
                        Console.WriteLine(Language == "uz" ? "Muavvafaqiyatli, raqam o'chirildi" : "Succsesfuly, number deleted");
                    }

                    else
                    {
                        Console.WriteLine(Language == "uz" ? "Xatolik , raqam o'chirilmadi" : "Error , number not deleted");
                    }
                }
                else if (option == 3)
                {
                    Console.Write(Language == "uz" ? "Eski raqamni kiriting : " : "Enter old number : ");
                    var oldNumber = Console.ReadLine();
                    Console.Write(Language == "uz" ? "Yangi raqamni kiriting : " : "Enter new number : ");
                    var newNumber = Console.ReadLine();

                    var boolResponse = UpdatePhoneNumber(oldNumber, newNumber);


                    if (boolResponse is true)
                    {
                        Console.WriteLine(Language == "uz" ? "Muavvafaqiyatli raqam yangilandi" : "Succsesfuly, new number updated");
                    }
                    else
                    {
                        Console.WriteLine(Language == "uz" ? "Xatolik , raqam yangilanmadi" : "Error , new number not updated");
                    }
                }
                else if (option == 4)
                {
                    Console.WriteLine(Language == "uz" ? "Telefon raqamlar : " : "Phone numbers : ");
                    var number = GetPhoneNumbers();
                    foreach (var phoneNumber in number)
                    {
                        Console.WriteLine(phoneNumber);
                    }

                }
            }
        }
        public static int AddNumber(string number)
        {
            var exists = PhoneNumbers.Contains(number);
            var IsValidFormat = CheckNumberFormat(number);
            if (exists is true || IsValidFormat is false)
            {
                return -1;
            }

            PhoneNumbers.Add(number);
            return PhoneNumbers.Count - 1;
        }
        public static bool DeleteNumber(string number)
        {
            var exists = PhoneNumbers.Contains(number);
            PhoneNumbers.Remove(number);
            return exists;
        }
        public static bool UpdatePhoneNumber(string oldNumber, string newNumber)
        {
            var index = PhoneNumbers.IndexOf(oldNumber);
            var boolResponse = true;
            if (index >= 0)
            {
                PhoneNumbers[index] = newNumber;
                boolResponse = true;
            }
            return boolResponse;
        }
        public static List<string> GetPhoneNumbers()
        {
            return PhoneNumbers;
        }

        public static string AddPlusSign(string phoneNumber)
        {
            if (!phoneNumber.StartsWith("+"))
            {
                return "+" + phoneNumber;
            }
            return phoneNumber;
        }
        public static bool CheckNumberFormat(string number)
        {

            for (int i = 1; i < number.Length; i++)
            {
                if (char.IsDigit(number[i]))
                {
                    return true;
                }
                if (number.Length == 12)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

