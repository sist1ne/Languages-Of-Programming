using lab7;
using System;

namespace lab7
{
    public class Hash
    {
        public static void WhoHaveReadTheBook
            (
            string fileName,
            string[] books,
            out HashSet<string> allHaveRead,
            out HashSet<string> someHaveRead,
            out HashSet<string> noneHaveRead
            )
        {
            HashSet<string[]> readers = new HashSet<string[]>();
            StreamReader file;
            try
            {
                string? line;
                file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    readers.Add(words);
                }
                allHaveRead = new HashSet<string>();
                someHaveRead = new HashSet<string>();
                noneHaveRead = new HashSet<string>(books);

                foreach (string book in books)
                {
                    int counter = 0;
                    foreach (string[] readerBooks in readers)
                    {
                        if (readerBooks.Contains(book))
                            counter++;
                    }

                    if (counter == readers.Count)
                    {
                        noneHaveRead.Remove(book);
                        allHaveRead.Add(book);
                    }
                    else if (counter > 0)
                    {
                        noneHaveRead.Remove(book);
                        someHaveRead.Add(book);
                    }
                }
            }
            catch
            {
                throw new Exception("Файл не открылся.\n");
            }
        }
        
        public static HashSet<char> SymbolsFromAllWordsExceptFirst(string fileName)
        {
            HashSet<string> words = new HashSet<string>();
            HashSet<char> symbols = new HashSet<char>();
            HashSet<char> bannedSymbols = new HashSet<char>();

            StreamReader file;
            try
            {  
                string? line;
                file = new StreamReader(fileName);

                while ((line = file.ReadLine()) != null)
                {
                    string[] sentence = line.Split(" ");
                    foreach(string word in sentence)
                    {
                        words.Add(word);
                    }
                }

                string firstWord = words.First();
                words.Remove(firstWord);
                foreach (char letter in firstWord)
                {
                    bannedSymbols.Add(letter);
                }
                
                string secondWord = words.First();
                words.Remove(secondWord);
                foreach (char letter in secondWord)
                {
                    symbols.Add(letter);
                }

                foreach (string word in words)
                {
                    char[] wordLetters = word.ToCharArray();
                    foreach (char letter in symbols)
                    {
                        if (!bannedSymbols.Contains(letter))
                        {
                            if (!wordLetters.Contains(letter))
                            {
                                symbols.Remove(letter);
                            }
                        }
                        else symbols.Remove(letter);
                    }
                }
                file.Close();

                return symbols;
            }
            catch
            {
                throw new Exception("Файл не открылся.\n");
            }
        }
    }
}