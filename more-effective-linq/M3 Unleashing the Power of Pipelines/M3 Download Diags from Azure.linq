<Query Kind="Statements">
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob</Namespace>
</Query>

var storageAccountName = "skypevoicechanger";
var accessKey = Util.GetPassword("Skype Voice Changer Storage Key");
var connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
	storageAccountName,
	accessKey);
var storageAccount = CloudStorageAccount.Parse(connectionString);
var blobClient = storageAccount.CreateCloudBlobClient();
var diagsContainer = blobClient.GetContainerReference("diags");
var downloadFolder = 
	Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"SkypeVoiceChanger","diags");
Directory.CreateDirectory(downloadFolder);

var logFiles = diagsContainer.ListBlobs("skypevoicechangerpro/2015/02", true)
				.OfType<CloudBlockBlob>()
				.Select(b => new { Blob = b, 
					Name = String.Join("-", b.Name.Split('/').Take(5)) + ".csv" })
				.Where(b => !File.Exists(Path.Combine(downloadFolder, b.Name)));

foreach(var b in logFiles)
{
	Console.WriteLine($"Downloading {b.Name}");
	b.Blob.DownloadToFile(Path.Combine(downloadFolder,b.Name),FileMode.CreateNew);
}