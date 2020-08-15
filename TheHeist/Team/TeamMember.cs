using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace TheHeist.Team
{
    class TeamMember
    {
        //properties:
        public string Name { get; set; }
        public int SkillLevel { get; set; } //how can I force it to be a positive number? Is byte an ok way to do that? Doesn't seem to do it!! Even if the max then has to be 255?
        public decimal CourageFactor { get; set; } //how can I force a range? AND - how can I store it as a decimal from the Console user entry??
        //[Range(typeof(decimal), "0.0", "2.0")]

        //methods:
        public void DisplayTeamMember(string name, int skillLevel, decimal courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
            Console.WriteLine($"{Name} has a skill level of {SkillLevel} and a courage factor of {CourageFactor}.");
        }

        public void DisplayTeamMember() //Anca note: using method overloading to stop displaying team member's info - #1 in Phase 3 - is that what was intended??
        { }

    }
}
