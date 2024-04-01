using CVApp.Server.Dtos.Requests;
using CVApp.Server.Dtos.Responses;
using CVApp.Server.Common;
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
        
        [DllImport("CSDELPREngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CSDELPREngineProcess(byte[] pbGray, int w, int h, ref CARPLATEDATA carPlateData);

        [HttpPost]
        public async Task<ActionResult> GetLPRResult([FromBody] LPRRequest request)
        {
            LPRResponse response = new LPRResponse();
            response.code = 200;
            Image image = null;
            if (request.image_url != null && request.image_url != "") 
            {
                image = Utils.GetImageFromUrl(request.image_url);
                //image.Save("image.jpg");
            }
            else
            {
                image = Utils.GetImageFromBase64(request.image_base64);
            }

            
            if(image == null)
            {
                response.Errors.Add("Image is not valid.");
                return Ok(response);
            }
            
            Mat grayImage = Utils.GetGrayMatFromSDImage(image);

            CARPLATEDATA carPlateData = new CARPLATEDATA();
            int nPlates = CSDELPREngineProcess(grayImage.GetRawData(), grayImage.Cols, grayImage.Rows, ref carPlateData);
            if(nPlates > 0) {
                string strProcTime = carPlateData.nProcTime.ToString() + "ms";
                response.carPlateData = new RESCARPLATEDATA(nPlates, strProcTime);
                
                for(int i = 0; i < nPlates; i++)
                {
                    response.carPlateData.pPlate[i] = carPlateData.pPlate[i];
                }
            }
            return Ok(response);
        }
    }
}
