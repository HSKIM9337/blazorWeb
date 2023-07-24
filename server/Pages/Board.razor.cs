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
	}
}
