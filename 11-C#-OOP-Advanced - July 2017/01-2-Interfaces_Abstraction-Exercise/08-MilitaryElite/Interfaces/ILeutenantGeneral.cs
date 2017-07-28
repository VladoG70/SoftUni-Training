using System.Collections.Generic;

namespace _08_MilitaryElite.Models.Soldiers.Privates
    {
    public interface ILeutenantGeneral : IPrivate
        {
        IReadOnlyList<IPrivate> PrivateSoldiers { get; }
        }
    }