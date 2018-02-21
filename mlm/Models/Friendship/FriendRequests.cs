/* TODO: All these frields
 * FriendRequests
- UserId
- FutureFriendId
- Message
- TimeStamp
- ApproveFlag
- RejectFlag
- BlockFlag
- SpamFlag
- ExpiresDate

Friends
- UserId
- FriendId
- FriendType
- FriendHasThisManyFriends
- TheirFriendsHaveThisManyFriends
- WhenWeBecameFriendsDate
     */

using System;

namespace mlm.Models.Friendship
{
    public class FriendRequests : ApplicationUser
    {
        /*
         * - Message
- TimeStamp
- ApproveFlag
- RejectFlag
- BlockFlag
- SpamFlag
- ExpiresDate

         */
        public Guid FutureFriendId { get; set; }
        public DateTime TimeStamp { get; set; }
        
    }
    
    
}