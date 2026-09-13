public class TeenContestant : Contestant
{
    public TeenContestant(string name, int age, char talentCode)
        : base(name, age, talentCode)
    {
        EntryFee = 20.00;
    }

    public override string ToString()
    {
        return base.ToString() + "\n" +
               "Age Category: Teen";
    }
}