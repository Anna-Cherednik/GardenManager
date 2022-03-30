using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenManager.Models
{
    public class Разметка
    {
        public int Id { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime DateCreation { get; set; }

        [Display(Name = "Зоны")]
        public virtual List<Zone> Zones { get; set; }    
        
        public Разметка()
        {
            Zones = new List<Zone>();
        }    
    }
}