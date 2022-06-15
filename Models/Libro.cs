﻿using System.ComponentModel.DataAnnotations;

namespace csharp_bibliotecaMvc.Models
{
    public enum Stato
    { 
        Disponibile,
        Prestato,
    }

    public class Libro
    {
        public int LibroID { get; set; }

        public string Titolo { get; set; }

        public int Anno { get; set; }

        public string Stato { get; set; }

        public string ISBN { get; set; }
        
        public virtual ICollection<Prestito> Prestito { get; set; }
        public virtual ICollection<Autore> Autore { get; set; }
    }
}
