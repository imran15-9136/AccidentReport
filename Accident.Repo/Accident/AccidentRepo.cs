using Accident.Database;
using Accident.Models.Models;
using Accident.Repo.Abstraction.Accident;
using Accident.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accident.Repo.Accident
{
    public class AccidentRepo: Repo<AccidentModel>, IAccidentRepo
    {
        private readonly ApplicationDbContext _db;
        public AccidentRepo(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    }
}
