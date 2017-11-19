using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entidades.Validadores
{
    public class ValidadorEdad : ValidationAttribute
    {
        private int edad;

        public ValidadorEdad(int edad)
        {
            this.edad = edad;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fechaIngresada = (DateTime)value;
                var diferencia = DateTime.Now - fechaIngresada;

                if ((diferencia.Days / 365) >= this.edad)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El alumno debe tener al menos " + this.edad + " años.");
                }
            }
            return ValidationResult.Success;
        }
    }
}