namespace TelefonRehberi
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public PhoneBook PhoneBook { get; set; } 

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            PhoneBook = new PhoneBook(); 
        }
    }
}