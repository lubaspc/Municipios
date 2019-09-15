using System;
using System.Collections.Generic;
using System.Text;
using Municipios.Modelos;

namespace Municipios.Modelos
{
    public class ListZonas
    {
        FireHelper firebaseHelper = new FireHelper();
        public List<zonar> _zonasr { get; set; }

        public ListZonas() {
            CargaLista();

        }
        public async void CargaLista() {
            _zonasr = await firebaseHelper.GetAllZonas();
        }
    }
}
