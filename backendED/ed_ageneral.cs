using System;
namespace backendED
{
    public class ed_ageneral
    {
        //AXIOS
        public int AjaxResultado { set; get; }
        public int Tipo { set; get; }
        public string AjaxError { set; get; }
        public string Error { set; get; }

        //Paginación
        public int RowNumber { set; get; }
        public int NumeroPagina { set; get; }
        public int NumeroRegistros { set; get; }
        public int TotalRegistros { set; get; }

        //Auditoria
        public string vAudNombreUsuarioCreacion { set; get; }
        public DateTime dtAudFechaCreacion { set; get; }
        public string vAudIPCreacion { set; get; }
        public string vAudMACCreacion { set; get; }
        public string vAudNombreUsuarioModificacion { set; get; }
        public DateTime dtAudFechaModificacion { set; get; }
        public string vAudIPModificacion { set; get; }
        public string vAudMACModificacion { set; get; }
        public string vAudFechaCreacion { set; get; }
        public string vAudFechaModificacion { set; get; }

        //Información por Local, RazonSocial
        public int iLocalSistema { get; set; }
        public int iRazonSocial { get; set; }
        public int iCliente { get; set; }
    }
}
