using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Laboratory.AWS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laboratory.AWS.Persistence
{
    public class UserProvide : IUserProvide
    {
        private readonly IAmazonDynamoDB dynamonDB;
        public UserProvide(IAmazonDynamoDB dynamonDB)
        {
            this.dynamonDB = dynamonDB;
        }
        public async Task<List<Users>> GetUsersList()
        {
            List<Users> usersResult = new List<Users>();

            var result = await dynamonDB.ScanAsync(new ScanRequest
            {
                TableName = "user-table"
            });

            if (result != null && result.Items != null)
            {
                foreach (var item in result.Items)
                {
                    item.TryGetValue("City", out var city);
                    item.TryGetValue("Address", out var address);
                    item.TryGetValue("Email", out var email);
                    item.TryGetValue("Phone", out var phone);
                    usersResult.Add(new Users
                    {
                        City = city?.S,
                        Address = address?.S,
                        Email = email?.S,
                        Phone = Convert.ToInt32(phone?.S)
                    });

                }
            }

            return usersResult;


        }
    }
}
