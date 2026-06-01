using System;
using System.Data;
using SistemaAcademico.DAL;

namespace SistemaAcademico.BLL
{
    /// <summary>Lógica de negocio para Estudiantes.</summary>
    public static class EstudianteBLL
    {
        public static (int id, string resultado, string mensaje) CrearEstudiante(
            string nombre, string apellidoPaterno, string apellidoMaterno,
            string ci, string correo, string telefono, string ciudad,
            string departamento, string sexo, DateTime? fechaNacimiento,
            string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombre))        return (0, "ERROR", "El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellidoPaterno)) return (0, "ERROR", "El apellido paterno es obligatorio.");
            if (string.IsNullOrWhiteSpace(ci))            return (0, "ERROR", "El CI es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return (0, "ERROR", "El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(clave) || clave.Length < 4) return (0, "ERROR", "La contraseña debe tener al menos 4 caracteres.");

            var (id, res, msg) = EstudianteDAL.CrearEstudiante(nombre, apellidoPaterno, apellidoMaterno,
                ci, correo, telefono, ciudad, departamento, sexo, fechaNacimiento, nombreUsuario, clave);
            return (id, res, msg);
        }

        public static DataTable ListarEstudiantes() => EstudianteDAL.ListarEstudiantes();

        public static DataTable ObtenerEstudiante(int id) => EstudianteDAL.ObtenerEstudiante(id);

        public static void ActualizarEstudiante(int id, string nombre, string apellidoPaterno,
            string apellidoMaterno, string ci, string correo, string telefono,
            string ciudad, string departamento, string sexo, DateTime? fechaNacimiento)
            => EstudianteDAL.ActualizarEstudiante(id, nombre, apellidoPaterno, apellidoMaterno,
               ci, correo, telefono, ciudad, departamento, sexo, fechaNacimiento);

        public static void EliminarEstudiante(int id) => EstudianteDAL.EliminarEstudiante(id);

