using System.Windows.Media.Imaging;

namespace PB.RevitWPFFW.res
{
    /// <summary>
    /// Gets an embedded image from the .res assembly based on a file name and extension
    /// </summary>
    public static class ResourceImage
    {
        /// <summary>
        /// Gets an icon image from a resource assembly
        /// </summary>
        /// <param name="name">File name</param>
        /// <returns>Bitmap Image</returns>
        public static BitmapImage GetIcon(string name)
        {
            //Create the resource reader stream
            var stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNameSpace() + "Images.Icons." + name);
            var image = new BitmapImage();

            //If image cannot be found, return null
            try
            {
                //Construct and return image
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                //return constructed BitmapImage
                return image;
            }
            catch
            {
                return null;
            }
        }

    }
}
