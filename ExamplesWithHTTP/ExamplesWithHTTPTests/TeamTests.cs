using ExamplesWithHTTP.Cervices;
using ExamplesWithHTTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExamplesWithHTTPTests
{
    public class TeamTests
    {
            

        [Fact]
        public async Task AuthoriseTest()
        {
            var _teamService = new TeamService();
            var _authResponse = await _teamService.Authorise(new AuthData { Login = "IvanD", Password = "IvanD" });

            var team = new Team
            {
                Id = 1,
                Name = "TestTeam3",
                FoudationYer = new DateTime(2022, 1, 1),
                Division = "A"
            };

            await _teamService.AddTeam(team);
            var teams = await _teamService.GetTeams();
        }

    }
}
