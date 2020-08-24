using System;

namespace Application.Users.Query.GetJoinedGroups
{
    public class JoinedGroupsModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; }
        public DateTime CreationDate { get; }
        public int MemberCount { get; }
        public string Creator { get; }    
        
        private JoinedGroupsModel(){}

        public JoinedGroupsModel(int groupId, string groupName, DateTime creationDate, int memberCount, string creator)
        {
            GroupId = groupId;
            GroupName = groupName;
            CreationDate = creationDate;
            MemberCount = memberCount;
            Creator = creator;
        }
    }
}