using EjercicioDavidMazur.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioDavidMazur.Services
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();
        private int nextId = 1;

        public TareaService()
        {
            GenerarTareasAleatorias(30000);
        }

        public IEnumerable<Tarea> ObtenerTareas() => tareas;

        public IEnumerable<Tarea> ObtenerTareasPaginadas(int pageIndex, int pageSize)
        {
            return tareas.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public int TotalTareas() => tareas.Count;

        public void AñadirTarea(Tarea tarea)
        {
            tarea.Id = nextId++;
            tarea.FechaCreacion = DateTime.Now;
            tareas.Add(tarea);
        }

        public void EliminarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
            }
        }

        public void ActualizarTarea(Tarea tarea)
        {
            var tareaExistente = tareas.FirstOrDefault(t => t.Id == tarea.Id);
            if (tareaExistente != null)
            {
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.Estado = tarea.Estado;
                tareaExistente.Bloqueada = tarea.Bloqueada;
                tareaExistente.FechaVencimiento = tarea.FechaVencimiento;
                tareaExistente.Prioridad = tarea.Prioridad;
                tareaExistente.Responsable = tarea.Responsable;
            }
        }

        private void GenerarTareasAleatorias(int cantidad)
        {
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                var estado = (EstadoTarea)random.Next(0, Enum.GetNames(typeof(EstadoTarea)).Length);
                var tarea = new Tarea
                {
                    Descripcion = $"Tarea {i + 1}",
                    Estado = estado,
                    Bloqueada = random.Next(0, 2) == 0 ? false : true,
                    FechaCreacion = DateTime.Now.AddDays(-random.Next(1, 100)),
                    FechaVencimiento = DateTime.Now.AddDays(random.Next(1, 30)),
                    Prioridad = random.Next(1, 6).ToString(),
                    Responsable = $"Responsable {random.Next(1, 11)}"
                };
                tareas.Add(tarea);
                nextId++;
            }
        }
    }
}
