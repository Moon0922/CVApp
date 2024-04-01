using CVApp.Server.Dtos.Requests;
using CVApp.Server.Dtos.Responses;
using Emgu.CV.Structure;
using Emgu.CV;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CVApp.Server.Controllers
{

    [Route("api/lpr")]
    [ApiController]
    public class LPRController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LPRController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private Mat GetMatFromSDImage(Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            Image<Gray, Byte> grayImage = cvImage.Convert<Gray, Byte>();
            return grayImage.Mat;
        }

        [DllImport("CSDELPREngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSDELPREngineProcess(byte[] pbGray, int w, int h, ref CARPLATEDATA carPlateData);

        [HttpPost]
        public async Task<ActionResult> GetLPRResult([FromBody] LPRRequest request)
        {
            Image image = Base64ToImage(request.image_base64);
            Mat grayImage = GetMatFromSDImage(image);

            CARPLATEDATA carDate = new CARPLATEDATA();
            //carPlateDate.nPlateCount = 3;
            int nPlates = CSDELPREngineProcess(grayImage.GetRawData(), grayImage.Cols, grayImage.Rows, ref carDate);

            //Console.WriteLine(carPlateDate.pPlate[0].szLicense);

            LPRResponse result = new LPRResponse();
            if(nPlates > 0) {
                result.carPlateData = new RESCARPLATEDATA(nPlates);
                for(int i = 0; i < nPlates; i++)
                {
                    result.carPlateData.pPlate[i]
                }
            }
            
            
            return Ok(result);
        }
    }
}
