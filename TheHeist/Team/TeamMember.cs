using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace TheHeist.Team
{
    class TeamMember
    {
        //properties
        public string Name { get; set; }
        public string SkillLevel { get; set; } //how can I force it to be a positive number? Is byte an ok way to do that? Doesn't seem to do it!! Even if the max then has to be 255?
        public string CourageFactor { get; set; } //how can I force a range? AND - how can I store it as a decimal from the Console user entry??
        //[Range(typeof(decimal), "0.0", "2.0")]
    }
}
