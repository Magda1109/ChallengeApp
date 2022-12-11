using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChallengeApp
{
    public class CheckedName
    {
        public string Name { get; set; }
        public void ChangeName(string name)
        {
            bool checkName = false;
            foreach (var sign in name)
            {
                if (char.IsDigit(sign))
                {
                    checkName = true;
                }
            }
            if (checkName)
            {
                Console.WriteLine("Invalid name");
            }
            else
            {
                Name = name;
            }
        }
    }
}
