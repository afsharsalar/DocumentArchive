namespace App.Models.Base
{
    public class BreadcrumbModel
    {
        public string Title { get; set; }



		public List<(string Name, string Url)> Urls { get; set; }
	}
}
