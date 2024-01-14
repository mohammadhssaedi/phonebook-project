using System;
using TelefonRehberi;

namespace PhonebookConsole
{
    class Program
    {

        private static string cypherizedPass()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            } while (true);
            return pass;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Telefon Rehberi Uygulamasına Hoş Geldiniz!");
            UserAuthentication userAuthentication = new UserAuthentication();

            // Kullanıcı kaydı yapma veya giriş yapma döngüsü
            while (true)
            {
                Outerloop:
                Console.WriteLine("1. Kayıt Ol");
                Console.WriteLine("2. Giriş Yap");
                Console.WriteLine("x. Çıkış");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Kullanıcı adı giriniz:");
                        var newUsername = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz:");
                        var newPassword = cypherizedPass();

                        // Yeni kullanıcı oluştur
                        User newUser = new User(newUsername, newPassword);

                        // Kullanıcıları yönet
                        userAuthentication.RegisterUser(newUser);

                        Console.WriteLine("Kullanıcı başarıyla kaydedildi.");
                        break;

                    case "2":
                        if (userAuthentication == null)
                        {
                            Console.WriteLine("Henüz bir kullanıcı oluşturulmamış.");
                            continue;
                        }

                        Console.WriteLine("Kullanıcı adı giriniz:");
                        var enteredUsername = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz:");
                        var enteredPassword = cypherizedPass();
                        PhoneBook userPhonebook = userAuthentication.AuthenticateUser(enteredUsername, enteredPassword);
                        
                    // Giriş başarılı, telefon uygulaması döngüsü

                        if (userPhonebook != null)
                        {
                            Console.WriteLine("Giriş başarılı");
                            
                            while (true)
                            {
                                PhoneLoop:
                                userPhonebook.ShowMenu();
                                var userInput = Console.ReadLine();

                                switch (userInput)
                                {
                                    case "1":
                                        Console.WriteLine("Kişi Adı:");
                                        var name = Console.ReadLine();
                                        Console.WriteLine("Kişi Numarası:");
                                        var number = Console.ReadLine();

                                        var newContact = new Contact(name, number);
                                        userPhonebook.AddContact(newContact);
                                        break;

                                    case "2":
                                        Console.WriteLine("Aranan kişinin Numarasını Giriniz:");
                                        var searchNumber = Console.ReadLine();
                                        if (searchNumber == null || searchNumber == "")
                                        {
                                            Console.WriteLine("Lütfen aranacak numarayı doğru giriniz");
                                        }
                                        else
                                        {
                                            userPhonebook.DisplayContact(searchNumber);
                                        }

                                        break;

                                    case "3":
                                        userPhonebook.DisplayAllContact();
                                        break;

                                    case "4":
                                        Console.WriteLine("Kişinin Adını Giriniz:");
                                        var searchPhrase = Console.ReadLine();
                                        userPhonebook.DisplayMatchingContacts(searchPhrase);
                                        break;
                                    case "5":
                                        Console.WriteLine("Silmek istediğiniz kişinin ismini giriniz");
                                        var nameToDelete = Console.ReadLine();
                                        userPhonebook.deleteContact(nameToDelete);
                                        break;
                                    case "6":
                                        Console.WriteLine("Değiştirmek istediğiniz kişinin adını yazınız");
                                        var nameToChangeNumber = Console.ReadLine();
                                        userPhonebook.changeNumber(nameToChangeNumber);
                                        break;

                                    case "m":
                                        userPhonebook.ShowMenu();
                                        break;

                                    case "x":
                                        return;
                                    case "d": 
                                        var deleteStatus = userAuthentication.DeleteUser(userPhonebook);
                                        if (deleteStatus)
                                        {
                                            goto Outerloop;
                                        }
                                        else
                                        {
                                            goto PhoneLoop;
                                        }
                                    case "r":
                                        goto Outerloop;

                                    default:
                                        Console.WriteLine("Hata: Geçerli bir işlem seçiniz");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Kullanıcı adı veya şifre hatalı");
                        }

                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("Hata: Geçerli bir seçenek giriniz");
                        break;
                }
            }
        }
    }
}
