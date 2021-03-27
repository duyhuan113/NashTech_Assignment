using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoManageMembers.Models
{
    public class MemberHandler : IMemberHandler
    {
       private static List<Member> members = new List<Member>(){
            new Member() { Name="Bui Duy Vinh",Phone="987654321",Birthday="11/03/2001",Gender="Male",Email="buihuana5@gmail.com",BirthPlace="Hai Phong"}
            ,new Member() { Name="Bui Duy Minh",Phone="987654321",Birthday="11/03/2000",Gender="Male",Email="buihuana52@gmail.com",BirthPlace="Ha Noi"}
            ,new Member() { Name="Bui Duy Tuan",Phone="987654321",Birthday="11/03/1999",Gender="Male",Email="buihuana53@gmail.com" ,BirthPlace="Hai Phong"}
            ,new Member() { Name="Bui Duy Tu",Phone="987654321",Birthday="11/03/1998",Gender="Male",Email="buihuana54@gmail.com",BirthPlace="Lao Cai"}
            ,new Member() { Name="Bui Duy Duc",Phone="987654321",Birthday="11/03/2000",Gender="Male",Email="buihuana55@gmail.com",BirthPlace="Ha Nam"}
            };
        public List<Member> GetMembersByName(string searchString){
              if (String.IsNullOrEmpty(searchString))
              {
                  return members;
              }
              return members.Where(p=>p.Name.Contains(searchString)).ToList();
        }
        public void DeleteMember(int index){
            if (CheckIndexIsValid(index))
            {
                members.RemoveAt(index);
            }
        }

        public List<Member> GetMembers(){
             return members;
        } 
        public Member GetMemberByIndex(int index){
            if (!CheckIndexIsValid(index))
            {
                return null;
            }
            Member member = members[index];
            return member;
        }
        public void AddMember(Member member){
            members.Add(member);
        }

        bool CheckIndexIsValid(int index){
            return (index < members.Count && index >=0);
        }

        public Member UpdateMember(int index, Member member){
            if (CheckIndexIsValid(index))
            {
                members[index] = member;
            }
            return members[index];
        }

    }
}