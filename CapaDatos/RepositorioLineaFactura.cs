﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloBase;

namespace CapaDatos
{
    public class RepositorioLineaFactura
    {
        public List<Entidades.LineaFactura> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.LineaFacturas
                            select new Entidades.LineaFactura()
                            {
                                IdLineaFactura = tabla.IdLineaFactura,
                                IdFactura = tabla.IdFactura,
                                Cantidad = tabla.Cantidad,
                            };

                foreach (var l in lista)
                {
                    var producto = bd.Productoes.Find(l.Producto.Id);

                    l.Producto = new Entidades.Producto()
                    {
                        Id = producto.Id,
                        Nombre = producto.Nombre,
                        Marca = producto.Marca,
                        PrecioPorUnidad = producto.PrecioPorUnidad,
                    }; 
                }

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.LineaFactura lineafactura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new LineaFactura
                {
                    IdFactura = lineafactura.IdFactura,
                    IdProducto = lineafactura.Producto.Id,
                    Cantidad = lineafactura.Cantidad,

                };
                bd.LineaFacturas.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.LineaFactura Buscar(Entidades.LineaFactura lineafactura)
        {
            Entidades.LineaFactura resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.LineaFacturas.Find(lineafactura.IdLineaFactura);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.LineaFactura
                    {
                        IdLineaFactura = entidadABuscar.IdLineaFactura,
                        IdFactura = entidadABuscar.IdFactura,
                        Cantidad = entidadABuscar.Cantidad,
                    };

                    var producto = from tablaLineaFactura in bd.LineaFacturas join tablaProducto in bd.Productoes on
                                        tablaLineaFactura.IdProducto equals tablaProducto.Id
                                        select new Entidades.Producto()
                                        {
                                            Id = tablaProducto.Id,
                                            Nombre = tablaProducto.Nombre,
                                            Marca = tablaProducto.Marca,
                                            PrecioPorUnidad = tablaProducto.PrecioPorUnidad,
                                        };
                    var elProducto = producto.First();

                    resultado.Producto = new Entidades.Producto
                    {
                        Id = elProducto.Id,
                        Nombre = elProducto.Nombre,
                        Marca = elProducto.Marca,
                        PrecioPorUnidad = elProducto.PrecioPorUnidad,
                    };
                }
            }

            return resultado;
        }

        public void Eliminar(Entidades.LineaFactura lineafactura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.LineaFacturas.Find(lineafactura.IdLineaFactura);

                if (buscarEntidad != null)
                {
                    bd.LineaFacturas.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }
    }
}
