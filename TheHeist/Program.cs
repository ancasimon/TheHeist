using System;
using System.Collections.Generic;
using TheHeist.Bank;
using TheHeist.Team;

namespace TheHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            string tryAgain = null;
            var team = new List<TeamMember>();
            var teamSkillLevel = 0;
            var bank1 = new BankInstitution();

            
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
                    var teamMemberSkillLevel = Convert.ToInt32(Console.ReadLine());
                    if (teamMemberSkillLevel == 0)  
                    {
                        Console.WriteLine("You must enter a skill level!");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("What's the team member's courage factor?");
                        var teamMemberCourageFactor = Convert.ToInt32(Console.ReadLine());
                        if (teamMemberCourageFactor == 0)
                        {
                            Console.WriteLine("You must enter a courage level!");
                        }
                        else
                        {
                            Console.WriteLine();
//                            Console.WriteLine(@$"You have entered the following team member's information:
//Name: {teamMemberName};
//Skill Level: {teamMemberSkillLevel};
//Courage Factor: {teamMemberCourageFactor};
//");
                            var member1 = new TeamMember()
                            {
                                Name = teamMemberName,
                                SkillLevel = teamMemberSkillLevel,
                                CourageFactor = teamMemberCourageFactor
                            };
                            member1.DisplayTeamMember(member1.Name, member1.SkillLevel, member1.CourageFactor);
                            //member1.DisplayTeamMember();
                            //Console.WriteLine(member1.ToString());
                            team.Add(member1);
                        }
                    }
                        
                    

                }
                Console.WriteLine($"Your team currently has {team.Count} members.");



                foreach (var name in team)
                {
                    //Console.WriteLine($"{name.Name} has a skill level of {name.SkillLevel} and a courage factor of {name.CourageFactor}.");
                    //name.DisplayTeamMember(name.Name, name.SkillLevel, name.CourageFactor);
                    name.DisplayTeamMember();
                    teamSkillLevel = name.SkillLevel + teamSkillLevel;
                    //Console.WriteLine($"Current team skill level is: {teamSkillLevel}.");
                }
                //Console.WriteLine($"Final team skill level is: {teamSkillLevel}.");


                if(teamSkillLevel > bank1.BankDifficultyLevel)
                {
                    Console.WriteLine($"Current team skill level is {teamSkillLevel}! You might get lucky and actually get some money out of this heist!");
                }
                else
                {
                    Console.WriteLine($"Current team skill level is {teamSkillLevel}! Pretty sure y'all are gonna end up in jail...");
                }
                

                Console.WriteLine("Would you like to add a team member? (Enter Yes or leave blank if No!)");
                tryAgain = Console.ReadLine();
            }
            while (tryAgain != "");

        }
    }
}
