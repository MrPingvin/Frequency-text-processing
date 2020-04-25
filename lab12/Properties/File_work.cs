using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public class File_work
{
    private String file_name;
    private Dictionary<int, Word> all_word;

    public File_work() { }
    public File_work(String _file, char[] config)
    {
        file_name = _file;
        Dictionary<int, Word> words_from_file = new Dictionary<int, Word>();
        try
        {
            using (StreamReader sr = new StreamReader(file_name))
            {
                String line = sr.ReadLine();
                do
                {
                    foreach (char _el_replace in config)
                        line = line.Replace(_el_replace, ' ');

                    String[] _words = line.Split(' ');
                    foreach (string word in _words)
                    {
                        if (word != "")
                        {
                            String lower_word = word.ToLower();
                            if (words_from_file.Count == 0)
                                words_from_file.Add(lower_word.GetHashCode(), new Word(lower_word));
                            else
                            {
                                if (words_from_file.TryGetValue(lower_word.GetHashCode(), out Word chek))
                                    words_from_file[lower_word.GetHashCode()].Inc();
                                else
                                    words_from_file.Add(lower_word.GetHashCode(), new Word(lower_word));
                            }
                        }
                    }
                    line = sr.ReadLine();
                } while (line != null);
            }
            all_word = words_from_file;
        }
        catch (NullReferenceException ref_exp)
        {
            Console.WriteLine(ref_exp.Message + ". Файл пуст");
        }
        catch (FileNotFoundException file_exp)
        {
            Console.WriteLine(file_exp.Message);
        }
    }

    public void Print_max_value()
    {
        try
        {
            Console.WriteLine("Самое большое количество раз встречается слово '" +
                (from x in all_word where x.Value.Try_Count == all_word.Max(v => v.Value.Try_Count) select x).First().Value.Try_Word + "' - " +
                (from x in all_word where x.Value.Try_Count == all_word.Max(v => v.Value.Try_Count) select x).First().Value.Try_Count);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("В файле нет слов.");
        }
    }

    public void Print_all_values()
    {
        try
        {
            foreach (KeyValuePair<int, Word> _word in all_word)
                Console.WriteLine(_word.Value.Try_Word + " " + _word.Value.Try_Count);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("В файле нет слов.");
        }
    }

    public void Statistic_word(String _word)
    {
        try
        {
            if (all_word.TryGetValue(_word.GetHashCode(), out Word find_word))
            {
                Console.WriteLine(find_word.Try_Word + " " + find_word.Try_Count);
            }
            else
            {
                Console.WriteLine("Такого слова нет в файле");
            }
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine("В файле нет слов.");
        }
    }

    public void Statistic_word()
    {
        Console.Write("Введите слово для поиска : ");
        String _word = Console.ReadLine();
        try
        {
            if (all_word.TryGetValue(_word.GetHashCode(), out Word find_word))
            {
                Console.WriteLine(find_word.Try_Word + " " + find_word.Try_Count);
            }
            else
            {
                Console.WriteLine("Такого слова нет в файле");
            }
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("В файле нет слов.");
        }
    }
}

