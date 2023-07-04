using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoPuntoVenta.Modelo
{
    class Imagenes
    {
        public int IdProducto { get; set; }
        public string path { get; set; }
        [Required]
        [NotMapped]
        public Image Picture
        {
            get
            {
                if (String.IsNullOrEmpty(path))
                {
                    if (File.Exists(path))
                    {
                        return Image.FromFile(path);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
        } 
    }
}
