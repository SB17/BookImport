namespace BookImport
{
    public class WebClientDownloader : IFileDownloader
    {

        readonly string Url;

        public WebClientDownloader(string Url)
        {
            this.Url = Url ?? throw new ArgumentNullException(nameof(Url));
        }

        public string DownloadFile()
        {
            
            
            var content = String.Empty;
            try
            {
                using (var client = new System.Net.WebClient())
                {
                   content = client.DownloadString(Url);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File could not be downloaded");
            }

            return content;
        }
    }
}