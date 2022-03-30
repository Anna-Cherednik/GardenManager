using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GardenManager.Models
{
    public class Zone
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Используемое растение")]
        public int? UsePlant_Id { get; set; }
        [ForeignKey("UsePlant_Id")]
        public Plant UsePlant { get; set; }

        public virtual List<Coordinates> Coordinates { get; set; }
        public virtual List<Plant> Рекомендации { get; set; }

        public Zone()
        {
            Coordinates = new List<Coordinates>();
            Рекомендации = new List<Plant>();
        }

        public Zone(string name)
        {
            Name = name;

            Coordinates = new List<Coordinates>();
            Рекомендации = new List<Plant>();
        }
    }
}