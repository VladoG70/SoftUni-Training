using System.Collections.Generic;

namespace _08_MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
    {
    public interface IEngineer : ISpecialisedSoldier
        {
        IReadOnlyList<IRepair> Repairs { get; }
        }
    }