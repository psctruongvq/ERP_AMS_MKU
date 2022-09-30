using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Digitizing.Client.Model
{
    public class ChungTu
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private Int64 _dbId;
        public Int64 DbId
        {
            get { return _dbId; }
            set { _dbId = value; }
        }

        private String _soChungTu;
        public String SoChungTu
        {
            get { return _soChungTu; }
            set { _soChungTu = value; }
        }

        private DateTime? _ngayChungTu;
        public DateTime? NgayChungTu
        {
            get { return _ngayChungTu; }
            set { _ngayChungTu = value; }
        }

        private Int32 _maLoaiChungTu;
        public Int32 MaLoaiChungTu
        {
            get { return _maLoaiChungTu; }
            set { _maLoaiChungTu = value; }
        }

        private Boolean _LaChungTuImport;
        public Boolean LaChungTuImport
        {
            get { return _LaChungTuImport; }
            set { _LaChungTuImport = value; }
        }

    }
}
