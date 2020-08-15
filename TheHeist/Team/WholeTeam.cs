using System;
using System.Collections.Generic;
using System.Text;

namespace TheHeist.Team
{
    class WholeTeam
    {
        public int TeamSkillLevel { get; set; } = 0;
        public List<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

        public int CalculateTeamSkillLevel(List<TeamMember> teamList)
        {
            TeamSkillLevel = 0;
            foreach (var name in teamList)
            {
                TeamSkillLevel += name.SkillLevel;
                //Console.WriteLine($"{TeamSkillLevel} from WholeTeam class!!");
            }
            return TeamSkillLevel;
        }
    }
}
