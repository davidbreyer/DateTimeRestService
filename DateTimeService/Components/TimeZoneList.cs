using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeService.Components
{
    public class TimeZoneList
    {
        public Dictionary<string, string> TimeZones { get; set; }

        public TimeZoneList()
        {
            TimeZones = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            TimeZones.Add("DST", "Dateline Standard Time");
            TimeZones.Add("UTC11", "UTC-11");
            TimeZones.Add("HAST", "Hawaiian Standard Time");
            TimeZones.Add("ALST", "Alaskan Standard Time");
            TimeZones.Add("PSTM", "Pacific Standard Time (Mexico)");
            TimeZones.Add("PST", "Pacific Standard Time");
            TimeZones.Add("USMT", "US Mountain Standard Time");
            TimeZones.Add("MSTM", "Mountain Standard Time (Mexico)");
            TimeZones.Add("MST", "Mountain Standard Time");
            TimeZones.Add("CAST", "Central America Standard Time");
            TimeZones.Add("CST", "Central Standard Time");
            TimeZones.Add("CSTM", "Central Standard Time (Mexico)");
            TimeZones.Add("CCST", "Canada Central Standard Time");
            TimeZones.Add("SAPST", "SA Pacific Standard Time");
            TimeZones.Add("EST", "Eastern Standard Time");
            TimeZones.Add("USEST", "US Eastern Standard Time");
            TimeZones.Add("VST", "Venezuela Standard Time");
            TimeZones.Add("PSTP", "Paraguay Standard Time");
            TimeZones.Add("AST", "Atlantic Standard Time");
            TimeZones.Add("CBST", "Central Brazilian Standard Time");
            TimeZones.Add("SAWST", "SA Western Standard Time");
            TimeZones.Add("PSAST", "Pacific SA Standard Time");
            TimeZones.Add("NST", "Newfoundland Standard Time");
            TimeZones.Add("ESAST", "E. South America Standard Time");
            TimeZones.Add("ARGST", "Argentina Standard Time");
            TimeZones.Add("SAEST", "SA Eastern Standard Time");
            TimeZones.Add("GRST", "Greenland Standard Time");
            TimeZones.Add("MONST", "Montevideo Standard Time");
            TimeZones.Add("BAHST", "Bahia Standard Time");
            TimeZones.Add("UTC02", "UTC-02");
            TimeZones.Add("MATST", "Mid-Atlantic Standard Time");
            TimeZones.Add("AZOST", "Azores Standard Time");
            TimeZones.Add("CVST", "Cape Verde Standard Time");
            TimeZones.Add("MOST", "Morocco Standard Time");
            TimeZones.Add("UTC", "UTC");
            TimeZones.Add("GMT", "GMT Standard Time");
            TimeZones.Add("GST", "Greenwich Standard Time");
            TimeZones.Add("WEST", "W. Europe Standard Time");
            TimeZones.Add("CEST", "Central Europe Standard Time");
            TimeZones.Add("RST", "Romance Standard Time");
            TimeZones.Add("CEUROST", "Central European Standard Time");
            TimeZones.Add("WEAST", "W. Central Africa Standard Time");
            TimeZones.Add("NAMST", "Namibia Standard Time");
            TimeZones.Add("GTB", "GTB Standard Time");
            TimeZones.Add("MEST", "Middle East Standard Time");
            TimeZones.Add("EGST", "Egypt Standard Time");
            TimeZones.Add("SYST", "Syria Standard Time");
            TimeZones.Add("EEST", "E. Europe Standard Time");
            TimeZones.Add("SOAST", "South Africa Standard Time");
            TimeZones.Add("FLEST", "FLE Standard Time");
            TimeZones.Add("TUST", "Turkey Standard Time");
            TimeZones.Add("ISST", "Israel Standard Time");
            TimeZones.Add("LIST", "Libya Standard Time");
            TimeZones.Add("JOST", "Jordan Standard Time");
            TimeZones.Add("ARABICST", "Arabic Standard Time");
            TimeZones.Add("KALST", "Kaliningrad Standard Time");
            TimeZones.Add("ARABST", "Arab Standard Time");
            TimeZones.Add("EAFST", "E. Africa Standard Time");
            TimeZones.Add("IRST", "Iran Standard Time");
            TimeZones.Add("ARST", "Arabian Standard Time");
            TimeZones.Add("AZST", "Azerbaijan Standard Time");
            TimeZones.Add("RUSST", "Russian Standard Time");
            TimeZones.Add("MAUST", "Mauritius Standard Time");
            TimeZones.Add("GEST", "Georgian Standard Time");
            TimeZones.Add("CAUCST", "Caucasus Standard Time");
            TimeZones.Add("AFST", "Afghanistan Standard Time");
            TimeZones.Add("WASST", "West Asia Standard Time");
            TimeZones.Add("PAKST", "Pakistan Standard Time");
            TimeZones.Add("INST", "India Standard Time");
            TimeZones.Add("SRILST", "Sri Lanka Standard Time");
            TimeZones.Add("NEPST", "Nepal Standard Time");
            TimeZones.Add("CEASST", "Central Asia Standard Time");
            TimeZones.Add("BAST", "Bangladesh Standard Time");
            TimeZones.Add("EKST", "Ekaterinburg Standard Time");
            TimeZones.Add("MYST", "Myanmar Standard Time");
            TimeZones.Add("SEASST", "SE Asia Standard Time");
            TimeZones.Add("NCAST", "N. Central Asia Standard Time");
            TimeZones.Add("CHST", "China Standard Time");
            TimeZones.Add("NASST", "North Asia Standard Time");
            TimeZones.Add("SIST", "Singapore Standard Time");
            TimeZones.Add("WAUST", "W. Australia Standard Time");
            TimeZones.Add("TAIST", "Taipei Standard Time");
            TimeZones.Add("ULST", "Ulaanbaatar Standard Time");
            TimeZones.Add("NAEST", "North Asia East Standard Time");
            TimeZones.Add("TOKST", "Tokyo Standard Time");
            TimeZones.Add("KOST", "Korea Standard Time");
            TimeZones.Add("CAUST", "Cen. Australia Standard Time");
            TimeZones.Add("AUSCST", "AUS Central Standard Time");
            TimeZones.Add("EAUST", "E. Australia Standard Time");
            TimeZones.Add("AUSEST", "AUS Eastern Standard Time");
            TimeZones.Add("WPST", "West Pacific Standard Time");
            TimeZones.Add("TAST", "Tasmania Standard Time");
            TimeZones.Add("YAST", "Yakutsk Standard Time");
            TimeZones.Add("CPST", "Central Pacific Standard Time");
            TimeZones.Add("VLST", "Vladivostok Standard Time");
            TimeZones.Add("NZST", "New Zealand Standard Time");
            TimeZones.Add("UTC12", "UTC+12");
            TimeZones.Add("FST", "Fiji Standard Time");
            TimeZones.Add("MAGST", "Magadan Standard Time");
            TimeZones.Add("KAST", "Kamchatka Standard Time");
            TimeZones.Add("TOST", "Tonga Standard Time");
            TimeZones.Add("SAST", "Samoa Standard Time");
        }
    }
}