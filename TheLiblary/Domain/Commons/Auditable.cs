namespace TheLiblary.Domain.Commons
{
    internal class Auditable : Base
    {
        public DateTime CreateAt { get; set; } = TimeHelper.GetDateTime();
        public DateTime UpdateAt { get; set; } = TimeHelper.GetDateTime();
    }
}
