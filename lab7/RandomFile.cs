using System;

namespace lab7
{
    class FileRandom 
    {
        public static void generateRandomFile(string fileName)
        {
            StreamWriter newFile;
            
            try
            {
                newFile = new StreamWriter(fileName);
                Random randNum = new Random();

                for (int i = 0; i < 30; i++)
                {
                    newFile.Write(randNum.Next(-1000, 1000) + "\n");
                }
                newFile.Close();
            }
            catch {
                throw new Exception("Что-то пошло не так!\n");
            }
        }
    }
}