﻿using System.ComponentModel.DataAnnotations;

namespace Marcos.Prestamos.Models
{
    public class CliCatEstadoTemporal
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Valor { get; set; }
    }
}