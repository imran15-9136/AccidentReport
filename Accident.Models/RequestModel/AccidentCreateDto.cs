using System;
using System.Collections.Generic;
using System.Text;

namespace Accident.Models.RequestModel
{
    public class AccidentCreateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}
