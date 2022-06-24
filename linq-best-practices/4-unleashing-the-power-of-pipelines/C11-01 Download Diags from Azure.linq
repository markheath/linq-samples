<Query Kind="Statements">
  <NuGetReference>Azure.Storage.Blobs</NuGetReference>
  <Namespace>Azure.Storage.Blobs</Namespace>
  <Namespace>Azure.Storage.Blobs.Models</Namespace>
</Query>

var connectionString = Util.GetPassword("Skype Voice Changer Connection String");
var downloadFolder = 
	Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"SkypeVoiceChanger","diags");
Directory.CreateDirectory(downloadFolder);

var diagsClient = new BlobContainerClient(connectionString, "diags");

var logFiles = diagsClient.GetBlobs(prefix: "skypevoicechangerpro/2016/01")
				.Select(b => new { Blob = b, 
					Name = String.Join("-", b.Name.Split('/').Take(5)) + ".csv" })
				.Where(b => !File.Exists(Path.Combine(downloadFolder, b.Name)));

foreach(var b in logFiles)
{
	Console.WriteLine($"Downloading {b.Name}");
	var path = Path.Combine(downloadFolder,b.Name);
	new BlobClient(connectionString, diagsClient.Name, b.Blob.Name).DownloadTo(path);
}