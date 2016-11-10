using System.Windows.Forms;

namespace Plugins
{
    public class FileDialogs
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

        public static void SaveFile(out string file, string initial_directory = "C:\\", string filter = "(*.*)|*.*")
        {
            file = null;

            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.InitialDirectory = initial_directory;
            save_file_dialog.Filter = filter;

            if(save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                file = save_file_dialog.FileName;
            }
        }
    }
}
