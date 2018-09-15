using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RepoInsight.Avalonia.View
{
    public class FileOverviewView : UserControl
    {
        public FileOverviewView()
        {
            this.InitializeComponent();
            this.DataContext = new FileOverviewViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
