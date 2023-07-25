using Microsoft.JSInterop;

namespace server.Pages
{
	public partial class Board
	{

		private string _showedText = "Notice";

		private bool _headerTextUnderLined = true;
		public string ShowedText { get { return _showedText; } set { _showedText = value; } }

		private void UpdateHeaderText(string clickedText)
		{
			this.ShowedText = clickedText;
			_headerTextUnderLined = true;

        }
		private async Task OpenNewPage()
		{
			string url = "/boardwrite"; 
			await JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
		}
	}
}
