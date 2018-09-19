﻿using Microservice.Service.Interfaces;
using Microservice.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Service.Repsitory
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> _teams;

        public MemoryTeamRepository()
        {
            if(_teams == null)
            {
                _teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            _teams = teams;
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }

        public IEnumerable<Member> GetAllMembersFromTeam(Guid id)
        {
            var team = _teams.Where(t => t.ID == id).FirstOrDefault();
            return team.Members;
        }

        public void AddTeamMember(Guid id, Member newMeber)
        {
            _teams.Where(t => t.ID == id).FirstOrDefault().Members.Add(newMeber);
        }

        public Member GetTeamMember(Guid id, Guid memberId)
        {
            var team = _teams.Where(t => t.ID == id).FirstOrDefault();
            var member = team.Members.Where(m => m.ID == memberId).FirstOrDefault();
            return member;
        }

        public void DeleteMember(Guid id, Guid memberId)
        {
            var team = _teams.Where(t => t.ID == id).FirstOrDefault();
            var member = GetTeamMember(id, memberId);
            team.Members.Remove(member);
        }
    }
}
