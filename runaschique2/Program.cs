//Autor Alexandre D'Amato, Unix SYSADMIN.
//2016/02/027
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Security;

namespace MyProcessSample
{
	class MyProcess
	{
		public static void Main(string[] args)
		{
			string usuario, senha, dominio, path, processo, argumentos;
			if (args.Length == 0) {
				Console.WriteLine ("Erro na inicializacao. zero argumentos foram informados");
				Console.WriteLine ("HELP::");
				Console.WriteLine ("<programa> dominio usuario senha path processo args");
				System.Environment.Exit (1);
			}
			dominio = args[0];
			usuario = args[1];
			senha = args[2];
			path = args[3];
			processo = args[4];

			argumentos = args[5];

			char[] text = senha.ToCharArray();
			SecureString secure = new SecureString();
			foreach (char c in text)
			{
				secure.AppendChar(c);
			}

			ProcessStartInfo myProcess = new ProcessStartInfo(path);
			myProcess.UserName = usuario;
			myProcess.Password = secure;
			myProcess.Domain = dominio;
			myProcess.FileName = processo;
			myProcess.WorkingDirectory = @path;
			myProcess.CreateNoWindow = true;
			myProcess.UseShellExecute = false;
			myProcess.Arguments = argumentos;
			Process.Start(myProcess);
		}
	}
}

