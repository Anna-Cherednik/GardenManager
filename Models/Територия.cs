using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GardenManager.Models
{
    public class Територия
    {
        public int Id { get; set; }
        [Display(Name="Название")]
        public string Name { get; set; }

        [Display(Name = "Длина")]
        public int Length { get; set; }
        [Display(Name = "Ширина")]
        public int Width { get; set; }

        [Display(Name = "Разметки")]
        public virtual List<Разметка> Разметки { get; set; }

        public Територия()
        {
            Разметки = new List<Разметка>();
        }
    }
}