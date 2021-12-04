using LoveFinder.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class User
    {
        public string mail { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public string sexualOrientation { get; set; }
        public string bio { get; set; }
        public List<User> users = new List<User>();

        public User(string _mail, string _password, string _firstname, string _lastname, int _age, string _gender, string _sexualOrientation)
        {
            mail = _mail;
            password = _password;
            firstname = _firstname;
            lastname = _lastname;
            age = _age;
            gender = _gender;
            sexualOrientation = _sexualOrientation;
        }
        public void CreateAccount(User newUser)
        {
            users.Add(newUser);
        }
        public void DeleteAccount(User deluser)
        {
            users.Remove(deluser);
        }
        public bool Login(string inputMail, string inputPassword)
        {
            var user = users.Find(x => x.mail == inputMail);
            if(inputMail == user.mail && inputPassword == user.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User FindUser(string mail)
        {
            User user = null;
            try
            {
                user = users.Find(x => x.mail == mail);
            }
            finally
            {
                
            }
            return user;
        }
        public void EditUser(User currentuser, string bio, string age)
        {
            int ctr = -1;
            foreach(User user in users)
            {
                ctr++;
                if(user.mail == currentuser.mail)
                {
                    break;
                }
            }
            users[ctr].bio = bio;
            try
            {
                users[ctr].age = Int32.Parse(age);
            }
            catch
            {

            }
        }
    }
}
