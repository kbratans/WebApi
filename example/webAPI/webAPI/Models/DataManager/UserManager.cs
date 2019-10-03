using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.Repository;

namespace webAPI.Models.DataManager
{
    public class UserManager: IDataRepository<Users>
    {
        readonly UsersContext _userContext;

        public UserManager(UsersContext context)
        {
            _userContext = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public Users Get(int id)
        {
            return _userContext.Users
                  .FirstOrDefault(e => e.ID == id);
        }

        public void Add(Users entity)
        {
            _userContext.Users.Add(entity);
            _userContext.SaveChanges();
        }

        public void Update(Users users, Users entity)
        {
            users.UserName = entity.UserName;
            users.Name = entity.Name;
            users.Surname = entity.Surname;
            users.IsDeleted = entity.IsDeleted;


            _userContext.SaveChanges();
        }

        public void Delete(Users employee)
        {
            _userContext.Users.Remove(employee);
            _userContext.SaveChanges();
        }



    }
}
