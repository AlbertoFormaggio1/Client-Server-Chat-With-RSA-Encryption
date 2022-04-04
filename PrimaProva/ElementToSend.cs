using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PrimaProva
{
    /// <summary>
    /// Classe creata per poter serializzare l'oggetto in JSON
    /// </summary>
    public class ElementToSend
    {
        string type;
        string[] values;

        public string Type { get => type; set => type = value; }
        public string[] Values { get => values; set => values = value; }

        public ElementToSend(string ty,string[] val)
        {
            type = ty;
            values = val;
        }
    }
}
