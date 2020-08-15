using System;
using System.Collections.Generic;
using System.Text;

namespace TheHeist.Team
{
    class WholeTeam
    {
        public int TeamSkillLevel { get; set; } = 0;

        public void CalculateTeamSkillLevel(List<TeamMember> teamList)
        {

            foreach (var name in teamList)
            {
                TeamSkillLevel = name.SkillLevel + TeamSkillLevel;
            }
        }

        internal void Add(TeamMember member1)
        {
            throw new NotImplementedException();
        }
    }
}
