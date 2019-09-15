using System;
using System.Collections.Generic;
using System.Text;

namespace Municipios
{
    class Administrador_MasterMenuItem
    {
        public Administrador_MasterMenuItem()
        {
            TargetType = typeof(detail_home);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
