using Accident.BLL.Abstraction.Accident;
using Accident.BLL.Base;
using Accident.Models.Models;
using Accident.Repo.Abstraction.Accident;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accident.BLL.Accident
{
    public class AccidentBLL: Manager<AccidentModel>, IAccidentBLL
    {
        private readonly IAccidentRepo _repo;
        public AccidentBLL(IAccidentRepo repo):base(repo)
        {
            _repo = repo;
        }
    }
}
