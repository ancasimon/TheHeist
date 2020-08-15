using System;
using System.Collections.Generic;
using System.Text;
using TheHeist.Team;

namespace TheHeist.Bank
{
    class BankInstitution
    {
        //properties:
        //public int BankDifficultyLevel { get; set; } = 100; //in Phase 3, this value was set by default to 100.
        public int FinalBankDifficultyLevel { get; set; }
        public int UserBankDifficultyLevel { get; set; }
        public int HeistLuckValue { get; set; }

        public BankInstitution()
        {
            Random rnd = new Random();
            HeistLuckValue = rnd.Next(-10, 10);
            //Console.WriteLine($"Newly auto-generated heist luck value: {HeistLuckValue}!");
        }

        public void CalculateFinalBankDifficultyLevel(int userBankDifficultyLevel)
        {
            UserBankDifficultyLevel = userBankDifficultyLevel;
            FinalBankDifficultyLevel = UserBankDifficultyLevel + HeistLuckValue;
            //Console.WriteLine($"Newly calculated bank difficulty level is: {BankDifficultyLevel}!");
        }


        public void Rob(List<TeamMember> teamList)
        {
            //if (teamList.TeamSkillLevel > bank1.BankDifficultyLevel) 
            //{
            //    Console.WriteLine($"Current team skill level is {teamSkillLevel}! You might get lucky and actually get some money out of this heist!");
            //}
            //else
            //{
            //    Console.WriteLine($"Current team skill level is {teamSkillLevel}! Pretty sure y'all are gonna end up in jail...");
            //}
        }
            
    }
}
