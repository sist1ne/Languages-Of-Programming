using System;
using System.Xml.Serialization;

namespace lab7
{

    public struct Toy
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; }

        public Toy() {
            this.Name = "Мяч";
            this.Price = 10;
            this.MinAge = 0;
            this.MaxAge = 99;
        }

        public Toy (string? name, double price, uint minAge, uint maxAge)
        {
            this.Name = name;
            this.Price = price;
            this.MinAge = minAge;
            this.MaxAge = maxAge;
        }
    }

    public class Files
    {
        public static int MultiplyMaxAndMin(string fileName)
        {
            StreamReader file;
            string? line;
            int res;
            int number;
            int maxInt = int.MinValue;
            int minInt = int.MaxValue;

            try
            {
                file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    number = GetInt.check(line);
                    if (number > maxInt)
                    {
                        maxInt = number;
                    }
                    if (number < minInt)
                    {
                        minInt = number;
                    }
                }

                if (maxInt == int.MinValue || minInt == int.MaxValue)
                {
                    res = 0;
                }
                else res = maxInt * minInt;
            }
            catch
            {
                throw new Exception("Файл не найден или не открывается!\n");
            }

            file.Close();

            return res;
        }

        public static int AmountOfOddNums(string fileName)
        {
            StreamReader file;
            string? line;
            int number;
            int amount = 0;

            try
            {
                file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    number = GetInt.check(line);
                    if (number % 2 != 0)
                        amount++;
                }
            }
            catch
            {
                throw new Exception("Файл не найден или не открывается!\n");
            }
            file.Close();

            return amount;
        }

        public static void FileWithLenghts(string fileName, string newFileName)
        {
            newFileName = newFileName + ".txt";
            StreamReader file;
            StreamWriter newFile;
            string? line;

            try
            {
                file = new StreamReader(fileName);
                newFile = new StreamWriter(newFileName);
                while ((line = file.ReadLine()) != null)
                {
                    newFile.WriteLine(line.Length);
                }
            }
            catch
            {
                throw new Exception("Что-то пошло не так!\n");
            }
            file.Close();
            newFile.Close();
        }

        public static void FileWithStairs(string binFileName, string newBinFileName)
        {
            newBinFileName = newBinFileName + ".bin";
            FileStream file;
            BinaryReader binFile;
            BinaryWriter newBinFile;

            int num;
            string acc = "";

            try
            {
                file = new FileStream(newBinFileName, FileMode.Create);
                newBinFile = new BinaryWriter(file);
                binFile = new BinaryReader(File.Open(binFileName, FileMode.Open));

                while (binFile.BaseStream.Position < binFile.BaseStream.Length)
                {
                    num = binFile.ReadInt32();
                    acc += num.ToString();
                    newBinFile.Write(acc+"\n");
                }

                binFile.Close();
                newBinFile.Close();
            }
            catch
            {
                throw new Exception("Что-то пошло не так!\n");
            }
        }
        
        public static void ToysInBinFile(string binFileName, Toy[] toys)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            FileStream file;
            try
            {
                file = new FileStream(binFileName, FileMode.Create);
            }
            catch
            {
                throw new Exception("Что-то пошло не так!\n");
            }
            serializer.Serialize(file, toys);
            file.Close();
        }

        public static void ToysForSpecAge(string binFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            FileStream file;
            Toy[] toys;

            try
            {
                file = new FileStream(binFileName, FileMode.Open);
                toys = (Toy[])serializer.Deserialize(file);
            }
            catch
            {
                throw new Exception("Что-то пошло не так!\n");
            }

            Console.WriteLine("Игрушки для ребенка от 4 до 10 лет: ");
            for (int i = 0; i < toys.Length; i++)
            {
                if ((toys[i].MinAge <= 4 && toys[i].MaxAge >= 10))
                {
                    Console.WriteLine("-> " + toys[i].Name);
                }
            } 

            file.Close();
        }
    }
}