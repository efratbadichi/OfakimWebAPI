using OfakimAPI.App_Code;
using OfakimAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OfakimAPI.Controllers
{
    public class UsersFileController : ApiController
    {
        // GET: api/UsersFile
        public IEnumerable<UserEntity> Get()
        {
            //get content from file system
            FileManager fm = new FileManager();

            List<UserEntity> result= fm.GetUsersFromFile();
            return result.OrderBy(user => user.Id);
        }
       

        // POST: api/UsersFile
        public IHttpActionResult Post(UserEntity user)
        {
            FileManager fm = new FileManager();
            
            //get current users
            List<UserEntity> users = fm.GetUsersFromFile();
            
            //add new user and set id
            user.Id = Utils.GetLastId(users);
            user.Id++;
            users.Add(user);

            //update file
            fm.UpdateFile(users);

            return Ok(user);
        }

      
    }
}
