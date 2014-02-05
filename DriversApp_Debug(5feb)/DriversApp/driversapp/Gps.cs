using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace DriversApp
{
    class Gps
    {
        private String _lat, _lon, _acc;
        public Gps(String lat, String lon, String acc)
        {
            _lat = lat;
            _lon = lon;
            _acc = acc;
        }

        public void setLat(String i)
        {
            _lat = i;
        }

        public void setLon(String i)
        {
            _lon = i;
        }

        public void setAcc(String i)
        {
            _acc = i;
        }


        public String getLat()
        {
            return _lat;
        }

        public String getLon()
        {
            return _lon;
        }

        public String getAcc()
        {
            return _acc;
        }
    }
}
