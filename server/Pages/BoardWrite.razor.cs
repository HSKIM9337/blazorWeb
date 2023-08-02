using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using server.DB;
using server.DB.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components;


namespace server.Pages
{
    public partial class BoardWrite
	{
		private List<Post> posts;
		private Post newPost = new Post();
		[Inject]
		private ApplicationDbContext dbContext { get; set; }

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
		

		protected override async Task OnInitializedAsync()
		{
			posts = await dbContext.Posts.ToListAsync();
		}

		private async Task CreatePost()
		{
			// 게시글 생성
			newPost.CreatedAt = DateTime.Now;
			dbContext.Posts.Add(newPost);
			await dbContext.SaveChangesAsync();

			// 게시글 목록 갱신
			posts = await dbContext.Posts.ToListAsync();

			// 새 게시글 폼 초기화
			newPost = new Post();
		}

	}

}
