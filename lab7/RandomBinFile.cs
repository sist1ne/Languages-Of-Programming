using System;

namespace lab7
{
    class BinFileRandom 
    {
        public static void generateRandomBinFile(string fileName)
        {
            FileStream newFile;
            BinaryWriter newBinFile;

            try
            {
                newFile = new FileStream(fileName, FileMode.Create);
                newBinFile = new BinaryWriter(newFile);
                
                Random randNum = new Random();

                for (int i = 0; i < 30; i++)
                {
                    newBinFile.Write(randNum.Next(-1000, 1000) + "\n");
                }
                newFile.Close();
            }
            catch {
                throw new Exception("Что-то пошло не так!\n");
            }
        }
    }
}