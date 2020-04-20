using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();
            List<Player> players = new List<Player>();

            while (command.ToLower() != "end")
            {
                try
                { 
                    string[] commandArgs = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    ParseCommand(commandArgs, teams, players);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        private void ParseCommand(string[] commandArgs, List<Team> teams, List<Player> players)
        {
            string typeOfCommand = commandArgs[0];

            if (typeOfCommand.ToLower() == "team")
            {
                Team team = CreateTeam(commandArgs);
                teams.Add(team);
            }
            else if (typeOfCommand.ToLower() == "add")
            {
                string teamName = commandArgs[1];

                if (CheckIfTeamExist(teamName, teams))
                {
                    Player player = CreatePlayer(commandArgs);
                    Team team = teams.Where(t => t.Name.ToLower() == teamName.ToLower()).FirstOrDefault();
                    team.AddPlayer(player);
                    players.Add(player);
                }
                else
                {
                    throw new InvalidOperationException($"Team {teamName} does not exist.");
                }
            }
            else if (typeOfCommand.ToLower() == "remove")
            {
                string teamName = commandArgs[1];

                if (CheckIfTeamExist(teamName, teams))
                {
                    string playerName = commandArgs[2];
                    
                    Team team = teams.Where(t => t.Name.ToLower() == teamName.ToLower()).FirstOrDefault();

                    if (CheckIfPlayerExist(team, playerName))
                    {
                        Player player = players.Where(p => p.Name.ToLower() == playerName.ToLower()).FirstOrDefault();
                        team.RemovePlayer(player);
                    }
                    else 
                    {
                        throw new InvalidOperationException($"Player {playerName} is not in {team.Name} team.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Team {teamName} does not exist.");
                }
            }
            else if (typeOfCommand.ToLower() == "rating")
            {
                string teamName = commandArgs[1];

                if (CheckIfTeamExist(teamName, teams))
                {
                    Team team = teams.Where(t => t.Name.ToLower() == teamName.ToLower()).FirstOrDefault();
                    Console.WriteLine(team);
                }
                else
                {
                    throw new InvalidOperationException($"Team {teamName} does not exist.");
                }
            }
        }

        private bool CheckIfPlayerExist(Team team, string playerName)
        {
            foreach (Player player in team.Players)
            {
                if (player.Name.ToLower() == playerName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private Player CreatePlayer(string[] commandArgs)
        {
            string playerName = commandArgs[2];
            double playerEndurance = double.Parse(commandArgs[3]);
            double playerSprint = double.Parse(commandArgs[4]);
            double playerDribble = double.Parse(commandArgs[5]);
            double playerPassing = double.Parse(commandArgs[6]);
            double playerShooting = double.Parse(commandArgs[7]);

            Player player = new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);

            return player;
        }

        private bool CheckIfTeamExist(string teamName,List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if (team.Name.ToLower() == teamName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private Team CreateTeam(string[] commandArgs)
        {
            string name = commandArgs[1];
            Team team = new Team(name);

            return team;
        }
    }
}
