using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SFTP_Algorix
{
    public static class SFTPUpload
    {
        const string host = "18.230.14.154";
        const string username = "suporte";
        const string password = "suporte@algorix";
        const string uploadFile = @"G:\Icons\ui\triangle.png";
        const string remotepath = "/Algorix/";

        /// <summary>
        /// Metodo para enviar o arquivo para o server FTP
        /// </summary>
        public static void Upload()
        {
            //upload file para o server SFTP
            using (var client = new SftpClient(host, username, password))
            {
                client.Connect();
                Console.WriteLine("Conectado a {0}", host);

                client.ChangeDirectory(remotepath);
                Console.WriteLine("Mudança de diretório para {0}", remotepath);

                var listDirectory = client.ListDirectory(remotepath);

                Console.WriteLine("Listando o diretório");

                foreach (var file in listDirectory)
                {
                    Console.WriteLine(" - ", file.Name);
                }
                using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                {
                    Console.WriteLine("Uploading {0} ({1:N0} bytes)", uploadFile, fileStream.Length);
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                }
            }
        }
    }
}
