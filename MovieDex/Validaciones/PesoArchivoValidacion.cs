using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.Validaciones
{
    public class PesoArchivoValidacion : ValidationAttribute
    {
        private readonly int pesoMaxenMB;

        public PesoArchivoValidacion(int PesoMaxenMB)
        {
            pesoMaxenMB = PesoMaxenMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if(formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaxenMB * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe pasar los {pesoMaxenMB} mb");
            }

            return ValidationResult.Success;
        }
    }
}
