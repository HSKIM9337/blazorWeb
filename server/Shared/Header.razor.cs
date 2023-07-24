using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace server.Shared
{
	public partial class Header
	{
		[Inject]
		public IJSRuntime? JSRuntime { get; set; }

		private IJSObjectReference _jsModule;
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/menutrigger.js");
			}
		}
		private int activeMenuItem { get; set; } = 0;

		private void SetActiveMenuItem(int menuItemID)
		{
			this.activeMenuItem = menuItemID;
		}

		public string IsActiveMenuItem(int menuItemId)
		{
			return activeMenuItem == menuItemId ? "active" : "";
		}

		public async Task ToggleMenu() =>
			await _jsModule.InvokeVoidAsync("menutrigeer");

	}
}
