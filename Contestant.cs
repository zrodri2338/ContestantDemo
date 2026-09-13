using System;

public class Contestant
{
    public static char[] TalentCodes = { 'S', 'D', 'M', 'O' };

    public static string[] TalentDescriptions =
    {
        "Singing",
        "Dancing",
        "Musical Instrument",
        "Other"
    };

    private string name;
    private int age;
    private char talentCode;
    private string talentDescription;
    private double entryFee;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public char TalentCode
    {
        get { return talentCode; }

        set
        {
            SetTalentCode(value);
        }
    }

    
    public string TalentDescription
    {
        get { return talentDescription; }
    }

    
    public double EntryFee
    {
        get { return entryFee; }
        set { entryFee = value; }
    }

    
    public Contestant(string name, int age, char talentCode)
    {
        this.name = name;
        this.age = age;

        TalentCode = talentCode;
    }

    private void SetTalentCode(char code)
    {
        code = char.ToUpper(code);

        for (int i = 0; i < TalentCodes.Length; i++)
        {
            if (code == TalentCodes[i])
            {
                talentCode = code;
                talentDescription = TalentDescriptions[i];
                return;
            }
        }

        talentCode = 'I';
        talentDescription = "Invalid";
    }

    
    public static bool IsValidTalentCode(char code)
    {
        code = char.ToUpper(code);

        foreach (char validCode in TalentCodes)
        {
            if (code == validCode)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Age: {Age}\n" +
               $"Talent Code: {TalentCode}\n" +
               $"Talent: {TalentDescription}\n" +
               $"Entry Fee: {EntryFee:C}";
    }
}