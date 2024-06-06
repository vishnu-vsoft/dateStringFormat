using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static format.Program.DateStringFormats;

namespace format
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DateStringFormatsResp dateStringFormat = DateStringFormats.GetAirline("555");
            Console.WriteLine(dateStringFormat.FlightScheduleFormat[1].ToString());
            //dd/MM/yyyy / HH:mm
            GetEventDateTime("12/02/2024 / 13:45","555");
            
            Console.ReadLine();
        }

        public enum Airline
        {
            Aeroflot,
            AirArabia,
            AirAsia,
            AmericanAirlines,
            BritishAirways,
            CathayCargoes,
            GulfAirCargoe,
            IndigoTracking,
            KuwaitAirwaysTracking,
            LOTPolishAirlinesCargo,
            LufthansaCargo,
            MalaysianAirways,
            NeoCargoTracking,
            NipponAirlinesCargo,
            ParcelsAppControl,
            QatarCargo,
            SingCargo,
            ThaiAirlines,
            TurkishCargo,
            UnitedCargoe,
            EmiratesSkyCargo,
            EthihadCargoTracking,
            JapanAirlines,
            KLMRoyalDutchCargo,
            CommonFormat,
            GoAirCargo,
            GulfAirCargo,
            SrilankanAirways,
            VirginAtlantic,
            OmanAirline,
            //not included in below dict 
            AirCanadaCargo,
            AirEuropaCargo,
            AirFrance,
            AirIndia,
            AkasaAir,
            EuropeanAirTransport,
            VistaraAirways,
            Ethihad
        }
        public static class DateStringFormats
        {

            private static readonly Dictionary<Airline, DateStringFormatsResp> formatMap = new Dictionary<Airline, DateStringFormatsResp>()
            {//01-Mar-2023 04:08 dd MMM yyyy
            { Airline.Aeroflot, new DateStringFormatsResp(){EventDateTime = "dd/MM/yyyy / HH:mm",FlightScheduleFormat=new string[] {  "dd/MM/yyyy / HH:mm", "dd/MM/yyyy"} } },
            { Airline.AirArabia, new DateStringFormatsResp(){EventDateTime ="dd MMM yyyy HH:mm",FlightScheduleFormat=new string[] { "dd MMM yyyy HH:mm" } } },
            { Airline.AirAsia, new DateStringFormatsResp(){EventDateTime = "dd MMM yyyy",FlightScheduleFormat= new string[] { "dd-MMM-yyyy HH:mm" } } },
            { Airline.AmericanAirlines, new DateStringFormatsResp(){EventDateTime = "dd-MMM-yyyy HH:mm:ss",FlightScheduleFormat=new string[] { "MM/dd/yyyy hh:mm tt" } } },
            { Airline.BritishAirways, new DateStringFormatsResp(){EventDateTime = "dd/MM/yyyy HH:mm",FlightScheduleFormat=new string[] { "dd/MM/yyyy HH:mm" } } },
            { Airline.CathayCargoes,new DateStringFormatsResp(){EventDateTime = "dd-MM-yyyy HH:mm:ss",FlightScheduleFormat = new string[] { "dd-MM-yyyy HH:mm:ss" } } },
            { Airline.GulfAirCargoe,new DateStringFormatsResp(){EventDateTime = "dd MMM yyyy HH:mm",FlightScheduleFormat = new string[] { "dd MMM yy HH:mm" } } },
            { Airline.IndigoTracking,new DateStringFormatsResp(){EventDateTime = "dd/MM/yyyy HH:mm",FlightScheduleFormat = new string[] { "dd/MM/yyyy HH:mm", "dd/MM/yyyy" } } },
            { Airline.KuwaitAirwaysTracking,new DateStringFormatsResp(){EventDateTime = "",FlightScheduleFormat = new string[] { "dd-MMM-yy HH:mm" } } },
            { Airline.LOTPolishAirlinesCargo,new DateStringFormatsResp(){EventDateTime = "",FlightScheduleFormat = new string[] { "ddMMyy HH:mm" } } },
            { Airline.LufthansaCargo,new DateStringFormatsResp(){EventDateTime = "dd MMM yy / HH:mm",FlightScheduleFormat = new string[]{"dd MMM yy / HH:mm"} } },
            { Airline.MalaysianAirways,new DateStringFormatsResp(){EventDateTime = "ddMMMyy",FlightScheduleFormat = new string[]{"ddMMMyy"} } },
            { Airline.NeoCargoTracking,new DateStringFormatsResp(){EventDateTime = "yyyy-MM-ddTHH:mm:ss",FlightScheduleFormat = new string[]{"yyyy-MM-ddTHH:mm:ss"} } },
            { Airline.NipponAirlinesCargo,new DateStringFormatsResp(){EventDateTime = "",FlightScheduleFormat = new string[]{ "dd MMM yyyy, HH:mm", "dd MMM, HH:mm" } } },
            { Airline.ParcelsAppControl,new DateStringFormatsResp(){EventDateTime = "dd MMM yyyy HH:mm",FlightScheduleFormat = new string[]{"dd MMM yyyy HH:mm"} } },
            { Airline.QatarCargo,new DateStringFormatsResp(){EventDateTime = "ddd, d MMM yyyy HH:mm",FlightScheduleFormat = new string[] { "dd-MMM-yyyy HH:mm" } } },
            { Airline.SingCargo,new DateStringFormatsResp(){EventDateTime = "dd MMMM yy | HH:mm",FlightScheduleFormat = new string[]{"dd MMM yy | HH:mm"} } },
            { Airline.ThaiAirlines,new DateStringFormatsResp() { EventDateTime = "dd MMM yyyy HH:mm",FlightScheduleFormat = new string[]{"ddMMMyyyy-HH:mm"} } },
            { Airline.TurkishCargo,new DateStringFormatsResp(){EventDateTime = "dd MMM yyyy HH:mm",FlightScheduleFormat = new string[] {"dd-MMM-yyyy HH:mm:ss 'LT'"} } },
            { Airline.UnitedCargoe,new DateStringFormatsResp(){EventDateTime = "yyyy-MM-dd HH:mm",FlightScheduleFormat = new string[]{"yyyy-MM-dd HH:mm:ss"} } },
            { Airline.EmiratesSkyCargo,new DateStringFormatsResp(){EventDateTime = "ddd, MMM d, yyyy",FlightScheduleFormat = new string[]{"HH:mm,ddd, MMM d, yyyy", "HH:mm,ddd, MMM dd, yyyy" } } },
            { Airline.EthihadCargoTracking,new DateStringFormatsResp(){EventDateTime = "dd-MM-yyyy HH:mm:ss",FlightScheduleFormat = new string[] { "dd-MMM-yyyy HH:mm" } } },
            { Airline.JapanAirlines,new DateStringFormatsResp(){EventDateTime = "ddMMM HH:mm",FlightScheduleFormat = new string[]{"ddMMM HH:mm"} } },
            { Airline.KLMRoyalDutchCargo,new DateStringFormatsResp(){EventDateTime = "dd MMM HH:mm",FlightScheduleFormat = new string[] { "dd-MM-yyyy HH:mm:ss" } } },
            { Airline.CommonFormat, new DateStringFormatsResp(){EventDateTime = " ", FlightScheduleFormat = new string[] {"dd/MM/yyyy","dd/MM/yyyy HH:mm"} } },
            { Airline.OmanAirline, new DateStringFormatsResp(){EventDateTime = " ", FlightScheduleFormat = new string[] { "dd/MM/yyyy HH:mm" } } },
            };

            private static readonly Dictionary<string, Airline> airlineMapper = new Dictionary<string, Airline>()
            {
            {"555",Airline.Aeroflot },
            {"514",Airline.AirArabia },
            {"807",Airline.AirAsia },
            {"091",Airline.AirAsia },
            {"843",Airline.AirAsia },
            {"014",Airline.AirCanadaCargo },
            {"996",Airline.AirEuropaCargo },
            {"057",Airline.AirFrance },
            {"098",Airline.AirIndia },
            {"516",Airline.AkasaAir },

            {"205",Airline.NipponAirlinesCargo },
            {"001",Airline.AmericanAirlines },
            {"125",Airline.BritishAirways },
            {"160",Airline.CathayCargoes },
            {"176",Airline.EmiratesSkyCargo },
            {"071",Airline.EthihadCargoTracking },
            {"607",Airline.EthihadCargoTracking },
            {"615",Airline.EuropeanAirTransport },//
            {"879",Airline.GoAirCargo },//
            {"072",Airline.GulfAirCargo },
            {"312",Airline.IndigoTracking },
            {"055",Airline.ParcelsAppControl },
            {"131",Airline.JapanAirlines },
            {"703",Airline.NeoCargoTracking },
            {"074",Airline.KLMRoyalDutchCargo },
            {"080",Airline.LOTPolishAirlinesCargo },
            {"020",Airline.LufthansaCargo },
            {"232",Airline.MalaysianAirways },
            {"910",Airline.OmanAirline },
            {"624",Airline.NeoCargoTracking },
            {"157",Airline.QatarCargo },
            {"618",Airline.SingCargo },
            //{"775",Spicejet },
            {"603",Airline.SrilankanAirways },
            {"217",Airline.ThaiAirlines },
            {"235",Airline.TurkishCargo },
            {"016",Airline.UnitedCargoe },
            {"932",Airline.VirginAtlantic },
            {"228",Airline.VistaraAirways }
            //{"879",Airline.GoAir }
            };

            public class DateStringFormatsResp
            {
                public string EventDateTime { get; set; }

                public string[] FlightScheduleFormat { get; set; }
            }


            public static DateStringFormatsResp GetDateString(Airline airline)
            {
                if (formatMap.TryGetValue(airline, out DateStringFormatsResp format))
                {
                    return format;
                }
                else
                {
                    return null;
                }

            }

            public static DateStringFormatsResp GetAirline(string prefix)
            {
                airlineMapper.TryGetValue(prefix, out Airline airline);
                DateStringFormatsResp format = DateStringFormats.GetDateString(airline);
                return format;
            }
            public static DateTime GetEventDateTime(string Datetime, string awb)
            {

                DateStringFormatsResp eventFormat = DateStringFormats.GetAirline(awb);
                DateTime eventTime;
                try
                {
                    bool GeTime = DateTime.TryParseExact(Datetime, eventFormat.EventDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out eventTime);
                    Console.WriteLine(eventTime);
                    return eventTime;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return DateTime.MinValue;
                }
            }
        }
      
    }
}
    

