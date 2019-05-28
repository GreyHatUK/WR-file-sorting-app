using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_file_sorting_app.Model
{

    //id,client_id, datetime_from, datetime_to,client_ name
    public class CareVisitModel
    {

        public CareVisitModel(string id, string clientId, string startTime, string endTime, string clientName)
        {
            int iTemp = 0;
            DateTime dTemp = new DateTime();
            InvalidTimes = false;

            if (int.TryParse(id, out iTemp))
            {
                Id = iTemp;
            }
            if (int.TryParse(clientId, out iTemp))
            {
                ClientId = iTemp;
            }
            StartString = startTime;
            if (DateTime.TryParse(startTime, out dTemp))
            {
                Start = dTemp;
            }
            else
            {
                if (DateTime.TryParseExact(startTime, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None,  out dTemp))
                {
                    Start = dTemp;
                }
                else
                {
                    InvalidTimes = true;
                }
            }
            EndString = endTime;
            if (DateTime.TryParse(endTime, out dTemp))
            {
                End = dTemp;
            }
            else
            {
                if (DateTime.TryParseExact(endTime, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dTemp))
                {
                    End = dTemp;
                }
                else
                {
                    InvalidTimes = true;
                }
            }
            if (Start > End) InvalidTimes = true;
            ClientName = clientName;
        }
        public int Id { get; set; }
        public int ClientId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string StartString { get; set; }

        public string EndString { get; set; }

        public string ClientName { get; set; }

        public bool InvalidTimes { get; set; }

    }
}
