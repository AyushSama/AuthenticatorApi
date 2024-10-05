using ConfigReader.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ConfigReader
{
    public class TokenConfiguration
    {

        public static TokenClaimModel _tokenClaim { get; set; }

        public static TokenClaimModel ApplyToken(JwtSecurityToken jwtToken, string strToken)
        {
            var _tokenClaim = new TokenClaimModel
            {
                Token = strToken,
                MainCorpNo = GetClaimValueAsInt(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid"),
                LoginCorpNo = GetClaimValueAsInt(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"),
                IsSubAdmin = GetClaimValueAsBool(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"),
                TimeZoneId = GetClaimValueAsInt(jwtToken, "TimezoneId"),
                TimeZoneDiffinSec = GetClaimValueAsInt(jwtToken, "TimeZoneDiffinSec"),
                AccountTimeFormat = GetClaimValueAsInt(jwtToken, "TimeFormat"),
                AccountDateFormat = GetClaimValueAsInt(jwtToken, "DateFormat"),
                FolderName = GetClaimValueAsString(jwtToken, "FolderName"),
                CorporateName = GetClaimValueAsString(jwtToken, "CorpName"),
                Creator = GetClaimValueAsString(jwtToken, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"),
                AccountType = GetClaimValueAsInt(jwtToken, "AccountType"),
                LtmcCorpNo = GetClaimValueAsInt(jwtToken, "LtmcCorpNo"),
                Ip = GetClaimValueAsString(jwtToken, "Ip"),
                MasterLogin = GetClaimValueAsInt(jwtToken, "MasterLogin"),
                IsNogin = GetClaimValueAsBool(jwtToken, "IsNogin"),
                PermissionId = GetClaimValueAsInt(jwtToken, "PermissionId")
            };

            return _tokenClaim;
        }

        private static int GetClaimValueAsInt(JwtSecurityToken jwtToken, string claimType)
        {
            try
            {
                var value = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
                return int.TryParse(value, out var result) ? result : 0;
            }
            catch { return 0; }


        }

        private static bool GetClaimValueAsBool(JwtSecurityToken jwtToken, string claimType)
        {
            try
            {
                var value = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
                return bool.TryParse(value, out var result) ? result : false;
            }
            catch
            {
                return false;
            }
        }

        private static string GetClaimValueAsString(JwtSecurityToken jwtToken, string claimType)
        {
            try
            {
                return jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value ?? string.Empty;
            }
            catch { return string.Empty; }
        }


        public static TokenClaimModel ApplyApplicationKey(JwtSecurityToken jwtToken, string strToken)
        {
            _tokenClaim = new TokenClaimModel();
            _tokenClaim.Token = strToken;
            _tokenClaim.MainCorpNo = GetClaimValueAsInt(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid");
            _tokenClaim.LoginCorpNo = GetClaimValueAsInt(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid");
            return _tokenClaim;
        }
        public static TokenClaimModel ApplyItsmTokenKey(JwtSecurityToken jwtToken, string strToken)
        {
            _tokenClaim = new TokenClaimModel();
            _tokenClaim.Token = strToken;
            _tokenClaim.MainCorpNo = GetClaimValueAsInt(jwtToken, "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarygroupsid");
            _tokenClaim.Email = GetClaimValueAsString(jwtToken, "Email");
            return _tokenClaim;
        }
    }
}
