using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viber.Bot;

namespace ViberMessagePlugin
{
    public class ViberMessanger
    {
       /* private ViberBotClient botClient;
        public async Task<List<User>> GetContactsList()
        {
            var list = new List<User>();
            var result = await botClient.GetUserDetailsAsync();
            if (result != null)
            {
                list = result.
                    .Where(x => x.GetType() == typeof(TLUser))
                    .Cast<TLUser>().Select(x => new User()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Phone = x.Phone,
                        Username = x.Username
                    }).ToList();
            }

            return list;
        }*/
    }
}
