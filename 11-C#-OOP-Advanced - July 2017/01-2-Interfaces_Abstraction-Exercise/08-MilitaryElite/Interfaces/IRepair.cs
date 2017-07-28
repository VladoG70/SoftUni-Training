namespace _08_MilitaryElite.Models
    {
    public interface IRepair
        {
        string PartName { get; }

        int HoursWorked { get; }
        }
    }