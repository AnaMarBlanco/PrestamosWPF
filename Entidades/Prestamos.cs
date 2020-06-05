using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrestamosWPF.Entidades
{
    class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        public decimal Balance { get; set; }
        //(PrestamoId, Fecha, PersonaId, Concepto, Monto, Balance
    }
}
