using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHandler
{
    public class DecryptedImage
    {
        private int _Id;
        private string _Name;
        private string _Type;
        private string _PathThumb;
        private string _Path;
        private string _Url;

        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }
        public string Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }
        public string Type
        {
            set { this._Type = value; }
            get { return this._Type; }
        }
        public string PathThumb
        {
            set { this._PathThumb = value; }
            get { return this._PathThumb; }
        }
        public string Path
        {
            set { this._Path = value; }
            get { return this._Path; }
        }
        public string Url
        {
            set { this._Url = value; }
            get { return this._Url; }
        }
    }
}
