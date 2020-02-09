using System;
using System.Security.Cryptography;
using System.Text;


//This class is used for hashing passwords or digital signatures before storing them into the database
//The alghoritam uses SHA256 hashing
//Hashing is a one way street, try to be carefull what data are you going to hash
//If hashing is for passwords, try to add some salt, HASHING + SALT works great
//Why to use salt, if the database is displaying hashed passwords, it can be read if someone has the same password


namespace TestingSM
{
    class Program
    {
        public bool cSalt;
        static void Main(string[] args)
        {
            string txtToHash = null;
            string hashedTxt = null;
            string customSaltTxt = null;
            bool custSalt;

            HashString();


            void HashString()
            {


                HashingClass hashClass = new HashingClass();
                Console.Write("Enter the text to be hashed: ");
                txtToHash = Console.ReadLine();


                Console.Write("Add custom salt? y/n: ");
                string ynC = Console.ReadLine();
                if (ynC == "y") { 
                    hashClass.custSaltBool = true;
                    Console.Write("Enter custom salt: ");
                    customSaltTxt = Console.ReadLine();
                    txtToHash = txtToHash + customSaltTxt;
                    hashedTxt = hashClass.HashString(txtToHash);
                }
                else
                {
                    hashedTxt = hashClass.HashString(txtToHash);
                }

                if (ynC == "n") { 
                Console.WriteLine(hashedTxt +" --- "+ hashClass.finalString);
                WriteToFile(hashedTxt+" - - - "+hashClass.finalString);
                }

                else if (ynC == "y")
                {
                    Console.WriteLine(hashedTxt + " --- " + customSaltTxt);
                    WriteToFile(hashedTxt + " - - - " + customSaltTxt);
                }


                Console.WriteLine("Hash another text? y/n ");
                string yn = Console.ReadLine();

                if (yn == "y")
                    HashString();
            }


            DatabaseClass db = new DatabaseClass();
            db.ConnectToDB();


            void WriteToFile(string text)
            {
                string readFile = System.IO.File.ReadAllText(@"C:\Users\Sebastian\Desktop\file.txt");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Sebastian\Desktop\file.txt"))
                {
                    file.WriteLine(readFile
                        +text);

                }
            }
        }
    }
}
