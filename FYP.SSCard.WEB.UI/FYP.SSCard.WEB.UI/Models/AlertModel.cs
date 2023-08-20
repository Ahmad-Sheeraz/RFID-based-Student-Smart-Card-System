using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP.SSCard.WEB.UI.Models
{
    public class AlertModel
    {
        public AlertModel() { }

        public AlertModel(string message, AlertType type)
        {
            switch (type)
            {
                case AlertType.Error:
                    cssClass = "alert-danger";
                    heading = "Error!";
                    icon = "glyphicon-remove-sign";
                    break;
                case AlertType.Success:
                    cssClass = "alert-success";
                    heading = "Success!";
                    icon = "glyphicon-check";
                    break;
                case AlertType.Warning:
                    cssClass = "alert-warning";
                    heading = "Warning!";
                    icon = "glyphicon-warning-sign";
                    break;
                default:
                    cssClass = "alert-info";
                    heading = "Information!";
                    icon = "glyphicon-exclamation-sign";
                    break;
            }
            this.message = message;
        }

        private string heading;
        public string Heading { get { return heading; } }

        private string icon;
        public string Icon { get { return icon; } }


        private string message;
        public string Message { get { return message; } }

        private string cssClass;
        public string CSSClass { get { return cssClass; } }

        public enum AlertType
        {
            Success,
            Information,
            Error,
            Warning
        }
    }
}