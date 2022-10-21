using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "ypPfdsfsdfdsPfdfdfsdfdsfdsfdsfBJPfdsfsdfdsffBJP";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly IMongoCollection<UserAccount> _UserInfoCollection;
        public JwtTokenHandler()
        {
            var mongoClient = new MongoClient("mongodb://databaseeauction:qs5yGVKcItOih9EqHvbEgePMh5kpbSImDH9Ww3in15yVVpTGVrl00XuJkFodofgYxrtlNiTySlhFfp0ppJAiTA==@databaseeauction.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@databaseeauction@");
            var database = mongoClient.GetDatabase("EAuction");
            _UserInfoCollection = database.GetCollection<UserAccount>("UserMaster");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticatonRequest"></param>
        /// <returns></returns>
        public AuthenticationResponse? GenerateJwtToken(AuthenticatonRequest authenticatonRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticatonRequest.UserName) || string.IsNullOrWhiteSpace(authenticatonRequest.Password))
                return null;

            var userAccount = _UserInfoCollection.Find(x => x.UserName == authenticatonRequest.UserName && x.Passwrod == authenticatonRequest.Password).SingleOrDefaultAsync().Result;
            if (userAccount == null) return null;

            var tokenExpirtyTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Name,authenticatonRequest.UserName),
               // new Claim(ClaimTypes.Role,userAccount.Role)
                new Claim("Role",userAccount.Role)
            });

            var signinigCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpirtyTimeStamp,
                SigningCredentials = signinigCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpirtyTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
                Roles = userAccount.Role
            };
        }
    }
}
