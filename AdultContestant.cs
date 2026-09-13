public class AdultContestant : Contestant
{
    public AdultContestant(string name, int age, char talentCode)
        : base(name, age, talentCode)
    {
        EntryFee = 30.00;
    }

    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Age Category: Adult";
    }
}