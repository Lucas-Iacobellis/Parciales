using System.Windows.Forms;

namespace Entidades.Extension
{
    public static class PictureBoxExtensions
    {
        public static string ObtenerUltimoCaracterDelNombre(this PictureBox pictureBox)
        {
            return pictureBox.Name.Substring(pictureBox.Name.Length - 1, 1);
        }
    }
}
