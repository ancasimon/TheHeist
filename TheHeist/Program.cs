﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TheHeist.Bank;
using TheHeist.Team;

namespace TheHeist
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            string moreTeamMembers;
            int userAttempts;
            var attemptCount = 1;
            var currentTeam = new WholeTeam();
            var teamSkillLevel = 0;
            int userBankDifficultyLevel;
            int successCount = 0;
            int failureCount = 0;

            Console.WriteLine("How difficult do you really think it will be to rob a bank - on a scale from 0 to 100??");
            userBankDifficultyLevel = Convert.ToInt32(Console.ReadLine());

            do
            {

                Console.WriteLine("What's the team member's name?");
                var teamMemberName = Console.ReadLine();
                if (string.IsNullOrEmpty(teamMemberName))
                {
                    Console.WriteLine("You must enter a name!");
                }
                else
                {
                    Console.WriteLine($"What's {teamMemberName}'s skill level?");
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
                            Console.WriteLine();
                            Console.WriteLine($"What's {teamMemberName}'s courage factor? (on a scale from 0.0 to 2.0)");
                            var teamMemberCourageFactor = decimal.Parse(Console.ReadLine());
                            if (teamMemberCourageFactor > 2.0M || teamMemberCourageFactor < 0.0M)
                            {
                                Console.WriteLine("You must enter a courage level between 0.0 and 2.0!");
                            }
                            else
                            {
                                Console.WriteLine();
                                var member1 = new TeamMember()
                                {
                                    Name = teamMemberName,
                                    SkillLevel = teamMemberSkillLevel,
                                    CourageFactor = teamMemberCourageFactor
                                };
                                //member1.DisplayTeamMember(member1.Name, member1.SkillLevel, member1.CourageFactor);
                                member1.DisplayTeamMember();
                                currentTeam.TeamMembers.Add(member1); //ANCA: This is how you add a new object to a list-type class!!!
                            }
                        }
                    }

                }

                Console.WriteLine("Would you like to add another team member? (Enter y or n!)");
                moreTeamMembers = Console.ReadLine();
            }
            while (moreTeamMembers == "y");

            Console.WriteLine("How many trial runs of the heist would you like to see?");
            userAttempts = Convert.ToInt32(Console.ReadLine());


            if (currentTeam.TeamMembers.Count != 0)   //ANCA: This is how we check the number of elements in a list!!
            {
                Console.WriteLine($"Your team currently has {currentTeam.TeamMembers.Count} members.");
                Console.WriteLine();
                teamSkillLevel = 0;
                foreach (var name in currentTeam.TeamMembers)
                {
                    name.DisplayTeamMember(name.Name, name.SkillLevel, name.CourageFactor);
                    //name.DisplayTeamMember();
                    teamSkillLevel = currentTeam.CalculateTeamSkillLevel(currentTeam.TeamMembers);  //ANCA: Updated this line to call the team method after fixing the WholeTeam class!
                    //Console.WriteLine($"Current team skill level is: {teamSkillLevel}.");
                }
            }

            for (int i = 1; i <= userAttempts; i++)
            {
                var bank1 = new BankInstitution();
                bank1.CalculateFinalBankDifficultyLevel(userBankDifficultyLevel);
                Console.WriteLine(@$"Here's your data:
-- Current team skill level is {teamSkillLevel}. 
-- Bank difficulty level is {bank1.FinalBankDifficultyLevel}.
-- (This does include a randomly-generated heist luck value of {bank1.HeistLuckValue}.)");

                if (teamSkillLevel >= bank1.FinalBankDifficultyLevel) //Anca: move this to the Bank file - have a method call Rob() that would take in a team parameter!!! STILL WORKING ON THIS!!
                {
                    successCount++;
                    Console.WriteLine("Final Answer: You might get lucky and actually get some money out of this heist!");
                    Console.WriteLine();
                }
                else
                {
                    failureCount++;
                    Console.WriteLine("Final Answer: Pretty sure y'all are gonna end up in jail...");
                    Console.WriteLine();
                }
            attemptCount++;
            }

            Console.WriteLine($"You had {successCount} successes!");
            Console.WriteLine($"You had {failureCount} failures!");

                //DISCUSSED IN CLASS:
                //wondering where the methods should go - where should the logic live? who should determine if the team got to rob the bank?
                //Program file is supposed to be just an orchestrator!!! do not put details of methods in here!! just like a recipe - should just include the steps that call out to other things!

                //Console.WriteLine("Would you like to try another scenario? (Enter y or n!)");
                //tryAgain = Console.ReadLine();
            
        }
    }
}
