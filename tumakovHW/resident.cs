using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakovHW
{
    public class Resident
    {
        public string name { get; set; }
        public string passportNumber { get; set; }
        public Problem problem { get; set; }
        public Temperament temperament { get; set; }

        public Resident(string name, string passportNumber,
            Problem problem, Temperament temperament)
        {
            this.name = name;
            this.passportNumber = passportNumber;
            this.problem = problem;
            this.temperament = temperament;
        }
    }
    public class Temperament
    {
        public int Scandalousness { get; set; }
        public int Intelligence { get; set; } 
    }
    public class Problem
    {
        public int Number { get; set; } 
        public string Description { get; set; } 
    }
}
