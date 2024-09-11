public class Tekst
{
    public List<Woord> Woorden { get; set; }
    public BestandInfo BestandInfo { get; set; }

    public Tekst(List<Woord> woorden, BestandInfo bestandInfo)
    {
        Woorden = woorden;
        BestandInfo = bestandInfo;
    }

    // Returns the list of words in the text.
    public List<Woord> GetWoorden()
    {
        return Woorden;
    }

    // Reverses the order of the words in the text.
    public void DraaiOm()
    {
        Woorden.Reverse();
    }

    // Finds and returns all palindromes in the text.
    public List<Woord> Palindromen()
    {
        List<Woord> palindromen = new List<Woord>();
        foreach (Woord woord in GetWoorden())
        {
            if (IsPalindrome(woord.Tekst))
            {
                palindromen.Add(woord);
            }
        }
        return palindromen;
    }

    // Checks if a given string is a palindrome.
    private bool IsPalindrome(string tekst)
    {
        char[] chars = tekst.ToCharArray();
        Array.Reverse(chars);
        return new string(chars) == tekst;
    }
}

public struct BestandInfo
{
    public string Pad { get; set; }
    public string FileName { get; set; }
}