        public static DataTable ObtenerModuloActual(int id) => EstudianteDAL.ObtenerModuloActual(id);
    }

    /// <summary>Lógica de negocio para Docentes.</summary>
    public static class DocenteBLL
    {
        public static (int id, string resultado, string mensaje) CrearDocente(
            string nombre, string apellidoPaterno, string apellidoMaterno,
            string ci, string correo, string telefono, string ciudad,
            string sexo, string nombreUsuario, string clave, int idTurno)
        {
            if (string.IsNullOrWhiteSpace(nombre))          return (0, "ERROR", "El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellidoPaterno)) return (0, "ERROR", "El apellido paterno es obligatorio.");
            if (string.IsNullOrWhiteSpace(ci))              return (0, "ERROR", "El CI es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombreUsuario))   return (0, "ERROR", "El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(clave) || clave.Length < 4) return (0, "ERROR", "La contraseña debe tener al menos 4 caracteres.");
            return DocenteDAL.CrearDocente(nombre, apellidoPaterno, apellidoMaterno,
                ci, correo, telefono, ciudad, sexo, nombreUsuario, clave, idTurno);
        }

        public static DataTable ListarDocentes() => DocenteDAL.ListarDocentes();
        public static DataTable ObtenerDocente(int id) => DocenteDAL.ObtenerDocente(id);
        public static DataTable ListarClasesDocente(int id) => DocenteDAL.ListarClasesDocente(id);

        public static void ActualizarDocente(int id, string nombre, string apellidoPaterno,
            string apellidoMaterno, string ci, string correo, string telefono,
            string ciudad, int idTurno)
            => DocenteDAL.ActualizarDocente(id, nombre, apellidoPaterno, apellidoMaterno,
               ci, correo, telefono, ciudad, idTurno);

        public static void EliminarDocente(int id) => DocenteDAL.EliminarDocente(id);
    }

    /// <summary>Lógica de negocio para Inscripciones y Pagos.</summary>
    public static class InscripcionBLL
    {
        public static (int id, string resultado, string mensaje) CrearInscripcion(
            int idEstudiante, DateTime fecha, string modalidad,
            decimal monto, DateTime? fechaVencimiento)
        {
            if (monto <= 0) return (0, "ERROR", "El monto debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(modalidad)) return (0, "ERROR", "La modalidad de pago es obligatoria.");
            return InscripcionDAL.CrearInscripcion(idEstudiante, fecha, modalidad, monto, fechaVencimiento);
        }

        public static DataTable ListarInscripciones()   => InscripcionDAL.ListarInscripciones();
        public static DataTable ListarModulos()          => InscripcionDAL.ListarModulos();
        public static DataTable ListarTurnos()           => InscripcionDAL.ListarTurnos();
        public static DataTable EstadoFinanciero(int id) => InscripcionDAL.EstadoFinancieroEstudiante(id);
        public static DataTable ListarMorosos()          => InscripcionDAL.ListarEstudiantesMorosos();
        public static DataTable ObtenerInscripcion(int idEstudiante) => InscripcionDAL.ObtenerInscripcionEstudiante(idEstudiante);

        public static (int id, string resultado, string mensaje) RegistrarPago(
            int idInscripcion, decimal monto, string tipo, int numeroCuota,
            DateTime fecha, DateTime? nuevaFechaVencimiento)
        {
            if (monto <= 0) return (0, "ERROR", "El monto debe ser mayor a cero.");
            return PagoDAL.RegistrarPago(idInscripcion, monto, tipo, numeroCuota, fecha, nuevaFechaVencimiento);
        }

        public static DataTable ListarPagos(int idInscripcion) => PagoDAL.ListarPagosPorInscripcion(idInscripcion);
        public static DataTable ListarCongelamientos()         => CongelamientoDAL.ListarCongelamientos();

        public static int CrearCongelamiento(int idInscripcion, DateTime inicio, DateTime fin, string motivo)
            => CongelamientoDAL.CrearCongelamiento(idInscripcion, inicio, fin, motivo);

        public static void FinalizarCongelamiento(int id) => CongelamientoDAL.FinalizarCongelamiento(id);
        // Estructura de Datos: Colas (Queues)
        // Uso: Procesamiento de pagos FIFO por lotes.
        public class PagoRequest
        {
            public int IdInscripcion { get; set; }
            public decimal Monto { get; set; }
            public string Tipo { get; set; }
            public int NumeroCuota { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime? NuevaFechaVencimiento { get; set; }
        }

        private static readonly System.Collections.Generic.Queue<PagoRequest> ColaPagos = new System.Collections.Generic.Queue<PagoRequest>();

        public static void EncolarPago(PagoRequest pago) => ColaPagos.Enqueue(pago);

        public static System.Collections.Generic.List<(int id, string res, string msg)> ProcesarPagosEnCola()
        {
            var resultados = new System.Collections.Generic.List<(int, string, string)>();
            while (ColaPagos.Count > 0)
            {
                var pago = ColaPagos.Dequeue();
                resultados.Add(RegistrarPago(pago.IdInscripcion, pago.Monto, pago.Tipo, pago.NumeroCuota, pago.Fecha, pago.NuevaFechaVencimiento));
            }
            return resultados;
        }
    }

    /// <summary>Lógica de negocio para Horarios y Clases.</summary>
    public static class HorarioBLL
    {
        public static int CrearHorario(string nombre, int idModulo) => HorarioDAL.CrearHorario(nombre, idModulo);
        public static void PublicarHorario(int id, bool pub)       => HorarioDAL.PublicarHorario(id, pub);
        public static DataTable ListarHorarios()                    => HorarioDAL.ListarHorarios();
        public static DataTable ListarClases(int idHorario)         => ClaseDAL.ListarClasesPorHorario(idHorario);
        public static DataTable ObtenerHorarioEstudiante(int id)    => ClaseDAL.ObtenerHorarioEstudiante(id);

        public static (int id, string resultado, string mensaje) CrearClase(
            DateTime fecha, TimeSpan hora, string modalidad,
            int idDocente, int idHorario, string linkZoom, string aula)
        {
            if (hora.Hours < 7 || hora.Hours >= 22)
                return (0, "ERROR", "El horario debe estar entre las 7:00 y las 22:00.");
            return ClaseDAL.CrearClase(fecha, hora, modalidad, idDocente, idHorario, linkZoom, aula);
        }

        public static (string resultado, string mensaje) EliminarClase(int id) => ClaseDAL.EliminarClase(id);

        // Estructura de Datos: Listas Enlazadas (LinkedList)
        // Uso: Administrar una lista de clases para un horario de forma secuencial.
        private static readonly System.Collections.Generic.LinkedList<DataRow> ClasesDisponibles = new System.Collections.Generic.LinkedList<DataRow>();

        public static void CargarClasesDisponibles(int idHorario)
        {
            ClasesDisponibles.Clear();
            var dt = ListarClases(idHorario);
            foreach (DataRow row in dt.Rows)
            {
                ClasesDisponibles.AddLast(row);
            }
        }

        // Estructura de Datos: Recursividad
        // Uso: Buscar recursivamente si existe un choque de horario en una lista de clases reservadas.
        public static bool VerificarChoqueHorarioRecursivo(System.Collections.Generic.List<DataRow> reservasActuales, int index, DateTime fechaNueva, TimeSpan horaNueva)
        {
            if (index >= reservasActuales.Count) return false; // Caso base: no hay choque
            
            var reserva = reservasActuales[index];
            DateTime fechaExistente = Convert.ToDateTime(reserva["Fecha"]);
            TimeSpan horaExistente = (TimeSpan)reserva["HoraInicio"];

            if (fechaExistente.Date == fechaNueva.Date && horaExistente == horaNueva)
                return true; // Caso base: hay choque

            return VerificarChoqueHorarioRecursivo(reservasActuales, index + 1, fechaNueva, horaNueva);
        }
    }

    /// <summary>Lógica de negocio para Reservas.</summary>
    public static class ReservaBLL
    {
        public static (int id, string resultado, string mensaje) CrearReserva(int idEstudiante, int idClase)
            => ReservaDAL.CrearReserva(idEstudiante, idClase);

        public static (string res, string msg) CancelarReserva(int id) => ReservaDAL.CancelarReserva(id);
        public static DataTable ListarReservasEstudiante(int id)       => ReservaDAL.ListarReservasPorEstudiante(id);
        public static DataTable ListarReservasClase(int id)            => ReservaDAL.ListarReservasPorClase(id);
        public static DataTable ContarHorasSemana(int id)              => ReservaDAL.ContarHorasSemana(id);
        public static DataTable ListarAsistencia(int id)               => ReservaDAL.ListarAsistenciaEstudiante(id);
        public static DataTable ResumenSemanal(int id)                 => ReservaDAL.ResumenAsistenciaSemanal(id);

        public static void VerificarAlerta(int id) => ReservaDAL.VerificarYGenerarAlerta(id);
        public static DataTable ListarAlertasActivas()                 => AlertaDAL.ListarAlertasActivas();
        public static void MarcarAlertaRevisada(int id)                => AlertaDAL.MarcarAlertaRevisada(id);
    }

    /// <summary>Lógica de negocio para Evaluaciones (Planillas, Notas, Exámenes).</summary>
    public static class EvaluacionBLL
    {
        public static int CrearPlanilla(int idEst, int idMod)   => PlanillaDAL.CrearPlanilla(idEst, idMod);
        public static DataSet ObtenerPlanillaCompleta(int idEst, int idMod) => PlanillaDAL.ObtenerPlanillaCompleta(idEst, idMod);
        public static DataTable ListarPlanillasEstudiante(int id) => PlanillaDAL.ListarPlanillasPorEstudiante(id);

        public static (string res, string msg) RegistrarNotaTema(int idPlanilla, int nroTema,
            decimal? speaking, decimal? writing, decimal? listening, decimal? reading, int idDocente)
        {
            if (nroTema < 1 || nroTema > 16) return ("ERROR", "El número de tema debe estar entre 1 y 16.");
            return NotaTemaDAL.RegistrarNotaTema(idPlanilla, nroTema, speaking, writing, listening, reading, idDocente);
        }

        public static void ActualizarNotaTema(int idNota, decimal? speaking, decimal? writing,
            decimal? listening, decimal? reading, int idDocente)
            => NotaTemaDAL.ActualizarNotaTema(idNota, speaking, writing, listening, reading, idDocente);

        public static (string res, string msg) RegistrarExamen(int idPlanilla, string tipo, decimal nota, int idDocente)
        {
            if (nota < 0 || nota > 100) return ("ERROR", "La nota debe estar entre 0 y 100.");
            return ExamenModuloDAL.RegistrarExamen(idPlanilla, tipo, nota, idDocente);
        }

        public static DataTable VerificarAprobacion(int idEst, int idMod) => ExamenModuloDAL.VerificarAprobacion(idEst, idMod);
        public static (string res, string msg) AvanzarModulo(int idEst)   => ProgresoDAL.AvanzarModulo(idEst);

        public static (string res, string msg) RegistrarDiagnostico(int idEst, DateTime fecha,
            int puntaje, string nivel, string obs, int idModulo)
            => DiagnosticoDAL.RegistrarDiagnostico(idEst, fecha, puntaje, nivel, obs, idModulo);

        public static DataTable ObtenerDiagnostico(int idEst) => DiagnosticoDAL.ObtenerDiagnostico(idEst);
        public static DataTable ListarDiagnosticos() => DiagnosticoDAL.ListarDiagnosticos();

        // Estructura de Datos: Árboles Binarios de Búsqueda (BST)
        // Uso: Organizar las notas de un estudiante jerárquicamente para búsquedas rápidas.
        public class NodoNota
        {
            public decimal Nota { get; set; }
            public string TipoExamen { get; set; }
            public NodoNota Izquierdo { get; set; }
            public NodoNota Derecho { get; set; }

            public NodoNota(decimal nota, string tipo)
            {
                Nota = nota;
                TipoExamen = tipo;
            }
        }

        public class ArbolNotas
        {
            public NodoNota Raiz;

            public void Insertar(decimal nota, string tipo)
            {
                Raiz = InsertarRec(Raiz, nota, tipo);
            }

            private NodoNota InsertarRec(NodoNota raiz, decimal nota, string tipo)
            {
                if (raiz == null)
                    return new NodoNota(nota, tipo);

                if (nota < raiz.Nota)
                    raiz.Izquierdo = InsertarRec(raiz.Izquierdo, nota, tipo);
                else
                    raiz.Derecho = InsertarRec(raiz.Derecho, nota, tipo);

                return raiz;
            }
        }
    }

    /// <summary>Lógica de negocio para Proyecto Final y Certificados.</summary>
    public static class CertificadoBLL
    {
        public static (int id, string res, string msg) CrearProyecto(int idEst, string tema, string linkEnsayo, string linkVideo)
            => ProyectoFinalDAL.CrearProyectoFinal(idEst, tema, linkEnsayo, linkVideo);

        public static DataTable CalificarProyecto(int idProyecto, decimal notaEnsayo,
            decimal notaVideo, decimal notaDefensa, int idDocente)
            => ProyectoFinalDAL.CalificarProyecto(idProyecto, notaEnsayo, notaVideo, notaDefensa, idDocente);

        public static DataTable ObtenerProyecto(int idEst) => ProyectoFinalDAL.ObtenerProyecto(idEst);

        public static (int id, string res, string msg) EmitirCertificado(int idEst, int idAdmin)
            => CertificadoDAL.EmitirCertificado(idEst, idAdmin);

        public static DataTable ListarCertificados() => CertificadoDAL.ListarCertificados();
    }
}
