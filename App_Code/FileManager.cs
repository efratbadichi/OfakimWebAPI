using OfakimAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace OfakimAPI.App_Code
{
    public class FileManager
    {

        private readonly string _fileName;

        public FileManager()
        {
            //set file name from web.config app settings
            this._fileName = ConfigurationManager.AppSettings[Utils.AppSettingsKeys.FileName];
        }

        public List<UserEntity> GetUsersFromFile()
        {
            List<UserEntity> dflt  = new List<UserEntity>();

            if (!File.Exists(this._fileName))
                return dflt; 
            //read content from file to string
            string fileContent = File.ReadAllText(this._fileName);
            if (string.IsNullOrEmpty(fileContent))
                return dflt;

            //convert string to list of UserEntity
            List<UserEntity> result = Utils.ToObject<List<UserEntity>>(fileContent);
            if (result == null)
                result = dflt;

            //return list
            return result;
        }

        internal void UpdateFile(List<UserEntity> users)
        {
            //convert list of UserEntity to string
            string content = Utils.ToJson<List<UserEntity>>(users);

            //update file (create new one , or overwrite existing file)
            File.WriteAllText(_fileName, content);
        }
    }
}