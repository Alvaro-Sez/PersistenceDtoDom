using Productora.Domain;
using Productora.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Productora.Data;
using Productora.Services.Builder;
using Productora.Data.Repositories;

namespace Productora.Services
{
    public class BulkDataService : IBulkDataService
    {
        private readonly IProductoraRepository _productoraRepository;

        public BulkDataService(IProductoraRepository productoraRepository)
        {
            _productoraRepository = productoraRepository;
        }
        public async Task<OperationResult> BulkData(string jsonString)
        {
            ProductoraDto productoraDto = JsonSerializer.Deserialize<ProductoraDto>(jsonString);

            ProductoraDom productoraDom = ProductoraBuilder.CreateBuilderFrom(productoraDto).Build();

            ProductoraEntity productoraEntity = MapProductora(productoraDom);

            _productoraRepository.Add(productoraEntity);

            await _productoraRepository.SaveChanges();

            return new OperationResult();
        }

        private ProductoraEntity MapProductora(ProductoraDom productoraDom)
        {
            ProductoraEntity productoraEntity = new ProductoraEntity()
            {
                Id = Guid.NewGuid(),
                Nombre = productoraDom.Nombre,
                Peliculas = productoraDom.Peliculas
                                    .Select(p =>
                                        new PeliculaEntity()
                                        {
                                            Titulo = p.Titulo,
                                            Id = Guid.NewGuid(),
                                            Tematica = p.Tematica,
                                            Presupuesto = p.Presupuesto,

                                            Director = new DirectorEntity
                                            {
                                                Id = Guid.NewGuid(),
                                                Nombre = p.Director.Nombre,
                                                Salario = p.Director.Salario,
                                            },
                                            Actors = p.Actores.Select(a => new ActorEntity
                                            {
                                                Id = Guid.NewGuid(),
                                                Nombre = a.Nombre,
                                                Papel = a.Papel,
                                                Salario = a.Salario,
                                            }).ToList(),
                                        }).ToList()
            };

            return productoraEntity;
        }
    }
}
