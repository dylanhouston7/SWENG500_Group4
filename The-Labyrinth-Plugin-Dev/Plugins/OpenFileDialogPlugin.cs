using System.Windows.Forms;

namespace Plugins
{
    public class OpenFileDialogPlugin
    {
        public static void OpenFile(out string file, string initial_directory = "C:\\", string filter = "(*.*)|*.*")
        {
            file = null;

            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.InitialDirectory = initial_directory;
            open_file_dialog.Filter = filter;

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                file = open_file_dialog.FileName;
            }
        }
    }
}
