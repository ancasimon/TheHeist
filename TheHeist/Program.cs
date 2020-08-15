using System;
using System.Collections.Generic;
using TheHeist.Team;

namespace TheHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            string tryAgain = null;
            var team = new List<TeamMember>();

            
            do
            {
                Console.WriteLine("Plan Your Heist!");
                Console.WriteLine("What's the team member's name?");
                var teamMemberName = Console.ReadLine();
                if (string.IsNullOrEmpty(teamMemberName))
                {
                    Console.WriteLine("You must enter a name!");
                }
                else
                {
                    Console.WriteLine("What's the team member's skill level?");
                    var teamMemberSkillLevel = Console.ReadKey().KeyChar;
                    if (teamMemberSkillLevel == 13)  //Anca : 13 is the key for Enter
                    {
                        Console.WriteLine("You must enter a skill level!");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("What's the team member's courage factor?");
                        var teamMemberCourageFactor = Console.ReadKey().KeyChar;
                        if (teamMemberCourageFactor == 13)
                        {
                            Console.WriteLine("You must enter a courage level!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(@$"You have entered the following team member's information:
Name: {teamMemberName};
Skill Level: {teamMemberSkillLevel};
Courage Factor: {teamMemberCourageFactor};
");
                            var member1 = new TeamMember()
                            {
                                Name = teamMemberName,
                                SkillLevel = teamMemberSkillLevel.ToString(),
                                CourageFactor = teamMemberCourageFactor.ToString()
                            };

                            //Console.WriteLine(member1.ToString());
                            team.Add(member1);
                        }
                    }
                        
                    

                }
                Console.WriteLine($"Your team currently has {team.Count} members.");
                foreach (var name in team)
                {
                    Console.WriteLine($"{name.Name} has a skill level of {name.SkillLevel} and a courage factor of {name.CourageFactor}.");
                }
                

                Console.WriteLine("Would you like to add a team member? (Enter Yes or leave blank if No!)");
                tryAgain = Console.ReadLine();
            }
            while (tryAgain != "");

        }
    }
}
