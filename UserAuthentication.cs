using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    internal class UserAuthentication
    {
        private List<User> _registeredUsers;

        public UserAuthentication()
        {
            _registeredUsers = new List<User>();
        }

        public void RegisterUser(User user)
        {
            _registeredUsers.Add(user);
        }

        public PhoneBook AuthenticateUser(string enteredUsername, string enteredPassword)
        {
            foreach (User user in _registeredUsers)
            {
                if (user.Username == enteredUsername && user.Password == enteredPassword)
                {
                    return user.PhoneBook;
                }
            }

            Console.WriteLine("Giriş bilgileri yanlış");
            return null;
        }

        public bool DeleteUser(PhoneBook phoneBook)
        {
            foreach (User user in _registeredUsers)
            {
                if (user.PhoneBook == phoneBook)
                {
                    Console.WriteLine("Kullanıcıyı silmek istediğinize emin misiniz?");
                    Console.WriteLine("1 - Evet");
                    Console.WriteLine("2 - Hayır");
                    var userInput = Console.ReadLine();
                    if (userInput == "1")
                    {
                        _registeredUsers.Remove(user);
                        Console.WriteLine("Kullanıcı başarıyla silindi");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Kullanıcı silinmekten vazgeçildi, menüye dönülüyor.");
                        return false;
                    }
                    
                }
            }
            Console.WriteLine("Kullanıcı silinirken hata oluştu: Kullanıcı bulunamadı");
            return false;
        }
    }
}