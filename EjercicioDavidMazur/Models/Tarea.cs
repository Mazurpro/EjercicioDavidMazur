namespace EjercicioDavidMazur.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public bool Bloqueada { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaVencimiento { get; set; }
        public string Prioridad { get; set; }
        public string Responsable { get; set; }
        public bool Seleccionada { get; set; }
    }

    public enum EstadoTarea
    {
        Planificada,
        Iniciada,
        EnCurso,
        Completada
    }
}
