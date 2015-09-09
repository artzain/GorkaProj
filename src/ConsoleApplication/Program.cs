using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Controllers;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApplication
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// These are the authorisation properties of your app.
			// You can find the values in the App Center when you are maintaining the app.
			const string clientId = "448fa0f2-988f-48e7-a6db-1bb075036d73";
			const string clientSecret = "yz45UT0HVRUz";

			// This can be any url as long as it is identical to the callback url you specified for your app in the App Center.
			var callbackUrl = new Uri("https://github.com/artzain/gorkasapp.git");

			var connector = new Connector(clientId, clientSecret, callbackUrl);
			var client = new ExactOnlineClient(connector.EndPoint, connector.GetAccessToken);

			// Get the Code and Name of a random account in the administration
			var fields = new[] { "Code", "Name" };
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();

			Debug.WriteLine("Account {0} - {1}", account.Code.TrimStart(), account.Name);
		}

		private void DownloadFile()
        {
            OAuthUtility.GetAsync("https://api.dropboxapi.com/1/metadata/auto/",
                new HttpParameterCollection {
                    {"path", "https://www.dropbox.com/s/3m8738gnkikx14w/exactonline-api-dotnet-client.zip?dl=0" },
                    {"list", "true" },
                    {"access_token",Properties.Settings.Default.AccessToken }
                } ,
            callback: Result);
        }

	}
}
