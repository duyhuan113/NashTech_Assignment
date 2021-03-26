using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoManageMembers.Models
{
    public interface IMemberHandler
    {
        List<Member> GetMembers();
        Member GetMemberByIndex(int index);
        void AddMember(Member member);
        void DeleteMember(int index);
        Member UpdateMember(int index, Member member);
        List<Member> GetMembersByName(string searchString);
    }
}