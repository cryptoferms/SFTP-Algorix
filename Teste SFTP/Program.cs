using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SFTP_Algorix;
namespace Teste_SFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            SFTPUpload.Upload();

            Console.ReadLine();
        }
    }
}
