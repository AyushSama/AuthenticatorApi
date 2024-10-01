namespace Authenticator.Application.LoginAttemptService
{
    public class FailedLoginAttemptsService
    {
        private readonly Dictionary<string, int> _failedAttempts = new Dictionary<string, int>();
        private readonly int _maxAttempts = 3;

        public void RecordFailedAttempt(string email)
        {
            if (_failedAttempts.ContainsKey(email))
            {
                _failedAttempts[email]++;
            }
            else
            {
                _failedAttempts[email] = 1;
            }
        }

        public int GetFailedAttempts(string email)
        {
            return _failedAttempts.TryGetValue(email, out var attempts) ? attempts : 0;
        }

        public void ResetAttempts(string email)
        {
            _failedAttempts.Remove(email);
        }

        public bool IsBlocked(string email)
        {
            return GetFailedAttempts(email) >= _maxAttempts;
        }
    }

}
