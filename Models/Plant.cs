using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GardenManager.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual List<int> selectedPositivePlants { get; set; }

        [Display(Name = "Благоприятные соседи")]
        public virtual List<Plant> PositivePlants { get; set; }
        public virtual List<Plant> ReversedPositivePlants { get; set; }

        public virtual List<int> selectedNegativePlants { get; set; }

        [Display(Name = "Нежелательные соседи")]
        public virtual List<Plant> NegativePlants { get; set; }
        public virtual List<Plant> ReversedNegativePlants { get; set; }

        public Plant()
        {
            selectedPositivePlants = new List<int>();
            PositivePlants = new List<Plant>();
            ReversedPositivePlants = new List<Plant>();

            selectedNegativePlants = new List<int>();
            NegativePlants = new List<Plant>();
            ReversedNegativePlants = new List<Plant>();

        }
    }
}