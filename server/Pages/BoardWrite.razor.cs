using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using server.DB;
using server.DB.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components.Forms;

namespace server.Pages
{
    public partial class BoardWrite
	{

        private WritingModel BoardInfo = new WritingModel();

       public string? InputTitleValue { get; set; }

		public string? InputContentValue { get; set; }

		public string? FileName { get; set; }

		private string ClearButtonStyle => string.IsNullOrEmpty(InputTitleValue) ? "display:none;" : "display:inline-block; border:none; background:transparent; position:absolute; top:12px; right:5px;";
		private void ClearInput()
		{
			InputTitleValue = string.Empty;
		}
		private async Task HandleFileChange(InputFileChangeEventArgs e)
		{
			var file = e.File;

			if (file != null)
			{
				FileName = file.Name;
				using (var memoryStream = new MemoryStream())
				{
					await file.OpenReadStream().CopyToAsync(memoryStream);
					// Now you have the file contents in the memoryStream,
					// and you can perform further operations, like sending the file to a server.
				}
			}
		}
	}

}
