using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
     class PhoneBook
     {
         private List<Contact> _contacts { get; set; } = new List<Contact>();

        private void DisplayContactDetails(Contact contact)
        {
            if (contact == null) return;
            Console.WriteLine($"Rehber: {contact.Name},{contact.Number}");
        }

        private bool DisplayContactsDetails(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Rehber Boş!");
                return false;
            }

            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }

            return true;
        }
        public bool AddContact(Contact contact)
        {
            if ((contact.Name == null || contact.Name == "") && (contact.Number == null || contact.Number == ""))
            {
                Console.WriteLine("İsim ve Numara Boş Olamaz");
                return false;
            } 
            else if (contact.Name == null || contact.Name == "")
            {
                Console.WriteLine("İsim Boş Olamaz");
                return false;
            } else if (contact.Number == null || contact.Number == "")
            {
                Console.WriteLine("Numara Boş Olamaz");
                return false;
            } else {
                    _contacts.Add(contact);
                    return true;
            }
        }

        public void DisplayContact(string number)
        {
            var contact = _contacts.FirstOrDefault(c => c.Number == number);
            if (contact == null)
            {
                Console.WriteLine("Kişi Bulunamadı!");
            }
            else
            {
                DisplayContactDetails(contact);
            }
            
            
        }

        public void DisplayAllContact()
        {
            DisplayContactsDetails(_contacts);
        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            if (!string.IsNullOrWhiteSpace(searchPhrase)) // İsim boş veya sadece boşluktan oluşmuyorsa devam et
            {
                var matchingContacts = _contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();
                if (matchingContacts.Count > 0)
                {
                    DisplayContactsDetails(matchingContacts);
                }
                else
                {
                    Console.WriteLine("Böyle bir kişi bulunamadı");
                }
            }
            else
            {
                Console.WriteLine("Lütfen bir isim girin"); // İsim boş ise hata mesajı ver
            }

        }

        public void deleteContact(string name)
        {
            var contact = _contacts.FirstOrDefault(c => c.Name == name);
            if (contact == null)
            {
                Console.WriteLine("Kişi Bulunamadı!");
            }
            else
            {
                _contacts.Remove(contact);
                Console.WriteLine("Kişi Rehberden Silindi");
            }

        }

        public void changeNumber(string name)
        {
            var contact = _contacts.FirstOrDefault(c => c.Name == name);
            if (contact == null)
            {
                Console.WriteLine("Kişi Bulunamadı!");
            }
            else
            {
                Console.WriteLine("Yeni Numarayı Giriniz");
                var newNumber = Console.ReadLine();
                Console.WriteLine("Kişinin eski numarası " + contact.Number + " idi.");
                contact.Number = newNumber;
                Console.WriteLine("Kişinin numarası " + contact.Number + " olarak değiştirildi");
                Console.WriteLine();
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("Bir işlem seçiniz:");
            Console.WriteLine("1 - Kişi Ekle");
            Console.WriteLine("2 - Kişiyi Numarasından Bul");
            Console.WriteLine("3 - Tüm Kişileri Göster");
            Console.WriteLine("4 - Bir Kişiyi Adı ile Bul");
            Console.WriteLine("5 - Kişiyi Rehberden Sil");
            Console.WriteLine("6 - Kişinin Numarasını Değiştir");
            Console.WriteLine("m - Menüyü Tekrar göster");
            Console.WriteLine("r - Kullanıcı Çıkışı Yap");
            Console.WriteLine("d - Kullanıcıyı Sil");
            Console.WriteLine("x - Çıkış");
            Console.WriteLine("");
            
        }

       
    }
}

