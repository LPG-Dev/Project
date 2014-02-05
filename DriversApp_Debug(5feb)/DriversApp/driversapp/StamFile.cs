using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DriversApp
{
    class StamFile
    {
        private string stamnr;
        private StorageFile file;
        public StamFile()
        {
            this.stamnr = "";
            this.file = null;
        }
        public StamFile(string stamnr)
        {
            this.stamnr = stamnr;
            this.file = null;
        }
        public StamFile(string stamnr, StorageFile file)
        {
            this.file = file;
            this.stamnr = stamnr;
        }
        public string getStamnr()
        {
            return stamnr;
        }
        public StorageFile getFile()
        {
            return file;
        }
        public void setStamnr(string stamnr)
        {
            this.stamnr = stamnr;
        }
        public void setFile(StorageFile file)
        {
            this.file = file;
        }

    }
}
