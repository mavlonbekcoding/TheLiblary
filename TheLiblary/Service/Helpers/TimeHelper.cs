using TheLiblary.Data.Constants;
    public class TimeHelper
    {
        public static DateTime GetDateTime()
        {
            var datetime = DateTime.UtcNow;
            datetime = datetime.AddHours(TimeConstants.UTC);
            return datetime;
        }
   }
