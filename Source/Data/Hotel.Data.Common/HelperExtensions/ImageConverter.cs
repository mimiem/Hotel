namespace Hotel.Data.Common.HelperExtensions
{
    using System.IO;
    using System.Drawing;

    public class ImageConverter
    {
        public static byte[] ImageToByteArray(string path)
        {
            Image img = Image.FromFile(path);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
