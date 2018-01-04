using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace HouseOfPrices
{
    public class CityFinder
    {
        public string getCity(string latitude, string longitude)
        {
            string PlateCode = getPlateCode(latitude, longitude);

            switch (PlateCode)
            {
                case "1":
                    return "Adana";
                case "2":
                    return "Adıyaman";
                case "3":
                    return "Afyon";
                case "4":
                    return "Ağrı";
                case "5":
                    return "Amasya";
                case "6":
                    return "Ankara";
                case "7":
                    return "Antalya";
                case "8":
                    return "Artvin";
                case "9":
                    return "Aydın";
                case "10":
                    return "Balıesir";
                case "11":
                    return "Bilecik";
                case "12":
                    return "Bingöl";
                case "13":
                    return "Bitlis";
                case "14":
                    return "Bolu";
                case "15":
                    return "Burdur";
                case "16":
                    return "Bursa";
                case "17":
                    return "Çanakkale";
                case "18":
                    return "Çankırı";
                case "19":
                    return "Çorum";
                case "20":
                    return "Denizli";
                case "21":
                    return "Diyarbakır";
                case "22":
                    return "Edirne";
                case "23":
                    return "Elazığ";
                case "24":
                    return "Erzincan";
                case "25":
                    return "Erzurum";
                case "26":
                    return "Eskişehir";
                case "27":
                    return "Gaziantep";
                case "28":
                    return "Giresun";
                case "29":
                    return "Gümüşhane";
                case "30":
                    return "Hakkari";
                case "31":
                    return "Hatay";
                case "32":
                    return "Isparta";
                case "33":
                    return "Mersin";
                case "34":
                    return "İstanbul";
                case "35":
                    return "İzmir";
                case "36":
                    return "Kars";
                case "37":
                    return "Kastamonu";
                case "38":
                    return "Kayseri";
                case "39":
                    return "Kırklareli";
                case "40":
                    return "Kırşehir";
                case "41":
                    return "Kocaeli";
                case "42":
                    return "Konya";
                case "43":
                    return "Kütahya";
                case "44":
                    return "Malatya";
                case "45":
                    return "Manisa";
                case "46":
                    return "Kahramanmaraş";
                case "47":
                    return "Mardin";
                case "48":
                    return "Muğla";
                case "49":
                    return "Muş";
                case "50":
                    return "Nevşehir";
                case "51":
                    return "Niğde";
                case "52":
                    return "Ordu";
                case "53":
                    return "Rize";
                case "54":
                    return "Sakarya";
                case "55":
                    return "Samsun";
                case "56":
                    return "Siirt";
                case "57":
                    return "Sinop";
                case "58":
                    return "Sivas";
                case "59":
                    return "Tekirdağ";
                case "60":
                    return "Tokat";
                case "61":
                    return "Trabzon";
                case "62":
                    return "Tunceli";
                case "63":
                    return "Şanlıurfa";
                case "64":
                    return "Uşak";
                case "65":
                    return "Van";
                case "66":
                    return "Yozgat";
                case "67":
                    return "Zonguldak";
                case "68":
                    return "Aksaray";
                case "69":
                    return "Bayburt";
                case "70":
                    return "Karaman";
                case "71":
                    return "Kırıkkale";
                case "72":
                    return "Batman";
                case "73":
                    return "Şırnak";
                case "74":
                    return "Bartın";
                case "75":
                    return "Ardahan";
                case "76":
                    return "Iğdır";
                case "77":
                    return "Yalova";
                case "78":
                    return "Karabük";
                case "79":
                    return "Kilis";
                case "80":
                    return "Osmaniye";
                case "81":
                    return "Düzce";
                default:
                    return "World";
            }
        }
        public string getPlateCode(string latitude, string longitude)
        {
            string plaka = "-1";
            XmlTextReader xmlDocument = new XmlTextReader("http://maps.google.com/maps/api/geocode/xml?latlng=" + latitude.Replace(',', '.').Trim() + "," + longitude.Replace(',', '.').Trim() + "&sensor=false®ion=tr");
            try
            {
                while (xmlDocument.Read())
                {
                    switch (xmlDocument.NodeType)
                    {
                        case XmlNodeType.Text:
                            {
                                if (isPostalCode(xmlDocument.Value))
                                {
                                    plaka = xmlDocument.Value.ToString();
                                    plaka = plaka.Substring(0, 2);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return plaka;
        }
        public static bool isPostalCode(string postalCode)
        {
            bool durum = false;
            try
            {
                if (postalCode.Length == 5)
                {
                    Convert.ToInt32(postalCode);
                    durum = true;
                }
            }
            catch
            {
                durum = false;
            }
            return durum;
        }
    }
}