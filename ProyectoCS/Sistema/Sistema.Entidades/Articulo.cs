﻿namespace Sistema.Entidades
{
    public class Articulo
    {
        public int idArticulo { get; set; }
        public int idCategoria { get; set;}
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }


    }
}
