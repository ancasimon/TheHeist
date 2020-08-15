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
            var bank1 = new BankInstitution();
            bank1.CalculateFinalBankDifficultyLevel();
            //var currentTeam = new WholeTeam(); ANCA: Will come back to this when I figure out the WholeTeam class better!
            var currentTeam = new List<TeamMember>();
            var teamSkillLevel = 0;


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
                    var userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        Console.WriteLine("You must enter an actual number for their skill level!");
                    }
                    else if (userInput != "")
                    {
                        var teamMemberSkillLevel = Convert.ToInt32(userInput);
                        if (teamMemberSkillLevel < 0)
                        {
                            Console.WriteLine("You must enter an actual number for their skill level!");
                        }
                        else
                        {
                            {
                                Console.WriteLine();
                                Console.WriteLine("What's the team member's courage factor? (on a scale from 0.0 to 2.0)");
                                var teamMemberCourageFactor = decimal.Parse(Console.ReadLine());
                                if (teamMemberCourageFactor > 2.0M || teamMemberCourageFactor < 0.0M)
                                {
                                    Console.WriteLine("You must enter a courage level between 0.0 and 2.0!");
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
                                    currentTeam.Add(member1);
                                }
                            }
                        }

                    }



                    Console.WriteLine("Would you like to add a team member? (Enter Yes or leave blank if No!)");
                    tryAgain = Console.ReadLine();
                }
            }
            while (tryAgain != "");


            if (currentTeam.Count != 0)
            {
                Console.WriteLine($"Your team currently has {currentTeam.Count} members.");
                foreach (var name in currentTeam)
                {
                    //Console.WriteLine($"{name.Name} has a skill level of {name.SkillLevel} and a courage factor of {name.CourageFactor}.");
                    //name.DisplayTeamMember(name.Name, name.SkillLevel, name.CourageFactor);
                    name.DisplayTeamMember();
                    teamSkillLevel = name.SkillLevel + teamSkillLevel;
                    //currentTeam.CalculateTeamSkillLevel  //ANCA: Will come back when I figure out the WholeTeam class!
                    //Console.WriteLine($"Current team skill level is: {teamSkillLevel}.");
                }
            }

            //Console.WriteLine($"Final team skill level is: {teamSkillLevel}.");

            //DISCUSSED IN CLASS:
            //wondering where the methods should go - where should the logic live? who should determine if the team got to rob the bank?
            //Program file is supposed to be just an orchestrator!!! do not put details of methods in here!! just like a recipe - should just include the steps that call out to other things!

            Console.WriteLine(@$"Here's your data:
-- Current team skill level is {teamSkillLevel}. 
-- Bank difficulty level is {bank1.BankDifficultyLevel}.
-- (This does include a randomly-generated heist luck value of {bank1.HeistLuckValue}.)
");

            if (teamSkillLevel >= bank1.BankDifficultyLevel) //Anca: move this to the Bank file - have a method call Rob() that would take in a team parameter!!! STILL WORKING ON THIS!!
            {
                Console.WriteLine("You might get lucky and actually get some money out of this heist!");
            }
            else
            {
                Console.WriteLine("Pretty sure y'all are gonna end up in jail...");
            }


        }
    }
}
