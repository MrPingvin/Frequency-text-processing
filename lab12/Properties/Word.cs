using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


public class Word : IComparable<Word>
{
    private int word_count { get; set; } = 1;
    private String word_ { get; set; }
    

    public Word(){}
    public Word(String word)
    {
        word_ = word;
    }

    public int CompareTo(Word other)
    {
        if (other == null) return 1;

        return word_.CompareTo(other.word_);
    }

    public void Inc()
    {
        word_count++;
    }

    public int Try_Count
    {
        get
        {
            return word_count;
        }

        set
        {
            this.word_count = value;
        }

    }

    public String Try_Word
    {
        get
        {
            return word_;
        }
        set
        {
            this.word_ = value;
        }
    }
}

