using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace server.DB.Model
{
    public class WritingModel : ObservableRecipient
    {
        private string? _title = string.Empty;
        [Required(ErrorMessage = " You have to write at least 10 Letters")]
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string? _contents = string.Empty;
        [Required(ErrorMessage = " You have to write at least 10 Letters")]
        public string? Contents
        {
            get => _contents;
            set => SetProperty(ref _contents, value);
        }

        private string? _email = string.Empty;
        public string? Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

    }
}
