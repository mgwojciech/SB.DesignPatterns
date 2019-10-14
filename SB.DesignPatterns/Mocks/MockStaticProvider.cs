using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Mocks
{
    public class MockStaticProvider
    {
        public static IDataProvider<User> GetUserDataProvider()
        {
            return new MockDataProvider<User>(new List<User>() {
                new User()
                {
                    Id = 1,
                    FirstName = "Marcin",
                    LastName = "Wojciechowski",
                    LoginName = "marcin.wojciechowski@solidbrain.com"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Michal",
                    LastName = "Majewski",
                    LoginName = "michal.majewski@solidbrain.com"
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Tomasz",
                    LastName = "Matyskiewicz",
                    LoginName = "tomasz.matyskiewicz@solidbrain.com"
                }
            });
        }
    }
}
