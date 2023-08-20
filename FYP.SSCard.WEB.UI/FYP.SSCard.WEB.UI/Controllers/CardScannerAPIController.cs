using StudentSmartCard;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;

using System.Web.Mvc;

namespace FYP.SSCard.WEB.UI.Controllers
{
    public class CardScannerAPIController : Controller
    {
        SerialPort port = new SerialPort("COM6", 9600, Parity.None, 8, StopBits.One);

        // Add API will be called from card scanner code in C++
        [HttpGet]
        public string Add()
        {

            User user = (User)Session[WebUtil.CURRENT_USER];
            port.Open();
            var cardID = port.ReadLine();
            var processedBy = user.Id;
            port.Close();

            new CardsHandler().AddScnannedCardInformation(cardID, processedBy);
            return "card scanned successfully";
        }

        //public class CardScannerAPIController : Controller
        //{
        //    // Add API will be called from card scanner code in C++
        //    [HttpGet]
        //    public string Add(string cardId, int processedBy)
        //    {
        //        new CardsHandler().AddScnannedCardInformation(cardId, processedBy);
        //        return "card scanned successfully";
        //    }


        //}
    }
}
