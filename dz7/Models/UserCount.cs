namespace dz7.Models
{
    public static class UserCount
    {
        private static List<string> sessionIds = new List<string>();
        public static void AddSessionId(string sessionId)
        {
            if (!sessionIds.Contains(sessionId))
            {
                sessionIds.Add(sessionId);
            }
        }

        public static void RemoveSessionId(string sessionId)
        {
            sessionIds.Remove(sessionId);
        }

        public static int GetUniqueSessionCount()
        {
            return sessionIds.Count;
        }
    }
}
