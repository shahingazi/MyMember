using System.Linq;
namespace MyMember.Models
{
    public static class MemberExtensions
    {
        public static IQueryable<Members> FilterByIdentity(this IQueryable<Members> q, string identity)
        {
            if (string.IsNullOrEmpty(identity) || q ==null)
                return q;
            return q.Where(x => x.IdentityNumber.Equals(identity));
        }

        public static IQueryable<Members> FilterByEmail(this IQueryable<Members> q, string email)
        {
            if (string.IsNullOrEmpty(email) || q == null)
                return q;
            return q.Where(x => x.IdentityNumber.Equals(email));
        }

        public static IQueryable<Members> FilterByPhoneNumber(this IQueryable<Members> q, string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || q == null)
                return q;
            return q.Where(x => x.IdentityNumber.Equals(phoneNumber));
        }
    }
}