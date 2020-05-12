using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAPbobsCOM;

namespace VAC_InventoryTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        // POST: api/login
        [HttpGet]
        public IActionResult Post([FromBody] string username, string password)
        {
            Company VAC = new Company();
            try
            {
                VAC.CompanyDB = "AC_Test";
                VAC.Server = "SAPMAIN";
                VAC.LicenseServer = "SAPMAIN:30000";
                VAC.SLDServer = "SAPMAIN:40000";
                VAC.DbUserName = "sa";
                VAC.DbPassword = "ACVN1234~!";
                VAC.UserName = username;
                VAC.Password = password;
                VAC.DbServerType = BoDataServerTypes.dst_MSSQL2016;
                VAC.UseTrusted = false;
                int ret = VAC.Connect();
                string errMsg = VAC.GetLastErrorDescription();
                int errNo = VAC.GetLastErrorCode();
                if (errNo != 0)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}