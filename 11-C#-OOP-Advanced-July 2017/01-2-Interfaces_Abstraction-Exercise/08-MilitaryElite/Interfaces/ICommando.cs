using System.Collections.Generic;

namespace _08_MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
    {
    public interface ICommando : ISpecialisedSoldier
        {
        IReadOnlyList<IMission> Missions { get; }
        }
    }