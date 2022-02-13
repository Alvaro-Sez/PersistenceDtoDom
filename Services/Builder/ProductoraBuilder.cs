using Productora.Domain;
using Productora.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productora.Services.Builder
{
    public class ProductoraBuilder
    {
        private readonly ProductoraDom _productora;
        private ProductoraBuilder(ProductoraDom productora) => _productora = productora;
        public static ProductoraBuilder CreateBuilderFrom(ProductoraDto productoraDto)
        {
            ProductoraDom productora = new ProductoraDom()
            {
                Nombre = productoraDto.Nombre,
                Peliculas = productoraDto.Peliculas.Select(p => new PeliculaDom
                {
                    Titulo = p.Titulo,
                    Tematica = p.Tematica,
                    Director = new DirectorDom
                    {
                        Nombre = p.Director.Nombre,
                        Salario = p.Director.Salario
                    },
                    Actores = p.Actores.Select(a => new ActorDom
                    {
                        Nombre= a.Nombre,
                        Nacionalidad = a.Nacionalidad,
                        Papel = a.Papel,
                        Salario= a.Salario
                    }).ToList(),
                    Presupuesto = p.Presupuesto
                }).ToList(),
            };

            return new ProductoraBuilder(productora);
        }
        public ProductoraDom Build()
        {
            return _productora;
        }
        
    }
}
