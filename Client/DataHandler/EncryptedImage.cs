using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHandler
{
    public class EncryptedImage
    {
        private int _Id;
        private string _Idx;
        private string _Name;
        private string _Key;
        private string _Type;
        private string _PathEncrypted;
        private string _PathThumb;
        private string _PathOriginal;

        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }
        public string Idx
        {
            set { this._Idx = value; }
            get { return this._Idx; }
        }
        public string Name
        {
            set { this._Name = value; }
            get { return this._Name; }
        }
        public string Key
        {
            set { this._Key = value; }
            get { return this._Key; }
        }
        public string Type
        {
            set { this._Type = value; }
            get { return this._Type; }
        }
        public string PathEncrypted
        {
            set { this._PathEncrypted = value; }
            get { return this._PathEncrypted; }
        }
        public string PathThumb
        {
            set { this._PathThumb = value; }
            get { return this._PathThumb; }
        }
        public string PathOriginal
        {
            set { this._PathOriginal = value; }
            get { return this._PathOriginal; }
        }
    }
}
