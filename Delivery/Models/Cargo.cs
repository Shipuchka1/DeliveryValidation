using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Models
{
    [Thermo(ErrorMessage ="Доставка термогруза возможна только для городов Алматы и Астана")]
    [Weight(ErrorMessage ="Доставка по тарифу экспресс возможна с весом до 1000 кг")]
    public class Cargo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public City CityOfDestination { get; set; }
        [Required]
        public TypeOfDeparture TypeOfDeparture { get; set; }
        [Required]
        public TariffType TariffType { get; set; }
        [Required]
        public double Weight { get; set; }
    }

    public enum City
        {
         Almaty,
         Astana,
         Karaganda,
         Pavlodar,
         Aktau
        }

    public enum TypeOfDeparture
    {
        Documentation,
        Premise,
        Thermogram
    }

    public enum TariffType
    {
        Express,
        Econom
    }

    public class ThermoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Cargo cargo = (Cargo)value;
            if (cargo.TypeOfDeparture == TypeOfDeparture.Thermogram)
            {
                if (cargo.CityOfDestination != City.Almaty || cargo.CityOfDestination != City.Astana)
                    return false;
                else return true;
            }
            else
                return true;
        }
    }

    public class WeightAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Cargo cargo = (Cargo)value;
            if (cargo.TariffType == TariffType.Express && cargo.Weight > 1000)
                return false;
            else return true;
        }
    }
}