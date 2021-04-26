using Accident.Models.Models;
using Accident.Repo.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accident.Repo.Abstraction.Accident
{
    public interface IAccidentRepo: IRepo<AccidentModel>
    {
    }
}
