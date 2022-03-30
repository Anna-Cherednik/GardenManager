using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GardenManager.Models
{
    public class ViewZone
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Используемое растение")]
        public Plant UsePlant { get; set; }

        public virtual List<Plant> Рекомендации { get; set; }

        public ViewZone()
        {
            Рекомендации = new List<Plant>();
        }
    }
}