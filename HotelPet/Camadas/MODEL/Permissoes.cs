﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    class Permissoes
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public bool frmvendas { get; set; }
        public bool frmclientes { get; set; }
        public bool frmprodutos { get; set; }
        public bool frmservicos { get; set; }
        public bool frmfuncionarios { get; set; }
    }
}