-- ============================================================
-- SISTEMA DE INFORMACIÓN ACADÉMICO - ACADEMIA DE INGLÉS BOLIVIA
-- Script Completo: Esquema Corregido + Procedimientos + Datos
-- Versión: 1.0  |  Compatibilidad: MariaDB 10.4+ / MySQL 8.0+
-- ============================================================

-- Eliminar y recrear la base de datos
DROP DATABASE IF EXISTS academia_ingles;
CREATE DATABASE academia_ingles
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_general_ci;
USE academia_ingles;

-- ============================================================
-- SECCIÓN 1: TABLAS BASE (sin dependencias externas)
-- ============================================================

-- Roles del sistema: Administrador, Docente, Estudiante
CREATE TABLE rol (
  idRol       INT AUTO_INCREMENT PRIMARY KEY,
  NombreRol   VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Turnos de trabajo de los docentes: Mañana y Tarde
CREATE TABLE turno (
  idTurno      INT AUTO_INCREMENT PRIMARY KEY,
  NombreTurno  VARCHAR(50) NOT NULL,
  HoraInicio   TIME NOT NULL,
  HoraFin      TIME NOT NULL
) ENGINE=InnoDB;

-- Los 4 módulos del curso de inglés (A1, A2, B1, B2)
-- CORRECCIÓN: DuracionSemanas → DuracionMeses (el negocio habla de meses)
CREATE TABLE modulo (
  idModulo       INT AUTO_INCREMENT PRIMARY KEY,
  NombreModulo   VARCHAR(100) NOT NULL,
  Nivel          VARCHAR(10) NOT NULL,   -- A1, A2, B1, B2
  DuracionMeses  INT NOT NULL,           -- M1=2, M2=2, M3=3, M4=3 (total 10 meses)
  NumeroLibro    INT NOT NULL,           -- Número del libro usado (tiene 16 temas c/u)
  Descripcion    VARCHAR(255)
) ENGINE=InnoDB;

-- Datos personales de cualquier persona (estudiantes, docentes, admins)
CREATE TABLE persona (
  idPersona       INT AUTO_INCREMENT PRIMARY KEY,
  Nombre          VARCHAR(100) NOT NULL,
  ApellidoPaterno VARCHAR(80) NOT NULL,
  ApellidoMaterno VARCHAR(80),
  CI              VARCHAR(20) UNIQUE,
  Correo          VARCHAR(120),
  Telefono        VARCHAR(20),
  Calle           VARCHAR(100),
  NroCasa         VARCHAR(20),
  Zona            VARCHAR(80),
  Ciudad          VARCHAR(80),
  Departamento    VARCHAR(50),
  Nacionalidad    VARCHAR(50) DEFAULT 'Boliviana',
  Sexo            CHAR(1),              -- 'M' o 'F'
  FechaNacimiento DATE,
  Estado          VARCHAR(20) DEFAULT 'Activo'
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 2: TABLAS DE USUARIOS Y ROLES
-- ============================================================

-- Credenciales de acceso al sistema
CREATE TABLE usuario (
  idUsuario      INT AUTO_INCREMENT PRIMARY KEY,
  NombreUsuario  VARCHAR(50) NOT NULL UNIQUE,
  Clave          VARCHAR(255) NOT NULL,  -- Almacenado como SHA-256
  Estado         VARCHAR(20) DEFAULT 'Activo', -- 'Activo','Inactivo','Bloqueado'
  FechaCreacion  DATETIME DEFAULT CURRENT_TIMESTAMP,
  UltimoAcceso   DATETIME,
  idPersona      INT NOT NULL,
  FOREIGN KEY (idPersona) REFERENCES persona(idPersona)
) ENGINE=InnoDB;

-- Tabla intermedia que asigna roles a usuarios (relación N:M)
CREATE TABLE usuario_rol (
  idUsuario INT NOT NULL,
  idRol     INT NOT NULL,
  PRIMARY KEY (idUsuario, idRol),
  FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
  FOREIGN KEY (idRol)     REFERENCES rol(idRol)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 3: ENTIDADES PRINCIPALES
-- ============================================================

-- Entidad Docente (hereda datos de persona)
CREATE TABLE docente (
  idDocente  INT AUTO_INCREMENT PRIMARY KEY,
  idPersona  INT NOT NULL,
  FOREIGN KEY (idPersona) REFERENCES persona(idPersona)
) ENGINE=InnoDB;

-- Asignación de turnos a docentes
CREATE TABLE docente_turno (
  idDocTurno INT AUTO_INCREMENT PRIMARY KEY,
  idDocente  INT NOT NULL,
  idTurno    INT NOT NULL,
  FOREIGN KEY (idDocente) REFERENCES docente(idDocente),
  FOREIGN KEY (idTurno)   REFERENCES turno(idTurno)
) ENGINE=InnoDB;

-- Entidad Estudiante (hereda datos de persona)
CREATE TABLE estudiante (
  idEstudiante INT AUTO_INCREMENT PRIMARY KEY,
  idPersona    INT NOT NULL,
  FOREIGN KEY (idPersona) REFERENCES persona(idPersona)
) ENGINE=InnoDB;

-- Entidad Administrador (hereda datos de persona)
-- NUEVO: Tabla que faltaba en el esquema original
CREATE TABLE administrador (
  idAdmin   INT AUTO_INCREMENT PRIMARY KEY,
  idPersona INT NOT NULL,
  FOREIGN KEY (idPersona) REFERENCES persona(idPersona)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 4: INSCRIPCIÓN Y PAGOS
-- ============================================================

-- Inscripción del estudiante al curso completo (10 meses)
-- CORRECCIÓN: Se elimina idModulo (el módulo se sigue en progreso_estudiante)
-- NUEVO: MontoTotal, FechaVencimientoPago, Estado extendido
CREATE TABLE inscripcion (
  idInscripcion        INT AUTO_INCREMENT PRIMARY KEY,
  FechaInscripcion     DATE NOT NULL,
  ModalidadPago        VARCHAR(50),           -- 'Contado', 'Cuotas'
  MontoTotal           DECIMAL(10,2) NOT NULL, -- Total del curso en Bs.
  Estado               VARCHAR(30) DEFAULT 'Activa', -- 'Activa','Congelada','Finalizada','Bloqueada'
  FechaVencimientoPago DATE,                  -- Fecha límite del siguiente pago
  idEstudiante         INT NOT NULL,
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante)
) ENGINE=InnoDB;

-- Registro de pagos (cuotas o pago completo)
-- CORRECCIÓN: Se agrega Estado para seguimiento
CREATE TABLE pago (
  idPago       INT AUTO_INCREMENT PRIMARY KEY,
  FechaPago    DATE NOT NULL,
  Monto        DECIMAL(10,2) NOT NULL,
  TipoPago     VARCHAR(50),    -- 'Cuota', 'Contado'
  NumeroCuota  INT,            -- Número de cuota (si aplica)
  Estado       VARCHAR(20) DEFAULT 'Pagado',
  Observacion  VARCHAR(200),
  idInscripcion INT NOT NULL,
  FOREIGN KEY (idInscripcion) REFERENCES inscripcion(idInscripcion)
) ENGINE=InnoDB;

-- Congelamiento del curso por solicitud del estudiante
-- CORRECCIÓN: Se agrega Estado para saber si sigue activo o ya terminó
CREATE TABLE congelamiento (
  idCongelamiento INT AUTO_INCREMENT PRIMARY KEY,
  FechaInicio     DATE NOT NULL,
  FechaFin        DATE NOT NULL,
  Motivo          TEXT,
  Estado          VARCHAR(20) DEFAULT 'Activo', -- 'Activo','Finalizado'
  idInscripcion   INT NOT NULL,
  FOREIGN KEY (idInscripcion) REFERENCES inscripcion(idInscripcion)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 5: EXAMEN DIAGNÓSTICO Y PROGRESO
-- ============================================================

-- Examen inicial para determinar nivel del estudiante
-- CORRECCIÓN: Se agrega ModuloAsignado para saber dónde empieza
CREATE TABLE examen_diagnostico (
  idDiagnostico   INT AUTO_INCREMENT PRIMARY KEY,
  Fecha           DATE NOT NULL,
  Puntaje         INT,
  Nivel           VARCHAR(10),  -- A1, A2, etc.
  Observaciones   TEXT,
  idModuloAsignado INT,         -- Módulo donde iniciará (normalmente 1, excepcionalmente 2)
  idEstudiante    INT NOT NULL,
  FOREIGN KEY (idEstudiante)    REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idModuloAsignado) REFERENCES modulo(idModulo)
) ENGINE=InnoDB;

-- Seguimiento del progreso del estudiante por módulo
-- NUEVO: Tabla fundamental que faltaba en el diseño original
CREATE TABLE progreso_estudiante (
  idProgreso   INT AUTO_INCREMENT PRIMARY KEY,
  FechaInicio  DATE,
  FechaFin     DATE,
  Estado       VARCHAR(30) DEFAULT 'En Progreso', -- 'En Progreso','Aprobado'
  idEstudiante INT NOT NULL,
  idModulo     INT NOT NULL,
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idModulo)     REFERENCES modulo(idModulo)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 6: HORARIOS Y CLASES
-- ============================================================

-- Horario publicado por el administrador para cada módulo
-- NUEVO: Tabla que agrupaba las clases; faltaba en el esquema original
CREATE TABLE horario (
  idHorario    INT AUTO_INCREMENT PRIMARY KEY,
  Nombre       VARCHAR(100) NOT NULL,
  idModulo     INT NOT NULL,
  Publicado    TINYINT(1) DEFAULT 0,   -- 0=Borrador, 1=Publicado (visible para estudiantes)
  FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (idModulo) REFERENCES modulo(idModulo)
) ENGINE=InnoDB;

-- Clase individual de 1 hora asignada a un docente
-- CORRECCIÓN: Ahora referencia horario en lugar de solo módulo
-- CORRECCIÓN: Se agrega UNIQUE para evitar choque de horarios del docente
CREATE TABLE clase (
  idClase     INT AUTO_INCREMENT PRIMARY KEY,
  Fecha       DATE NOT NULL,
  HoraInicio  TIME NOT NULL,
  HoraFin     TIME NOT NULL,   -- Siempre HoraInicio + 1 hora
  Modalidad   VARCHAR(20) DEFAULT 'Virtual', -- 'Virtual','Presencial'
  CupoMaximo  INT DEFAULT 8,
  CupoActual  INT DEFAULT 0,
  Estado      VARCHAR(30) DEFAULT 'Programada', -- 'Programada','En Curso','Finalizada'
  LinkZoom    VARCHAR(255),               -- URL de la sesión Zoom (si es Virtual)
  Aula        VARCHAR(50),               -- Aula física (si es Presencial)
  idDocente   INT NOT NULL,
  idHorario   INT NOT NULL,
  -- RESTRICCIÓN: Un docente no puede estar en dos clases a la misma hora
  UNIQUE KEY uk_docente_fecha_hora (idDocente, Fecha, HoraInicio),
  FOREIGN KEY (idDocente)  REFERENCES docente(idDocente),
  FOREIGN KEY (idHorario)  REFERENCES horario(idHorario)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 7: RESERVAS Y ASISTENCIA
-- ============================================================

-- Reserva de clase por parte del estudiante
-- CORRECCIÓN: Se agrega UNIQUE para evitar reservas duplicadas
CREATE TABLE reserva (
  idReserva    INT AUTO_INCREMENT PRIMARY KEY,
  FechaReserva DATETIME DEFAULT CURRENT_TIMESTAMP,
  Estado       VARCHAR(30) DEFAULT 'Confirmada', -- 'Confirmada','Cancelada'
  idEstudiante INT NOT NULL,
  idClase      INT NOT NULL,
  -- Un estudiante no puede reservar la misma clase dos veces
  UNIQUE KEY uk_estudiante_clase (idEstudiante, idClase),
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idClase)      REFERENCES clase(idClase)
) ENGINE=InnoDB;

-- Asistencia generada automáticamente al reservar una clase
CREATE TABLE asistencia (
  idAsistencia INT AUTO_INCREMENT PRIMARY KEY,
  Asistio      TINYINT(1) DEFAULT 1,  -- 1=Presente (auto al reservar)
  idReserva    INT NOT NULL UNIQUE,   -- Una asistencia por reserva
  FOREIGN KEY (idReserva) REFERENCES reserva(idReserva)
) ENGINE=InnoDB;

-- Alerta cuando el estudiante tiene menos de 5 horas a la semana
-- NUEVO: Tabla que faltaba en el diseño original
CREATE TABLE alerta_asistencia (
  idAlerta      INT AUTO_INCREMENT PRIMARY KEY,
  Semana        DATE NOT NULL,         -- Lunes de la semana afectada
  HorasCursadas INT DEFAULT 0,
  FechaAlerta   DATETIME DEFAULT CURRENT_TIMESTAMP,
  Revisada      TINYINT(1) DEFAULT 0, -- El admin marcó que revisó esta alerta
  idEstudiante  INT NOT NULL,
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 8: EVALUACIONES Y PLANILLAS
-- ============================================================

-- Planilla de evaluación por módulo (se generan 4 en total por estudiante)
-- CORRECCIÓN: Se agrega FechaCreacion
CREATE TABLE planilla_evaluacion (
  idPlanilla    INT AUTO_INCREMENT PRIMARY KEY,
  Estado        VARCHAR(30) DEFAULT 'En Progreso', -- 'En Progreso','Completada'
  FechaCreacion DATE,
  idEstudiante  INT NOT NULL,
  idModulo      INT NOT NULL,
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idModulo)     REFERENCES modulo(idModulo)
) ENGINE=InnoDB;

-- Notas por habilidad para cada tema (1-16 por libro)
-- NUEVO: Separa las notas de tema de los exámenes finales
-- CORRECCIÓN: El diseño original mezclaba todo en detalle_eva
CREATE TABLE nota_tema (
  idNotaTema    INT AUTO_INCREMENT PRIMARY KEY,
  NroTema       INT NOT NULL,          -- Número de tema del libro (1 al 16)
  Speaking      DECIMAL(4,2),          -- Nota de expresión oral
  Writing       DECIMAL(4,2),          -- Nota de escritura
  Listening     DECIMAL(4,2),          -- Nota de comprensión auditiva
  Reading       DECIMAL(4,2),          -- Nota de comprensión lectora
  FechaRegistro DATE,
  idPlanilla    INT NOT NULL,
  idDocente     INT NOT NULL,          -- El docente que calificó
  -- Un tema solo puede registrarse una vez por planilla
  UNIQUE KEY uk_tema_planilla (NroTema, idPlanilla),
  FOREIGN KEY (idPlanilla) REFERENCES planilla_evaluacion(idPlanilla),
  FOREIGN KEY (idDocente)  REFERENCES docente(idDocente)
) ENGINE=InnoDB;

-- Exámenes de módulo (Teórico y Oral) – mínimo 90 para aprobar
-- NUEVO: Reemplaza y mejora el concepto de evaluación final en detalle_eva
CREATE TABLE examen_modulo (
  idExamen    INT AUTO_INCREMENT PRIMARY KEY,
  TipoExamen  ENUM('Teorico','Oral') NOT NULL,
  Nota        DECIMAL(4,2),
  Intento     INT DEFAULT 1,
  Estado      VARCHAR(20) DEFAULT 'Pendiente', -- 'Pendiente','Aprobado','Reprobado'
  Fecha       DATE,
  idPlanilla  INT NOT NULL,
  idDocente   INT NOT NULL,
  FOREIGN KEY (idPlanilla) REFERENCES planilla_evaluacion(idPlanilla),
  FOREIGN KEY (idDocente)  REFERENCES docente(idDocente)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 9: PROYECTO FINAL Y CERTIFICADO
-- ============================================================

-- Proyecto final al terminar todos los módulos (Ensayo + Video + Defensa)
-- CORRECCIÓN: Se separan las notas de cada componente
CREATE TABLE proyecto_final (
  idProyecto    INT AUTO_INCREMENT PRIMARY KEY,
  Tema          VARCHAR(200),
  LinkEnsayo    VARCHAR(255),          -- URL o descripción del ensayo
  LinkVideo     VARCHAR(255),          -- URL del video
  NotaEnsayo    DECIMAL(4,2),
  NotaVideo     DECIMAL(4,2),
  NotaDefensa   DECIMAL(4,2),
  NotaFinal     DECIMAL(4,2),         -- Promedio de las tres notas
  Estado        VARCHAR(30) DEFAULT 'Pendiente',
  FechaRegistro DATE,
  idEstudiante  INT NOT NULL UNIQUE,  -- Un proyecto por estudiante
  idDocente     INT,                  -- Docente evaluador de la defensa
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idDocente)    REFERENCES docente(idDocente)
) ENGINE=InnoDB;

-- Certificado emitido al completar el curso
-- CORRECCIÓN: Se agrega referencia al administrador que emitió
CREATE TABLE certificado (
  idCertificado    INT AUTO_INCREMENT PRIMARY KEY,
  FechaEmision     DATE NOT NULL,
  NivelAlcanzado   VARCHAR(10) DEFAULT 'B2',
  CodigoCertificado VARCHAR(20) UNIQUE,  -- Código único del certificado
  idEstudiante     INT NOT NULL UNIQUE,  -- Un certificado por estudiante
  idAdmin          INT,                  -- Admin que lo tramitó
  FOREIGN KEY (idEstudiante) REFERENCES estudiante(idEstudiante),
  FOREIGN KEY (idAdmin)      REFERENCES administrador(idAdmin)
) ENGINE=InnoDB;

-- ============================================================
-- SECCIÓN 10: DATOS SEMILLA (SEED DATA)
-- ============================================================

-- Roles del sistema
INSERT INTO rol (NombreRol) VALUES ('Administrador'), ('Docente'), ('Estudiante');

-- Turnos de trabajo
INSERT INTO turno (NombreTurno, HoraInicio, HoraFin) VALUES
  ('Mañana', '07:00:00', '14:00:00'),
  ('Tarde',  '14:00:00', '22:00:00');

-- Los 4 módulos del curso de inglés
INSERT INTO modulo (NombreModulo, Nivel, DuracionMeses, NumeroLibro, Descripcion) VALUES
  ('Módulo 1 – Beginner',        'A1', 2, 1, 'Nivel inicial del inglés, libro 1 (16 temas)'),
  ('Módulo 2 – Elementary',      'A2', 2, 2, 'Nivel elemental del inglés, libro 2 (16 temas)'),
  ('Módulo 3 – Pre-Intermediate','B1', 3, 3, 'Nivel pre-intermedio del inglés, libro 3 (16 temas)'),
  ('Módulo 4 – Intermediate',    'B2', 3, 4, 'Nivel intermedio del inglés, libro 4 (16 temas)');

-- Usuario administrador inicial (contraseña: admin123 en SHA-256)
INSERT INTO persona (Nombre, ApellidoPaterno, CI, Correo, Ciudad, Estado)
VALUES ('Administrador', 'Principal', '00000000', 'admin@academia.edu.bo', 'Cochabamba', 'Activo');

INSERT INTO usuario (NombreUsuario, Clave, idPersona)
VALUES ('admin', SHA2('admin123', 256), 1);

INSERT INTO administrador (idPersona) VALUES (1);

INSERT INTO usuario_rol (idUsuario, idRol)
VALUES (1, 1); -- Administrador

-- ==========================================
-- REGISTROS ADICIONALES DE PRUEBA
-- ==========================================

-- Docente de prueba
INSERT INTO persona (Nombre, ApellidoPaterno, CI, Correo, Ciudad, Sexo, Estado)
VALUES ('Roberto', 'Gomez', '11111111', 'roberto@academia.edu.bo', 'Cochabamba', 'M', 'Activo');
INSERT INTO docente (idPersona) VALUES (2);
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES ('profesor', SHA2('profe123', 256), 2);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (2, 2);
INSERT INTO docente_turno (idDocente, idTurno) VALUES (1, 1);

-- Estudiantes de prueba
INSERT INTO persona (Nombre, ApellidoPaterno, CI, Correo, Ciudad, Sexo, Estado)
VALUES ('Ana', 'Lopez', '22222222', 'ana@estudiante.com', 'Cochabamba', 'F', 'Activo');
INSERT INTO estudiante (idPersona) VALUES (3);
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES ('ana', SHA2('ana123', 256), 3);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (3, 3);
INSERT INTO progreso_estudiante (FechaInicio, Estado, idEstudiante, idModulo) VALUES (CURDATE(), 'En Progreso', 1, 1);
INSERT INTO inscripcion (FechaInscripcion, ModalidadPago, MontoTotal, Estado, idEstudiante) VALUES (CURDATE(), 'Contado', 2000, 'Activa', 1);

INSERT INTO persona (Nombre, ApellidoPaterno, CI, Correo, Ciudad, Sexo, Estado)
VALUES ('Carlos', 'Perez', '33333333', 'carlos@estudiante.com', 'Santa Cruz', 'M', 'Activo');
INSERT INTO estudiante (idPersona) VALUES (4);
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES ('carlos', SHA2('carlos123', 256), 4);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (4, 3);
INSERT INTO progreso_estudiante (FechaInicio, Estado, idEstudiante, idModulo) VALUES (CURDATE(), 'En Progreso', 2, 1);
INSERT INTO inscripcion (FechaInscripcion, ModalidadPago, MontoTotal, Estado, idEstudiante) VALUES (CURDATE(), 'Contado', 2000, 'Activa', 2);

-- Horario y Clases de prueba
INSERT INTO horario (Nombre, idModulo, Publicado) VALUES ('Horario Mañana M1', 1, 1);

INSERT INTO clase (Fecha, HoraInicio, HoraFin, Modalidad, CupoMaximo, CupoActual, Estado, idDocente, idHorario) 
VALUES (CURDATE(), '08:00:00', '09:00:00', 'Presencial', 8, 0, 'Programada', 1, 1);
INSERT INTO clase (Fecha, HoraInicio, HoraFin, Modalidad, CupoMaximo, CupoActual, Estado, idDocente, idHorario) 
VALUES (CURDATE(), '09:00:00', '10:00:00', 'Presencial', 8, 0, 'Programada', 1, 1);
INSERT INTO clase (Fecha, HoraInicio, HoraFin, Modalidad, CupoMaximo, CupoActual, Estado, idDocente, idHorario) 
VALUES (CURDATE(), '10:00:00', '11:00:00', 'Presencial', 8, 0, 'Programada', 1, 1);

-- ============================================================
-- SECCIÓN 11: PROCEDIMIENTOS ALMACENADOS (STORED PROCEDURES)
-- ============================================================
DELIMITER $$

-- ==========================================
-- GRUPO 1: AUTENTICACIÓN Y USUARIOS
-- ==========================================

-- sp_Login: Verifica credenciales y retorna datos del usuario con su rol
-- Uso: Pantalla de login del sistema
DROP PROCEDURE IF EXISTS sp_Login$$
CREATE PROCEDURE sp_Login(
  IN p_nombreUsuario VARCHAR(50),
  IN p_clave         VARCHAR(255)  -- Recibe el hash SHA-256 de la contraseña
)
BEGIN
  DECLARE v_idUsuario INT DEFAULT NULL;

  -- Buscar si el usuario y contraseña existen
  SELECT idUsuario INTO v_idUsuario
  FROM usuario
  WHERE NombreUsuario = p_nombreUsuario AND Clave = p_clave
  LIMIT 1;

  IF v_idUsuario IS NOT NULL THEN
    -- Actualizar fecha de último acceso
    UPDATE usuario SET UltimoAcceso = NOW() WHERE idUsuario = v_idUsuario;

    -- Retornar datos completos del usuario con su rol y entidad relacionada
    SELECT
      u.idUsuario,
      u.NombreUsuario,
      u.Estado,
      p.Nombre,
      p.ApellidoPaterno,
      CONCAT(p.Nombre, ' ', p.ApellidoPaterno) AS NombreCompleto,
      p.idPersona,
      r.NombreRol,
      r.idRol,
      e.idEstudiante,
      d.idDocente,
      a.idAdmin
    FROM usuario u
    INNER JOIN persona p      ON u.idPersona  = p.idPersona
    INNER JOIN usuario_rol ur ON u.idUsuario   = ur.idUsuario
    INNER JOIN rol r          ON ur.idRol      = r.idRol
    LEFT JOIN  estudiante e   ON e.idPersona   = p.idPersona
    LEFT JOIN  docente d      ON d.idPersona   = p.idPersona
    LEFT JOIN  administrador a ON a.idPersona  = p.idPersona
    WHERE u.idUsuario = v_idUsuario;
  END IF;
  -- Si no se encontró, no se retorna ninguna fila (login fallido)
END$$

-- sp_CambiarContrasena: Permite cambiar la contraseña de un usuario
DROP PROCEDURE IF EXISTS sp_CambiarContrasena$$
CREATE PROCEDURE sp_CambiarContrasena(
  IN p_idUsuario  INT,
  IN p_claveVieja VARCHAR(255),  -- SHA-256 de la contraseña anterior
  IN p_claveNueva VARCHAR(255)   -- SHA-256 de la nueva contraseña
)
BEGIN
  DECLARE v_existe INT DEFAULT 0;
  SELECT COUNT(*) INTO v_existe FROM usuario
  WHERE idUsuario = p_idUsuario AND Clave = p_claveVieja;

  IF v_existe > 0 THEN
    UPDATE usuario SET Clave = p_claveNueva WHERE idUsuario = p_idUsuario;
    SELECT 'OK' AS Resultado, 'Contraseña cambiada exitosamente' AS Mensaje;
  ELSE
    SELECT 'ERROR' AS Resultado, 'La contraseña actual es incorrecta' AS Mensaje;
  END IF;
END$$

-- sp_CambiarEstadoUsuario: Activa/desactiva/bloquea un usuario
DROP PROCEDURE IF EXISTS sp_CambiarEstadoUsuario$$
CREATE PROCEDURE sp_CambiarEstadoUsuario(
  IN p_idUsuario INT,
  IN p_estado    VARCHAR(20)  -- 'Activo','Inactivo','Bloqueado'
)
BEGIN
  UPDATE usuario SET Estado = p_estado WHERE idUsuario = p_idUsuario;
  SELECT ROW_COUNT() AS FilasAfectadas;
END$$

-- sp_ListarUsuarios: Retorna todos los usuarios con su rol
DROP PROCEDURE IF EXISTS sp_ListarUsuarios$$
CREATE PROCEDURE sp_ListarUsuarios()
BEGIN
  SELECT
    u.idUsuario,
    u.NombreUsuario,
    u.Estado,
    u.FechaCreacion,
    u.UltimoAcceso,
    CONCAT(p.Nombre, ' ', p.ApellidoPaterno) AS NombreCompleto,
    p.CI,
    r.NombreRol
  FROM usuario u
  INNER JOIN persona p      ON u.idPersona  = p.idPersona
  INNER JOIN usuario_rol ur ON u.idUsuario   = ur.idUsuario
  INNER JOIN rol r          ON ur.idRol      = r.idRol
  ORDER BY r.NombreRol, p.ApellidoPaterno;
END$$

-- ==========================================
-- GRUPO 2: GESTIÓN DE ESTUDIANTES
-- ==========================================

-- sp_CrearEstudiante: Registra persona + estudiante + usuario en una transacción
DROP PROCEDURE IF EXISTS sp_CrearEstudiante$$
CREATE PROCEDURE sp_CrearEstudiante(
  IN  p_nombre          VARCHAR(100),
  IN  p_apellidoPaterno VARCHAR(80),
  IN  p_apellidoMaterno VARCHAR(80),
  IN  p_ci              VARCHAR(20),
  IN  p_correo          VARCHAR(120),
  IN  p_telefono        VARCHAR(20),
  IN  p_ciudad          VARCHAR(80),
  IN  p_departamento    VARCHAR(50),
  IN  p_sexo            CHAR(1),
  IN  p_fechaNacimiento DATE,
  IN  p_nombreUsuario   VARCHAR(50),
  IN  p_clave           VARCHAR(255),
  OUT p_idEstudiante    INT,
  OUT p_resultado       VARCHAR(10),
  OUT p_mensaje         VARCHAR(200)
)
BEGIN
  DECLARE v_idPersona  INT;
  DECLARE v_idUsuario  INT;
  DECLARE v_idRol      INT;
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    SET p_resultado = 'ERROR';
    SET p_mensaje   = 'Error al crear estudiante. El CI o usuario ya puede existir.';
    SET p_idEstudiante = 0;
  END;

  START TRANSACTION;
    -- 1. Crear registro de persona
    INSERT INTO persona (Nombre, ApellidoPaterno, ApellidoMaterno, CI, Correo, Telefono,
                         Ciudad, Departamento, Sexo, FechaNacimiento)
    VALUES (p_nombre, p_apellidoPaterno, p_apellidoMaterno, p_ci, p_correo, p_telefono,
            p_ciudad, p_departamento, p_sexo, p_fechaNacimiento);
    SET v_idPersona = LAST_INSERT_ID();

    -- 2. Crear registro de estudiante
    INSERT INTO estudiante (idPersona) VALUES (v_idPersona);
    SET p_idEstudiante = LAST_INSERT_ID();

    -- 3. Crear usuario del sistema
    INSERT INTO usuario (NombreUsuario, Clave, idPersona)
    VALUES (p_nombreUsuario, p_clave, v_idPersona);
    SET v_idUsuario = LAST_INSERT_ID();

    -- 4. Asignar rol Estudiante
    SELECT idRol INTO v_idRol FROM rol WHERE NombreRol = 'Estudiante' LIMIT 1;
    INSERT INTO usuario_rol (idUsuario, idRol) VALUES (v_idUsuario, v_idRol);
  COMMIT;

  SET p_resultado = 'OK';
  SET p_mensaje   = CONCAT('Estudiante creado con ID: ', p_idEstudiante);
END$$

-- sp_ObtenerEstudiante: Retorna datos completos de un estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerEstudiante$$
CREATE PROCEDURE sp_ObtenerEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT
    e.idEstudiante,
    p.idPersona,
    p.Nombre,
    p.ApellidoPaterno,
    p.ApellidoMaterno,
    p.CI,
    p.Correo,
    p.Telefono,
    p.Ciudad,
    p.Departamento,
    p.Sexo,
    p.FechaNacimiento,
    p.Estado,
    u.NombreUsuario,
    u.Estado AS EstadoUsuario,
    m.NombreModulo AS ModuloActual,
    m.Nivel AS NivelActual,
    prog.Estado AS EstadoModulo
  FROM estudiante e
  INNER JOIN persona p ON e.idPersona = p.idPersona
  LEFT JOIN  usuario u ON u.idPersona  = p.idPersona
  LEFT JOIN  progreso_estudiante prog ON prog.idEstudiante = e.idEstudiante AND prog.Estado = 'En Progreso'
  LEFT JOIN  modulo m ON m.idModulo = prog.idModulo
  WHERE e.idEstudiante = p_idEstudiante;
END$$

-- sp_ListarEstudiantes: Lista todos los estudiantes con su módulo actual
DROP PROCEDURE IF EXISTS sp_ListarEstudiantes$$
CREATE PROCEDURE sp_ListarEstudiantes()
BEGIN
  SELECT
    e.idEstudiante,
    p.Nombre,
    p.ApellidoPaterno,
    p.ApellidoMaterno,
    CONCAT(p.Nombre, ' ', p.ApellidoPaterno) AS NombreCompleto,
    p.CI,
    p.Correo,
    p.Telefono,
    p.Ciudad,
    p.Estado AS EstadoPersona,
    u.NombreUsuario,
    u.Estado AS EstadoUsuario,
    IFNULL(m.NombreModulo, 'Sin módulo') AS ModuloActual,
    IFNULL(m.Nivel, '-') AS Nivel,
    i.Estado AS EstadoInscripcion
  FROM estudiante e
  INNER JOIN persona p      ON e.idPersona    = p.idPersona
  LEFT JOIN  usuario u      ON u.idPersona     = p.idPersona
  LEFT JOIN  progreso_estudiante prog ON prog.idEstudiante = e.idEstudiante AND prog.Estado = 'En Progreso'
  LEFT JOIN  modulo m       ON m.idModulo      = prog.idModulo
  LEFT JOIN  inscripcion i  ON i.idEstudiante  = e.idEstudiante AND i.Estado NOT IN ('Finalizada')
  ORDER BY p.ApellidoPaterno, p.Nombre;
END$$

-- sp_ActualizarEstudiante: Actualiza datos personales del estudiante
DROP PROCEDURE IF EXISTS sp_ActualizarEstudiante$$
CREATE PROCEDURE sp_ActualizarEstudiante(
  IN p_idEstudiante    INT,
  IN p_nombre          VARCHAR(100),
  IN p_apellidoPaterno VARCHAR(80),
  IN p_apellidoMaterno VARCHAR(80),
  IN p_ci              VARCHAR(20),
  IN p_correo          VARCHAR(120),
  IN p_telefono        VARCHAR(20),
  IN p_ciudad          VARCHAR(80),
  IN p_departamento    VARCHAR(50),
  IN p_sexo            CHAR(1),
  IN p_fechaNacimiento DATE
)
BEGIN
  DECLARE v_idPersona INT;
  SELECT idPersona INTO v_idPersona FROM estudiante WHERE idEstudiante = p_idEstudiante;

  UPDATE persona SET
    Nombre          = p_nombre,
    ApellidoPaterno = p_apellidoPaterno,
    ApellidoMaterno = p_apellidoMaterno,
    CI              = p_ci,
    Correo          = p_correo,
    Telefono        = p_telefono,
    Ciudad          = p_ciudad,
    Departamento    = p_departamento,
    Sexo            = p_sexo,
    FechaNacimiento = p_fechaNacimiento
  WHERE idPersona = v_idPersona;

  SELECT ROW_COUNT() AS FilasAfectadas;
END$$

-- sp_EliminarEstudiante: Baja lógica del estudiante (no elimina físicamente)
DROP PROCEDURE IF EXISTS sp_EliminarEstudiante$$
CREATE PROCEDURE sp_EliminarEstudiante(IN p_idEstudiante INT)
BEGIN
  DECLARE v_idPersona INT;
  SELECT idPersona INTO v_idPersona FROM estudiante WHERE idEstudiante = p_idEstudiante;
  UPDATE persona  SET Estado = 'Inactivo' WHERE idPersona  = v_idPersona;
  UPDATE usuario  SET Estado = 'Inactivo' WHERE idPersona  = v_idPersona;
  SELECT ROW_COUNT() AS FilasAfectadas;
END$$

-- sp_VerificarAccesoPago: Verifica si el estudiante puede acceder al sistema
-- Regla: Si el pago está vencido más de 30 días, se bloquea el acceso
DROP PROCEDURE IF EXISTS sp_VerificarAccesoPago$$
CREATE PROCEDURE sp_VerificarAccesoPago(IN p_idEstudiante INT)
BEGIN
  DECLARE v_fechaVencimiento DATE;
  DECLARE v_estadoInscripcion VARCHAR(30);

  SELECT FechaVencimientoPago, Estado
  INTO v_fechaVencimiento, v_estadoInscripcion
  FROM inscripcion
  WHERE idEstudiante = p_idEstudiante AND Estado = 'Activa'
  LIMIT 1;

  IF v_estadoInscripcion IS NULL THEN
    SELECT 'SIN_INSCRIPCION' AS Acceso, 'No tiene inscripción activa' AS Mensaje;
  ELSEIF v_fechaVencimiento IS NOT NULL AND DATEDIFF(CURDATE(), v_fechaVencimiento) > 30 THEN
    -- Bloquear acceso automáticamente
    UPDATE inscripcion SET Estado = 'Bloqueada' WHERE idEstudiante = p_idEstudiante AND Estado = 'Activa';
    UPDATE usuario u
    INNER JOIN persona p ON u.idPersona = p.idPersona
    INNER JOIN estudiante e ON e.idPersona = p.idPersona
    SET u.Estado = 'Bloqueado'
    WHERE e.idEstudiante = p_idEstudiante;
    SELECT 'BLOQUEADO' AS Acceso, CONCAT('Pago vencido desde ', v_fechaVencimiento) AS Mensaje;
  ELSE
    SELECT 'PERMITIDO' AS Acceso, 'Acceso permitido' AS Mensaje;
  END IF;
END$$

-- ==========================================
-- GRUPO 3: GESTIÓN DE DOCENTES
-- ==========================================

-- sp_CrearDocente: Registra persona + docente + usuario + turno
DROP PROCEDURE IF EXISTS sp_CrearDocente$$
CREATE PROCEDURE sp_CrearDocente(
  IN  p_nombre          VARCHAR(100),
  IN  p_apellidoPaterno VARCHAR(80),
  IN  p_apellidoMaterno VARCHAR(80),
  IN  p_ci              VARCHAR(20),
  IN  p_correo          VARCHAR(120),
  IN  p_telefono        VARCHAR(20),
  IN  p_ciudad          VARCHAR(80),
  IN  p_sexo            CHAR(1),
  IN  p_nombreUsuario   VARCHAR(50),
  IN  p_clave           VARCHAR(255),
  IN  p_idTurno         INT,
  OUT p_idDocente       INT,
  OUT p_resultado       VARCHAR(10),
  OUT p_mensaje         VARCHAR(200)
)
BEGIN
  DECLARE v_idPersona INT;
  DECLARE v_idUsuario INT;
  DECLARE v_idRol     INT;
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    SET p_resultado = 'ERROR';
    SET p_mensaje   = 'Error al crear docente. El CI o usuario ya puede existir.';
    SET p_idDocente = 0;
  END;

  START TRANSACTION;
    INSERT INTO persona (Nombre, ApellidoPaterno, ApellidoMaterno, CI, Correo, Telefono, Ciudad, Sexo)
    VALUES (p_nombre, p_apellidoPaterno, p_apellidoMaterno, p_ci, p_correo, p_telefono, p_ciudad, p_sexo);
    SET v_idPersona = LAST_INSERT_ID();

    INSERT INTO docente (idPersona) VALUES (v_idPersona);
    SET p_idDocente = LAST_INSERT_ID();

    -- Asignar turno al docente
    IF p_idTurno IS NOT NULL THEN
      INSERT INTO docente_turno (idDocente, idTurno) VALUES (p_idDocente, p_idTurno);
    END IF;

    INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES (p_nombreUsuario, p_clave, v_idPersona);
    SET v_idUsuario = LAST_INSERT_ID();

    SELECT idRol INTO v_idRol FROM rol WHERE NombreRol = 'Docente' LIMIT 1;
    INSERT INTO usuario_rol (idUsuario, idRol) VALUES (v_idUsuario, v_idRol);
  COMMIT;

  SET p_resultado = 'OK';
  SET p_mensaje   = CONCAT('Docente creado con ID: ', p_idDocente);
END$$

-- sp_ListarDocentes: Lista todos los docentes con su turno
DROP PROCEDURE IF EXISTS sp_ListarDocentes$$
CREATE PROCEDURE sp_ListarDocentes()
BEGIN
  SELECT
    d.idDocente,
    p.Nombre,
    p.ApellidoPaterno,
    CONCAT(p.Nombre, ' ', p.ApellidoPaterno) AS NombreCompleto,
    p.CI,
    p.Correo,
    p.Telefono,
    p.Ciudad,
    p.Estado,
    u.NombreUsuario,
    u.Estado AS EstadoUsuario,
    t.NombreTurno,
    t.HoraInicio,
    t.HoraFin
  FROM docente d
  INNER JOIN persona p ON d.idPersona = p.idPersona
  LEFT JOIN  usuario u ON u.idPersona  = p.idPersona
  LEFT JOIN  docente_turno dt ON dt.idDocente = d.idDocente
  LEFT JOIN  turno t ON t.idTurno = dt.idTurno
  ORDER BY p.ApellidoPaterno;
END$$

-- sp_ObtenerDocente: Datos de un docente específico
DROP PROCEDURE IF EXISTS sp_ObtenerDocente$$
CREATE PROCEDURE sp_ObtenerDocente(IN p_idDocente INT)
BEGIN
  SELECT d.idDocente, p.Nombre, p.ApellidoPaterno, p.ApellidoMaterno,
         p.CI, p.Correo, p.Telefono, p.Ciudad, p.Sexo, p.FechaNacimiento,
         u.NombreUsuario, u.Estado AS EstadoUsuario,
         t.idTurno, t.NombreTurno
  FROM docente d
  INNER JOIN persona p ON d.idPersona = p.idPersona
  LEFT JOIN  usuario u ON u.idPersona = p.idPersona
  LEFT JOIN  docente_turno dt ON dt.idDocente = d.idDocente
  LEFT JOIN  turno t ON t.idTurno = dt.idTurno
  WHERE d.idDocente = p_idDocente;
END$$

-- sp_ActualizarDocente: Actualiza datos del docente
DROP PROCEDURE IF EXISTS sp_ActualizarDocente$$
CREATE PROCEDURE sp_ActualizarDocente(
  IN p_idDocente       INT,
  IN p_nombre          VARCHAR(100),
  IN p_apellidoPaterno VARCHAR(80),
  IN p_apellidoMaterno VARCHAR(80),
  IN p_ci              VARCHAR(20),
  IN p_correo          VARCHAR(120),
  IN p_telefono        VARCHAR(20),
  IN p_ciudad          VARCHAR(80),
  IN p_idTurno         INT
)
BEGIN
  DECLARE v_idPersona INT;
  SELECT idPersona INTO v_idPersona FROM docente WHERE idDocente = p_idDocente;

  UPDATE persona SET
    Nombre = p_nombre, ApellidoPaterno = p_apellidoPaterno,
    ApellidoMaterno = p_apellidoMaterno, CI = p_ci,
    Correo = p_correo, Telefono = p_telefono, Ciudad = p_ciudad
  WHERE idPersona = v_idPersona;

  -- Actualizar turno si se proporcionó
  IF p_idTurno IS NOT NULL THEN
    INSERT INTO docente_turno (idDocente, idTurno) VALUES (p_idDocente, p_idTurno)
    ON DUPLICATE KEY UPDATE idTurno = p_idTurno;
  END IF;
END$$

-- sp_EliminarDocente: Baja lógica del docente
DROP PROCEDURE IF EXISTS sp_EliminarDocente$$
CREATE PROCEDURE sp_EliminarDocente(IN p_idDocente INT)
BEGIN
  DECLARE v_idPersona INT;
  SELECT idPersona INTO v_idPersona FROM docente WHERE idDocente = p_idDocente;
  UPDATE persona SET Estado = 'Inactivo' WHERE idPersona = v_idPersona;
  UPDATE usuario SET Estado = 'Inactivo' WHERE idPersona = v_idPersona;
END$$

-- ==========================================
-- GRUPO 4: MÓDULOS Y PROGRESO
-- ==========================================

-- sp_ListarModulos: Lista los 4 módulos del curso
DROP PROCEDURE IF EXISTS sp_ListarModulos$$
CREATE PROCEDURE sp_ListarModulos()
BEGIN
  SELECT idModulo, NombreModulo, Nivel, DuracionMeses, NumeroLibro, Descripcion
  FROM modulo ORDER BY idModulo;
END$$

-- sp_ObtenerModuloActual: Retorna el módulo activo del estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerModuloActual$$
CREATE PROCEDURE sp_ObtenerModuloActual(IN p_idEstudiante INT)
BEGIN
  SELECT m.idModulo, m.NombreModulo, m.Nivel, m.DuracionMeses, m.NumeroLibro,
         prog.FechaInicio, prog.Estado AS EstadoProgreso
  FROM progreso_estudiante prog
  INNER JOIN modulo m ON m.idModulo = prog.idModulo
  WHERE prog.idEstudiante = p_idEstudiante AND prog.Estado = 'En Progreso'
  LIMIT 1;
END$$

-- sp_CrearProgresoEstudiante: Inicia el progreso en el módulo asignado
DROP PROCEDURE IF EXISTS sp_CrearProgresoEstudiante$$
CREATE PROCEDURE sp_CrearProgresoEstudiante(
  IN p_idEstudiante INT,
  IN p_idModulo     INT
)
BEGIN
  INSERT INTO progreso_estudiante (FechaInicio, Estado, idEstudiante, idModulo)
  VALUES (CURDATE(), 'En Progreso', p_idEstudiante, p_idModulo);
  SELECT LAST_INSERT_ID() AS idProgreso;
END$$

-- sp_AvanzarModulo: Aprueba módulo actual y pasa al siguiente
DROP PROCEDURE IF EXISTS sp_AvanzarModulo$$
CREATE PROCEDURE sp_AvanzarModulo(
  IN p_idEstudiante INT,
  OUT p_resultado   VARCHAR(10),
  OUT p_mensaje     VARCHAR(200)
)
BEGIN
  DECLARE v_idModuloActual  INT;
  DECLARE v_idSiguienteModulo INT;
  DECLARE v_aprobado        INT DEFAULT 0;

  -- Obtener módulo actual
  SELECT prog.idModulo INTO v_idModuloActual
  FROM progreso_estudiante prog
  WHERE prog.idEstudiante = p_idEstudiante AND prog.Estado = 'En Progreso'
  LIMIT 1;

  -- Verificar que ambos exámenes (Teórico y Oral) están aprobados
  SELECT COUNT(*) INTO v_aprobado
  FROM examen_modulo em
  INNER JOIN planilla_evaluacion pe ON em.idPlanilla = pe.idPlanilla
  WHERE pe.idEstudiante = p_idEstudiante AND pe.idModulo = v_idModuloActual
    AND em.Estado = 'Aprobado'
  GROUP BY pe.idModulo
  HAVING COUNT(*) >= 2;

  IF v_aprobado = 0 THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'El estudiante debe aprobar Examen Teórico y Oral (mín. 90) antes de avanzar.';
  ELSE
    -- Marcar módulo actual como aprobado
    UPDATE progreso_estudiante SET Estado = 'Aprobado', FechaFin = CURDATE()
    WHERE idEstudiante = p_idEstudiante AND Estado = 'En Progreso';

    -- Buscar siguiente módulo
    SELECT idModulo INTO v_idSiguienteModulo
    FROM modulo WHERE idModulo > v_idModuloActual ORDER BY idModulo LIMIT 1;

    IF v_idSiguienteModulo IS NOT NULL THEN
      -- Crear progreso para el siguiente módulo
      INSERT INTO progreso_estudiante (FechaInicio, Estado, idEstudiante, idModulo)
      VALUES (CURDATE(), 'En Progreso', p_idEstudiante, v_idSiguienteModulo);

      -- Crear nueva planilla para el siguiente módulo
      INSERT INTO planilla_evaluacion (FechaCreacion, Estado, idEstudiante, idModulo)
      VALUES (CURDATE(), 'En Progreso', p_idEstudiante, v_idSiguienteModulo);

      SET p_resultado = 'OK';
      SET p_mensaje = CONCAT('Avanzó al módulo ', v_idSiguienteModulo);
    ELSE
      -- Ya terminó todos los módulos
      SET p_resultado = 'COMPLETADO';
      SET p_mensaje = 'El estudiante ha completado todos los módulos del curso';
    END IF;
  END IF;
END$$

-- ==========================================
-- GRUPO 5: INSCRIPCIONES Y PAGOS
-- ==========================================

-- sp_CrearInscripcion: Registra inscripción del estudiante al curso
DROP PROCEDURE IF EXISTS sp_CrearInscripcion$$
CREATE PROCEDURE sp_CrearInscripcion(
  IN  p_idEstudiante       INT,
  IN  p_fechaInscripcion   DATE,
  IN  p_modalidadPago      VARCHAR(50),
  IN  p_montoTotal         DECIMAL(10,2),
  IN  p_fechaVencimiento   DATE,
  OUT p_idInscripcion      INT,
  OUT p_resultado          VARCHAR(10),
  OUT p_mensaje            VARCHAR(200)
)
BEGIN
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'Error al crear inscripción.';
    SET p_idInscripcion = 0;
  END;

  INSERT INTO inscripcion (FechaInscripcion, ModalidadPago, MontoTotal, Estado, FechaVencimientoPago, idEstudiante)
  VALUES (p_fechaInscripcion, p_modalidadPago, p_montoTotal, 'Activa', p_fechaVencimiento, p_idEstudiante);

  SET p_idInscripcion = LAST_INSERT_ID();
  SET p_resultado = 'OK';
  SET p_mensaje   = CONCAT('Inscripción creada con ID: ', p_idInscripcion);
END$$

-- sp_ListarInscripciones: Lista todas las inscripciones
DROP PROCEDURE IF EXISTS sp_ListarInscripciones$$
CREATE PROCEDURE sp_ListarInscripciones()
BEGIN
  SELECT
    i.idInscripcion,
    i.FechaInscripcion,
    i.ModalidadPago,
    i.MontoTotal,
    i.Estado,
    i.FechaVencimientoPago,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreEstudiante,
    e.idEstudiante,
    COALESCE(SUM(pago.Monto), 0) AS TotalPagado,
    i.MontoTotal - COALESCE(SUM(pago.Monto), 0) AS Saldo
  FROM inscripcion i
  INNER JOIN estudiante e ON e.idEstudiante = i.idEstudiante
  INNER JOIN persona p    ON p.idPersona    = e.idPersona
  LEFT JOIN  pago         ON pago.idInscripcion = i.idInscripcion
  GROUP BY i.idInscripcion
  ORDER BY i.FechaInscripcion DESC;
END$$

-- sp_ObtenerInscripcionPorEstudiante: Obtiene la inscripción activa del estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerInscripcionPorEstudiante$$
CREATE PROCEDURE sp_ObtenerInscripcionPorEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT
    i.idInscripcion, i.FechaInscripcion, i.ModalidadPago,
    i.MontoTotal, i.Estado, i.FechaVencimientoPago,
    COALESCE(SUM(pa.Monto), 0) AS TotalPagado,
    i.MontoTotal - COALESCE(SUM(pa.Monto), 0) AS Saldo
  FROM inscripcion i
  LEFT JOIN pago pa ON pa.idInscripcion = i.idInscripcion
  WHERE i.idEstudiante = p_idEstudiante
  GROUP BY i.idInscripcion
  ORDER BY i.FechaInscripcion DESC
  LIMIT 1;
END$$

-- sp_RegistrarPago: Registra un pago de cuota o contado
DROP PROCEDURE IF EXISTS sp_RegistrarPago$$
CREATE PROCEDURE sp_RegistrarPago(
  IN  p_idInscripcion INT,
  IN  p_monto         DECIMAL(10,2),
  IN  p_tipoPago      VARCHAR(50),
  IN  p_numeroCuota   INT,
  IN  p_fechaPago     DATE,
  IN  p_nuevaFechaVencimiento DATE,
  OUT p_idPago        INT,
  OUT p_resultado     VARCHAR(10),
  OUT p_mensaje       VARCHAR(200)
)
BEGIN
  INSERT INTO pago (FechaPago, Monto, TipoPago, NumeroCuota, Estado, idInscripcion)
  VALUES (p_fechaPago, p_monto, p_tipoPago, p_numeroCuota, 'Pagado', p_idInscripcion);
  SET p_idPago = LAST_INSERT_ID();

  -- Actualizar fecha de vencimiento y estado si corresponde
  UPDATE inscripcion
  SET FechaVencimientoPago = p_nuevaFechaVencimiento,
      Estado = CASE WHEN Estado = 'Bloqueada' THEN 'Activa' ELSE Estado END
  WHERE idInscripcion = p_idInscripcion;

  -- Si la inscripción se reactiva, reactivar usuario
  UPDATE usuario u
  INNER JOIN persona p ON u.idPersona = p.idPersona
  INNER JOIN estudiante e ON e.idPersona = p.idPersona
  INNER JOIN inscripcion i ON i.idEstudiante = e.idEstudiante
  SET u.Estado = 'Activo'
  WHERE i.idInscripcion = p_idInscripcion AND u.Estado = 'Bloqueado';

  SET p_resultado = 'OK';
  SET p_mensaje   = CONCAT('Pago registrado con ID: ', p_idPago);
END$$

-- sp_ListarPagosPorInscripcion: Lista los pagos de una inscripción
DROP PROCEDURE IF EXISTS sp_ListarPagosPorInscripcion$$
CREATE PROCEDURE sp_ListarPagosPorInscripcion(IN p_idInscripcion INT)
BEGIN
  SELECT idPago, FechaPago, Monto, TipoPago, NumeroCuota, Estado, Observacion
  FROM pago WHERE idInscripcion = p_idInscripcion ORDER BY FechaPago;
END$$

-- sp_EstadoFinancieroEstudiante: Resumen financiero del estudiante
DROP PROCEDURE IF EXISTS sp_EstadoFinancieroEstudiante$$
CREATE PROCEDURE sp_EstadoFinancieroEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT
    i.idInscripcion,
    i.FechaInscripcion,
    i.ModalidadPago,
    i.MontoTotal,
    i.Estado AS EstadoInscripcion,
    i.FechaVencimientoPago,
    COALESCE(SUM(pa.Monto), 0) AS TotalPagado,
    i.MontoTotal - COALESCE(SUM(pa.Monto), 0) AS SaldoPendiente,
    DATEDIFF(CURDATE(), i.FechaVencimientoPago) AS DiasVencimiento,
    CASE
      WHEN DATEDIFF(CURDATE(), i.FechaVencimientoPago) > 30 THEN 'VENCIDO'
      WHEN DATEDIFF(CURDATE(), i.FechaVencimientoPago) BETWEEN 1 AND 30 THEN 'POR VENCER'
      ELSE 'AL DÍA'
    END AS EstadoPago
  FROM inscripcion i
  LEFT JOIN pago pa ON pa.idInscripcion = i.idInscripcion
  WHERE i.idEstudiante = p_idEstudiante
  GROUP BY i.idInscripcion;
END$$

-- sp_ListarEstudiantesMorosos: Estudiantes con pago vencido > 30 días
DROP PROCEDURE IF EXISTS sp_ListarEstudiantesMorosos$$
CREATE PROCEDURE sp_ListarEstudiantesMorosos()
BEGIN
  SELECT
    e.idEstudiante,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreCompleto,
    p.Correo, p.Telefono,
    i.FechaVencimientoPago,
    DATEDIFF(CURDATE(), i.FechaVencimientoPago) AS DiasVencidos,
    i.MontoTotal - COALESCE(SUM(pa.Monto),0) AS SaldoPendiente
  FROM inscripcion i
  INNER JOIN estudiante e ON e.idEstudiante = i.idEstudiante
  INNER JOIN persona p    ON p.idPersona    = e.idPersona
  LEFT JOIN  pago pa      ON pa.idInscripcion = i.idInscripcion
  WHERE i.Estado = 'Activa'
    AND i.FechaVencimientoPago IS NOT NULL
    AND DATEDIFF(CURDATE(), i.FechaVencimientoPago) > 30
  GROUP BY i.idInscripcion
  ORDER BY DiasVencidos DESC;
END$$

-- ==========================================
-- GRUPO 6: CONGELAMIENTOS
-- ==========================================

-- sp_CrearCongelamiento: Registra congelamiento y bloquea acceso
DROP PROCEDURE IF EXISTS sp_CrearCongelamiento$$
CREATE PROCEDURE sp_CrearCongelamiento(
  IN p_idInscripcion INT,
  IN p_fechaInicio   DATE,
  IN p_fechaFin      DATE,
  IN p_motivo        TEXT
)
BEGIN
  INSERT INTO congelamiento (FechaInicio, FechaFin, Motivo, Estado, idInscripcion)
  VALUES (p_fechaInicio, p_fechaFin, p_motivo, 'Activo', p_idInscripcion);

  -- Cambiar estado de inscripción a Congelada
  UPDATE inscripcion SET Estado = 'Congelada' WHERE idInscripcion = p_idInscripcion;

  -- Bloquear usuario del estudiante
  UPDATE usuario u
  INNER JOIN persona p ON u.idPersona = p.idPersona
  INNER JOIN estudiante e ON e.idPersona = p.idPersona
  INNER JOIN inscripcion i ON i.idEstudiante = e.idEstudiante
  SET u.Estado = 'Bloqueado'
  WHERE i.idInscripcion = p_idInscripcion;

  SELECT LAST_INSERT_ID() AS idCongelamiento;
END$$

-- sp_FinalizarCongelamiento: Levanta el congelamiento y reactiva acceso
DROP PROCEDURE IF EXISTS sp_FinalizarCongelamiento$$
CREATE PROCEDURE sp_FinalizarCongelamiento(IN p_idCongelamiento INT)
BEGIN
  DECLARE v_idInscripcion INT;
  SELECT idInscripcion INTO v_idInscripcion FROM congelamiento WHERE idCongelamiento = p_idCongelamiento;

  UPDATE congelamiento SET Estado = 'Finalizado' WHERE idCongelamiento = p_idCongelamiento;
  UPDATE inscripcion SET Estado = 'Activa' WHERE idInscripcion = v_idInscripcion;

  -- Reactivar usuario del estudiante
  UPDATE usuario u
  INNER JOIN persona p ON u.idPersona = p.idPersona
  INNER JOIN estudiante e ON e.idPersona = p.idPersona
  INNER JOIN inscripcion i ON i.idEstudiante = e.idEstudiante
  SET u.Estado = 'Activo'
  WHERE i.idInscripcion = v_idInscripcion AND u.Estado = 'Bloqueado';
END$$

-- sp_ListarCongelamientos: Lista todos los congelamientos
DROP PROCEDURE IF EXISTS sp_ListarCongelamientos$$
CREATE PROCEDURE sp_ListarCongelamientos()
BEGIN
  SELECT
    c.idCongelamiento,
    c.FechaInicio, c.FechaFin, c.Motivo, c.Estado,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreEstudiante,
    e.idEstudiante,
    i.idInscripcion
  FROM congelamiento c
  INNER JOIN inscripcion i ON i.idInscripcion = c.idInscripcion
  INNER JOIN estudiante e  ON e.idEstudiante  = i.idEstudiante
  INNER JOIN persona p     ON p.idPersona     = e.idPersona
  ORDER BY c.FechaInicio DESC;
END$$

-- ==========================================
-- GRUPO 7: HORARIOS Y CLASES
-- ==========================================

-- sp_CrearHorario: Crea un nuevo horario para un módulo
DROP PROCEDURE IF EXISTS sp_CrearHorario$$
CREATE PROCEDURE sp_CrearHorario(
  IN  p_nombre   VARCHAR(100),
  IN  p_idModulo INT,
  OUT p_idHorario INT
)
BEGIN
  INSERT INTO horario (Nombre, idModulo, Publicado) VALUES (p_nombre, p_idModulo, 0);
  SET p_idHorario = LAST_INSERT_ID();
END$$

-- sp_PublicarHorario: Publica o despublica un horario
DROP PROCEDURE IF EXISTS sp_PublicarHorario$$
CREATE PROCEDURE sp_PublicarHorario(
  IN p_idHorario INT,
  IN p_publicado TINYINT(1)
)
BEGIN
  UPDATE horario SET Publicado = p_publicado WHERE idHorario = p_idHorario;
  SELECT ROW_COUNT() AS FilasAfectadas;
END$$

-- sp_ListarHorarios: Lista horarios con información del módulo
DROP PROCEDURE IF EXISTS sp_ListarHorarios$$
CREATE PROCEDURE sp_ListarHorarios()
BEGIN
  SELECT
    h.idHorario, h.Nombre, h.Publicado, h.FechaCreacion,
    m.idModulo, m.NombreModulo, m.Nivel,
    COUNT(c.idClase) AS TotalClases
  FROM horario h
  INNER JOIN modulo m ON m.idModulo = h.idModulo
  LEFT JOIN  clase c  ON c.idHorario = h.idHorario
  GROUP BY h.idHorario
  ORDER BY m.idModulo, h.FechaCreacion;
END$$

-- sp_CrearClase: Crea una clase, validando choque de horario del docente
-- La restricción UNIQUE uk_docente_fecha_hora en la tabla ya previene duplicados
DROP PROCEDURE IF EXISTS sp_CrearClase$$
CREATE PROCEDURE sp_CrearClase(
  IN  p_fecha        DATE,
  IN  p_horaInicio   TIME,
  IN  p_modalidad    VARCHAR(20),
  IN  p_idDocente    INT,
  IN  p_idHorario    INT,
  IN  p_linkZoom     VARCHAR(255),
  IN  p_aula         VARCHAR(50),
  OUT p_idClase      INT,
  OUT p_resultado    VARCHAR(10),
  OUT p_mensaje      VARCHAR(200)
)
BEGIN
  DECLARE v_horaFin TIME;
  DECLARE EXIT HANDLER FOR 1062
  BEGIN
    -- Error 1062 = Duplicate entry (choque de horario)
    SET p_resultado = 'ERROR';
    SET p_mensaje = CONCAT('El docente ya tiene una clase el ',p_fecha,' a las ',p_horaInicio);
    SET p_idClase = 0;
  END;

  -- La hora fin es siempre 1 hora después del inicio
  SET v_horaFin = ADDTIME(p_horaInicio, '01:00:00');

  INSERT INTO clase (Fecha, HoraInicio, HoraFin, Modalidad, CupoMaximo, CupoActual,
                     Estado, LinkZoom, Aula, idDocente, idHorario)
  VALUES (p_fecha, p_horaInicio, v_horaFin, p_modalidad, 8, 0,
          'Programada', p_linkZoom, p_aula, p_idDocente, p_idHorario);

  SET p_idClase   = LAST_INSERT_ID();
  SET p_resultado = 'OK';
  SET p_mensaje   = CONCAT('Clase creada con ID: ', p_idClase);
END$$

-- sp_ActualizarClase: Modifica datos de una clase
DROP PROCEDURE IF EXISTS sp_ActualizarClase$$
CREATE PROCEDURE sp_ActualizarClase(
  IN p_idClase    INT,
  IN p_fecha      DATE,
  IN p_horaInicio TIME,
  IN p_modalidad  VARCHAR(20),
  IN p_idDocente  INT,
  IN p_linkZoom   VARCHAR(255),
  IN p_aula       VARCHAR(50)
)
BEGIN
  DECLARE v_horaFin TIME;
  SET v_horaFin = ADDTIME(p_horaInicio, '01:00:00');
  UPDATE clase SET
    Fecha = p_fecha, HoraInicio = p_horaInicio, HoraFin = v_horaFin,
    Modalidad = p_modalidad, idDocente = p_idDocente,
    LinkZoom = p_linkZoom, Aula = p_aula
  WHERE idClase = p_idClase;
END$$

-- sp_EliminarClase: Elimina clase solo si no tiene reservas activas
DROP PROCEDURE IF EXISTS sp_EliminarClase$$
CREATE PROCEDURE sp_EliminarClase(
  IN  p_idClase   INT,
  OUT p_resultado VARCHAR(10),
  OUT p_mensaje   VARCHAR(200)
)
BEGIN
  DECLARE v_reservas INT DEFAULT 0;
  SELECT COUNT(*) INTO v_reservas FROM reserva
  WHERE idClase = p_idClase AND Estado = 'Confirmada';

  IF v_reservas > 0 THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = CONCAT('La clase tiene ', v_reservas, ' reservas activas. No se puede eliminar.');
  ELSE
    DELETE FROM clase WHERE idClase = p_idClase;
    SET p_resultado = 'OK';
    SET p_mensaje = 'Clase eliminada correctamente.';
  END IF;
END$$

-- sp_ListarClasesPorHorario: Lista clases de un horario con datos del docente
DROP PROCEDURE IF EXISTS sp_ListarClasesPorHorario$$
CREATE PROCEDURE sp_ListarClasesPorHorario(IN p_idHorario INT)
BEGIN
  SELECT
    c.idClase, c.Fecha, c.HoraInicio, c.HoraFin,
    c.Modalidad, c.CupoMaximo, c.CupoActual, c.Estado,
    c.LinkZoom, c.Aula,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreDocente,
    d.idDocente,
    h.idHorario, h.Nombre AS NombreHorario,
    m.NombreModulo
  FROM clase c
  INNER JOIN docente d  ON d.idDocente   = c.idDocente
  INNER JOIN persona p  ON p.idPersona   = d.idPersona
  INNER JOIN horario h  ON h.idHorario   = c.idHorario
  INNER JOIN modulo m   ON m.idModulo    = h.idModulo
  WHERE c.idHorario = p_idHorario
  ORDER BY c.Fecha, c.HoraInicio;
END$$

-- sp_ObtenerHorarioEstudiante: Retorna el horario publicado del módulo actual del estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerHorarioEstudiante$$
CREATE PROCEDURE sp_ObtenerHorarioEstudiante(IN p_idEstudiante INT)
BEGIN
  DECLARE v_idModulo INT;

  -- Obtener módulo actual del estudiante
  SELECT prog.idModulo INTO v_idModulo
  FROM progreso_estudiante prog
  WHERE prog.idEstudiante = p_idEstudiante AND prog.Estado = 'En Progreso'
  LIMIT 1;

  -- Retornar clases de los horarios publicados de ese módulo
  SELECT
    c.idClase, c.Fecha, c.HoraInicio, c.HoraFin,
    c.Modalidad, c.CupoMaximo, c.CupoActual, c.Estado,
    c.LinkZoom, c.Aula,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreDocente,
    h.Nombre AS NombreHorario,
    m.NombreModulo, m.Nivel,
    -- Verificar si ya tiene reserva para esa clase
    CASE WHEN r.idReserva IS NOT NULL THEN 1 ELSE 0 END AS YaReservado
  FROM clase c
  INNER JOIN horario h ON h.idHorario = c.idHorario
  INNER JOIN modulo m  ON m.idModulo  = h.idModulo
  INNER JOIN docente d ON d.idDocente = c.idDocente
  INNER JOIN persona p ON p.idPersona = d.idPersona
  LEFT JOIN  reserva r ON r.idClase = c.idClase AND r.idEstudiante = p_idEstudiante
  WHERE h.idModulo = v_idModulo AND h.Publicado = 1
  ORDER BY c.Fecha, c.HoraInicio;
END$$

-- ==========================================
-- GRUPO 8: RESERVAS Y ASISTENCIA
-- ==========================================

-- sp_CrearReserva: Crea reserva y asistencia, valida cupo máximo (8)
DROP PROCEDURE IF EXISTS sp_CrearReserva$$
CREATE PROCEDURE sp_CrearReserva(
  IN  p_idEstudiante INT,
  IN  p_idClase      INT,
  OUT p_idReserva    INT,
  OUT p_resultado    VARCHAR(10),
  OUT p_mensaje      VARCHAR(200)
)
BEGIN
  DECLARE v_cupoActual INT;
  DECLARE v_cupoMaximo INT;
  DECLARE v_estadoClase VARCHAR(30);
  DECLARE EXIT HANDLER FOR 1062
  BEGIN
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'Ya tienes una reserva para esta clase.';
    SET p_idReserva = 0;
  END;

  -- Verificar disponibilidad de la clase
  SELECT CupoActual, CupoMaximo, Estado INTO v_cupoActual, v_cupoMaximo, v_estadoClase
  FROM clase WHERE idClase = p_idClase FOR UPDATE;

  IF v_estadoClase = 'Finalizada' THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'La clase ya finalizó.';
    SET p_idReserva = 0;
  ELSEIF v_cupoActual >= v_cupoMaximo THEN
    SET p_resultado = 'LLENA';
    SET p_mensaje = CONCAT('La clase está llena (', v_cupoMaximo, '/', v_cupoMaximo, ').');
    SET p_idReserva = 0;
  ELSE
    -- Crear reserva
    INSERT INTO reserva (Estado, idEstudiante, idClase)
    VALUES ('Confirmada', p_idEstudiante, p_idClase);
    SET p_idReserva = LAST_INSERT_ID();

    -- Crear asistencia automáticamente (presente por defecto)
    INSERT INTO asistencia (Asistio, idReserva) VALUES (1, p_idReserva);

    -- Actualizar cupo
    UPDATE clase SET CupoActual = CupoActual + 1 WHERE idClase = p_idClase;

    SET p_resultado = 'OK';
    SET p_mensaje = 'Reserva confirmada exitosamente.';
  END IF;
END$$

-- sp_CancelarReserva: Cancela la reserva y elimina la asistencia
DROP PROCEDURE IF EXISTS sp_CancelarReserva$$
CREATE PROCEDURE sp_CancelarReserva(
  IN  p_idReserva INT,
  OUT p_resultado VARCHAR(10),
  OUT p_mensaje   VARCHAR(200)
)
BEGIN
  DECLARE v_idClase INT;
  SELECT idClase INTO v_idClase FROM reserva WHERE idReserva = p_idReserva;

  -- Eliminar asistencia asociada
  DELETE FROM asistencia WHERE idReserva = p_idReserva;

  -- Eliminar reserva
  DELETE FROM reserva WHERE idReserva = p_idReserva;

  -- Liberar cupo
  UPDATE clase SET CupoActual = CupoActual - 1 WHERE idClase = v_idClase AND CupoActual > 0;

  SET p_resultado = 'OK';
  SET p_mensaje = 'Reserva cancelada y asistencia eliminada.';
END$$

-- sp_ListarReservasPorEstudiante: Lista reservas del estudiante con detalle de clase
DROP PROCEDURE IF EXISTS sp_ListarReservasPorEstudiante$$
CREATE PROCEDURE sp_ListarReservasPorEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT
    r.idReserva, r.FechaReserva, r.Estado AS EstadoReserva,
    c.idClase, c.Fecha, c.HoraInicio, c.HoraFin, c.Modalidad,
    c.LinkZoom, c.Aula,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreDocente,
    m.NombreModulo,
    a.Asistio
  FROM reserva r
  INNER JOIN clase c    ON c.idClase   = r.idClase
  INNER JOIN horario h  ON h.idHorario = c.idHorario
  INNER JOIN modulo m   ON m.idModulo  = h.idModulo
  INNER JOIN docente d  ON d.idDocente = c.idDocente
  INNER JOIN persona p  ON p.idPersona = d.idPersona
  LEFT JOIN  asistencia a ON a.idReserva = r.idReserva
  WHERE r.idEstudiante = p_idEstudiante
  ORDER BY c.Fecha DESC, c.HoraInicio;
END$$

-- sp_ListarReservasPorClase: Lista reservas de una clase (para el admin)
DROP PROCEDURE IF EXISTS sp_ListarReservasPorClase$$
CREATE PROCEDURE sp_ListarReservasPorClase(IN p_idClase INT)
BEGIN
  SELECT
    r.idReserva, r.FechaReserva, r.Estado,
    CONCAT(pe.Nombre,' ',pe.ApellidoPaterno) AS NombreEstudiante,
    pe.CI, pe.Telefono,
    e.idEstudiante,
    a.Asistio
  FROM reserva r
  INNER JOIN estudiante e ON e.idEstudiante = r.idEstudiante
  INNER JOIN persona pe   ON pe.idPersona   = e.idPersona
  LEFT JOIN  asistencia a ON a.idReserva    = r.idReserva
  WHERE r.idClase = p_idClase
  ORDER BY pe.ApellidoPaterno;
END$$

-- sp_ContarHorasSemana: Cuenta las horas cursadas por el estudiante en la semana actual
DROP PROCEDURE IF EXISTS sp_ContarHorasSemana$$
CREATE PROCEDURE sp_ContarHorasSemana(IN p_idEstudiante INT)
BEGIN
  DECLARE v_inicioSemana DATE;
  DECLARE v_finSemana    DATE;

  -- Obtener lunes de la semana actual (MySQL: DAYOFWEEK domingo=1)
  SET v_inicioSemana = DATE_SUB(CURDATE(), INTERVAL WEEKDAY(CURDATE()) DAY);
  SET v_finSemana    = DATE_ADD(v_inicioSemana, INTERVAL 5 DAY); -- hasta sábado

  SELECT
    COUNT(r.idReserva) AS HorasSemana,
    v_inicioSemana AS InicioSemana,
    v_finSemana AS FinSemana
  FROM reserva r
  INNER JOIN clase c ON c.idClase = r.idClase
  WHERE r.idEstudiante = p_idEstudiante
    AND r.Estado = 'Confirmada'
    AND c.Fecha BETWEEN v_inicioSemana AND v_finSemana;
END$$

-- sp_VerificarYGenerarAlerta: Verifica horas semanales y genera alerta si < 5
DROP PROCEDURE IF EXISTS sp_VerificarYGenerarAlerta$$
CREATE PROCEDURE sp_VerificarYGenerarAlerta(IN p_idEstudiante INT)
BEGIN
  DECLARE v_horas        INT DEFAULT 0;
  DECLARE v_inicioSemana DATE;
  DECLARE v_existeAlerta INT DEFAULT 0;

  SET v_inicioSemana = DATE_SUB(CURDATE(), INTERVAL WEEKDAY(CURDATE()) DAY);

  -- Contar horas de la semana actual
  SELECT COUNT(*) INTO v_horas
  FROM reserva r
  INNER JOIN clase c ON c.idClase = r.idClase
  WHERE r.idEstudiante = p_idEstudiante
    AND r.Estado = 'Confirmada'
    AND c.Fecha BETWEEN v_inicioSemana AND DATE_ADD(v_inicioSemana, INTERVAL 5 DAY);

  -- Verificar si ya existe una alerta para esta semana
  SELECT COUNT(*) INTO v_existeAlerta FROM alerta_asistencia
  WHERE idEstudiante = p_idEstudiante AND Semana = v_inicioSemana;

  -- Si tiene menos de 5 horas y no existe alerta, crear alerta
  IF v_horas < 5 AND v_existeAlerta = 0 THEN
    INSERT INTO alerta_asistencia (Semana, HorasCursadas, Revisada, idEstudiante)
    VALUES (v_inicioSemana, v_horas, 0, p_idEstudiante);
  END IF;

  SELECT v_horas AS HorasCursadas, v_inicioSemana AS Semana;
END$$

-- sp_ListarAlertasActivas: Retorna todas las alertas no revisadas con datos del estudiante
DROP PROCEDURE IF EXISTS sp_ListarAlertasActivas$$
CREATE PROCEDURE sp_ListarAlertasActivas()
BEGIN
  SELECT
    al.idAlerta, al.Semana, al.HorasCursadas, al.FechaAlerta, al.Revisada,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreEstudiante,
    p.Correo, p.Telefono,
    e.idEstudiante
  FROM alerta_asistencia al
  INNER JOIN estudiante e ON e.idEstudiante = al.idEstudiante
  INNER JOIN persona p    ON p.idPersona    = e.idPersona
  WHERE al.Revisada = 0
  ORDER BY al.FechaAlerta DESC;
END$$

-- sp_MarcarAlertaRevisada: El admin marca una alerta como revisada
DROP PROCEDURE IF EXISTS sp_MarcarAlertaRevisada$$
CREATE PROCEDURE sp_MarcarAlertaRevisada(IN p_idAlerta INT)
BEGIN
  UPDATE alerta_asistencia SET Revisada = 1 WHERE idAlerta = p_idAlerta;
END$$

-- ==========================================
-- GRUPO 9: EVALUACIONES Y PLANILLAS
-- ==========================================

-- sp_CrearPlanilla: Crea la planilla de evaluación para un estudiante en un módulo
DROP PROCEDURE IF EXISTS sp_CrearPlanilla$$
CREATE PROCEDURE sp_CrearPlanilla(
  IN  p_idEstudiante INT,
  IN  p_idModulo     INT,
  OUT p_idPlanilla   INT
)
BEGIN
  -- Verificar si ya existe planilla para ese módulo
  DECLARE v_existe INT DEFAULT 0;
  SELECT COUNT(*) INTO v_existe FROM planilla_evaluacion
  WHERE idEstudiante = p_idEstudiante AND idModulo = p_idModulo;

  IF v_existe = 0 THEN
    INSERT INTO planilla_evaluacion (Estado, FechaCreacion, idEstudiante, idModulo)
    VALUES ('En Progreso', CURDATE(), p_idEstudiante, p_idModulo);
    SET p_idPlanilla = LAST_INSERT_ID();
  ELSE
    SELECT idPlanilla INTO p_idPlanilla FROM planilla_evaluacion
    WHERE idEstudiante = p_idEstudiante AND idModulo = p_idModulo LIMIT 1;
  END IF;
END$$

-- sp_ObtenerPlanillaEstudianteModulo: Obtiene planilla con todas sus notas
DROP PROCEDURE IF EXISTS sp_ObtenerPlanillaEstudianteModulo$$
CREATE PROCEDURE sp_ObtenerPlanillaEstudianteModulo(
  IN p_idEstudiante INT,
  IN p_idModulo     INT
)
BEGIN
  -- Datos de la planilla
  SELECT pe.idPlanilla, pe.Estado, pe.FechaCreacion,
         m.NombreModulo, m.Nivel, m.NumeroLibro,
         CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreEstudiante
  FROM planilla_evaluacion pe
  INNER JOIN modulo m ON m.idModulo = pe.idModulo
  INNER JOIN estudiante e ON e.idEstudiante = pe.idEstudiante
  INNER JOIN persona p ON p.idPersona = e.idPersona
  WHERE pe.idEstudiante = p_idEstudiante AND pe.idModulo = p_idModulo;

  -- Notas por tema
  SELECT nt.idNotaTema, nt.NroTema, nt.Speaking, nt.Writing, nt.Listening, nt.Reading,
         nt.FechaRegistro, CONCAT(pd.Nombre,' ',pd.ApellidoPaterno) AS NombreDocente
  FROM nota_tema nt
  INNER JOIN planilla_evaluacion pe ON pe.idPlanilla = nt.idPlanilla
  INNER JOIN docente d ON d.idDocente = nt.idDocente
  INNER JOIN persona pd ON pd.idPersona = d.idPersona
  WHERE pe.idEstudiante = p_idEstudiante AND pe.idModulo = p_idModulo
  ORDER BY nt.NroTema;

  -- Exámenes de módulo
  SELECT em.idExamen, em.TipoExamen, em.Nota, em.Intento, em.Estado, em.Fecha,
         CONCAT(pd.Nombre,' ',pd.ApellidoPaterno) AS NombreDocente
  FROM examen_modulo em
  INNER JOIN planilla_evaluacion pe ON pe.idPlanilla = em.idPlanilla
  INNER JOIN docente d ON d.idDocente = em.idDocente
  INNER JOIN persona pd ON pd.idPersona = d.idPersona
  WHERE pe.idEstudiante = p_idEstudiante AND pe.idModulo = p_idModulo;
END$$

-- sp_ListarPlanillasPorEstudiante: Retorna todas las planillas de un estudiante
DROP PROCEDURE IF EXISTS sp_ListarPlanillasPorEstudiante$$
CREATE PROCEDURE sp_ListarPlanillasPorEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT pe.idPlanilla, pe.Estado, pe.FechaCreacion,
         m.idModulo, m.NombreModulo, m.Nivel
  FROM planilla_evaluacion pe
  INNER JOIN modulo m ON m.idModulo = pe.idModulo
  WHERE pe.idEstudiante = p_idEstudiante
  ORDER BY m.idModulo;
END$$

-- sp_RegistrarNotaTema: Docente registra las 4 notas de un tema
DROP PROCEDURE IF EXISTS sp_RegistrarNotaTema$$
CREATE PROCEDURE sp_RegistrarNotaTema(
  IN  p_idPlanilla INT,
  IN  p_nroTema    INT,
  IN  p_speaking   DECIMAL(4,2),
  IN  p_writing    DECIMAL(4,2),
  IN  p_listening  DECIMAL(4,2),
  IN  p_reading    DECIMAL(4,2),
  IN  p_idDocente  INT,
  OUT p_resultado  VARCHAR(10),
  OUT p_mensaje    VARCHAR(200)
)
BEGIN
  DECLARE EXIT HANDLER FOR 1062
  BEGIN
    SET p_resultado = 'ERROR';
    SET p_mensaje = CONCAT('El tema ', p_nroTema, ' ya tiene notas registradas. Use Actualizar.');
  END;

  INSERT INTO nota_tema (NroTema, Speaking, Writing, Listening, Reading, FechaRegistro, idPlanilla, idDocente)
  VALUES (p_nroTema, p_speaking, p_writing, p_listening, p_reading, CURDATE(), p_idPlanilla, p_idDocente);

  SET p_resultado = 'OK';
  SET p_mensaje = CONCAT('Notas del tema ', p_nroTema, ' registradas.');
END$$

-- sp_ActualizarNotaTema: Modifica las notas de un tema existente
DROP PROCEDURE IF EXISTS sp_ActualizarNotaTema$$
CREATE PROCEDURE sp_ActualizarNotaTema(
  IN p_idNotaTema INT,
  IN p_speaking   DECIMAL(4,2),
  IN p_writing    DECIMAL(4,2),
  IN p_listening  DECIMAL(4,2),
  IN p_reading    DECIMAL(4,2),
  IN p_idDocente  INT
)
BEGIN
  UPDATE nota_tema SET
    Speaking = p_speaking, Writing = p_writing,
    Listening = p_listening, Reading = p_reading,
    FechaRegistro = CURDATE(), idDocente = p_idDocente
  WHERE idNotaTema = p_idNotaTema;
END$$

-- sp_RegistrarExamenModulo: Docente registra resultado de examen teórico u oral
-- Regla: Mínimo 90 puntos para aprobar; puede reintentar solo el que falló

DELIMITER $$

DROP PROCEDURE IF EXISTS sp_RegistrarExamenModulo$$
CREATE PROCEDURE sp_RegistrarExamenModulo(
  IN  p_idPlanilla  INT,
  IN  p_tipoExamen  ENUM('Teorico','Oral'),
  IN  p_nota        DECIMAL(4,2),
  IN  p_idDocente   INT,
  OUT p_resultado   VARCHAR(10),
  OUT p_mensaje     VARCHAR(200)
)
principal: BEGIN
  DECLARE v_intento   INT DEFAULT 1;
  DECLARE v_estado    VARCHAR(20);
  DECLARE v_idUltimo  INT DEFAULT NULL;

  -- Verificar si ya existe un examen de este tipo en la planilla
  SELECT idExamen, Intento INTO v_idUltimo, v_intento
  FROM examen_modulo
  WHERE idPlanilla = p_idPlanilla AND TipoExamen = p_tipoExamen
  ORDER BY Intento DESC LIMIT 1;

  -- Si el último intento ya está aprobado, no permitir nuevo intento
  IF v_idUltimo IS NOT NULL THEN
    SELECT Estado INTO v_estado FROM examen_modulo WHERE idExamen = v_idUltimo;
    IF v_estado = 'Aprobado' THEN
      SET p_resultado = 'ERROR';
      SET p_mensaje = CONCAT('El examen ', p_tipoExamen, ' ya fue aprobado.');
      LEAVE principal;
    ELSE
      SET v_intento = v_intento + 1;
    END IF;
  END IF;

  -- Determinar estado según nota (mínimo 90)
  SET v_estado = IF(p_nota >= 90, 'Aprobado', 'Reprobado');

  INSERT INTO examen_modulo (TipoExamen, Nota, Intento, Estado, Fecha, idPlanilla, idDocente)
  VALUES (p_tipoExamen, p_nota, v_intento, v_estado, CURDATE(), p_idPlanilla, p_idDocente);

  SET p_resultado = 'OK';
  SET p_mensaje = CONCAT('Examen registrado: ', p_nota, ' puntos → ', v_estado,
                         ' (Intento ', v_intento, ')');
END principal$$

DELIMITER ;

DELIMITER $$

-- sp_VerificarAprobacionModulo: Verifica si el estudiante aprobó ambos exámenes del módulo
DROP PROCEDURE IF EXISTS sp_VerificarAprobacionModulo$$
CREATE PROCEDURE sp_VerificarAprobacionModulo(
  IN p_idEstudiante INT,
  IN p_idModulo     INT
)
BEGIN
  SELECT
    COUNT(CASE WHEN em.TipoExamen = 'Teorico' AND em.Estado = 'Aprobado' THEN 1 END) AS TeoricoAprobado,
    COUNT(CASE WHEN em.TipoExamen = 'Oral'    AND em.Estado = 'Aprobado' THEN 1 END) AS OralAprobado,
    CASE
      WHEN COUNT(CASE WHEN em.TipoExamen = 'Teorico' AND em.Estado = 'Aprobado' THEN 1 END) > 0
       AND COUNT(CASE WHEN em.TipoExamen = 'Oral'    AND em.Estado = 'Aprobado' THEN 1 END) > 0
      THEN 1 ELSE 0
    END AS PuedeAvanzar
  FROM planilla_evaluacion pe
  LEFT JOIN examen_modulo em ON em.idPlanilla = pe.idPlanilla
  WHERE pe.idEstudiante = p_idEstudiante AND pe.idModulo = p_idModulo;
END$$

-- ==========================================
-- GRUPO 10: EXAMEN DIAGNÓSTICO
-- ==========================================

-- sp_RegistrarDiagnostico: Registra el examen diagnóstico y asigna módulo inicial
DROP PROCEDURE IF EXISTS sp_RegistrarDiagnostico$$
CREATE PROCEDURE sp_RegistrarDiagnostico(
  IN  p_idEstudiante    INT,
  IN  p_fecha           DATE,
  IN  p_puntaje         INT,
  IN  p_nivel           VARCHAR(10),
  IN  p_observaciones   TEXT,
  IN  p_idModuloAsignado INT,
  OUT p_resultado        VARCHAR(10),
  OUT p_mensaje          VARCHAR(200)
)
BEGIN
  DECLARE v_existe INT DEFAULT 0;
  SELECT COUNT(*) INTO v_existe FROM examen_diagnostico WHERE idEstudiante = p_idEstudiante;
  
  IF v_existe > 0 THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'El estudiante ya cuenta con un examen diagnóstico.';
  ELSE
    -- Registrar el diagnóstico
    INSERT INTO examen_diagnostico (Fecha, Puntaje, Nivel, Observaciones, idModuloAsignado, idEstudiante)
    VALUES (p_fecha, p_puntaje, p_nivel, p_observaciones, p_idModuloAsignado, p_idEstudiante);

    -- Crear progreso en el módulo asignado
    INSERT INTO progreso_estudiante (FechaInicio, Estado, idEstudiante, idModulo)
    VALUES (p_fecha, 'En Progreso', p_idEstudiante, p_idModuloAsignado);

    -- Crear planilla de evaluación para el módulo inicial
    INSERT INTO planilla_evaluacion (Estado, FechaCreacion, idEstudiante, idModulo)
    VALUES ('En Progreso', p_fecha, p_idEstudiante, p_idModuloAsignado);

    SET p_resultado = 'OK';
    SET p_mensaje = CONCAT('Diagnóstico registrado. Módulo asignado: ', p_idModuloAsignado);
  END IF;
END$$

-- sp_ObtenerDiagnostico: Obtiene el diagnóstico de un estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerDiagnostico$$
CREATE PROCEDURE sp_ObtenerDiagnostico(IN p_idEstudiante INT)
BEGIN
  SELECT ed.idDiagnostico, ed.Fecha, ed.Puntaje, ed.Nivel, ed.Observaciones,
         m.NombreModulo AS ModuloAsignado, m.Nivel AS NivelModulo
  FROM examen_diagnostico ed
  LEFT JOIN modulo m ON m.idModulo = ed.idModuloAsignado
  WHERE ed.idEstudiante = p_idEstudiante;
END$$

-- sp_ListarDiagnosticos: Lista todos los diagnósticos registrados
DROP PROCEDURE IF EXISTS sp_ListarDiagnosticos$$
CREATE PROCEDURE sp_ListarDiagnosticos()
BEGIN
  SELECT 
    ed.idDiagnostico, ed.Fecha, ed.Puntaje, ed.Nivel, ed.Observaciones,
    CONCAT(p.Nombre, ' ', p.ApellidoPaterno) AS NombreEstudiante,
    m.NombreModulo AS ModuloAsignado
  FROM examen_diagnostico ed
  INNER JOIN estudiante e ON e.idEstudiante = ed.idEstudiante
  INNER JOIN persona p ON p.idPersona = e.idPersona
  LEFT JOIN modulo m ON m.idModulo = ed.idModuloAsignado
  ORDER BY ed.Fecha DESC;
END$$

-- ==========================================
-- GRUPO 11: PROYECTO FINAL Y CERTIFICADO
-- ==========================================

-- sp_CrearProyectoFinal: Registra el proyecto final del estudiante
DROP PROCEDURE IF EXISTS sp_CrearProyectoFinal$$
CREATE PROCEDURE sp_CrearProyectoFinal(
  IN  p_idEstudiante INT,
  IN  p_tema         VARCHAR(200),
  IN  p_linkEnsayo   VARCHAR(255),
  IN  p_linkVideo    VARCHAR(255),
  OUT p_idProyecto   INT,
  OUT p_resultado    VARCHAR(10),
  OUT p_mensaje      VARCHAR(200)
)
BEGIN
  -- Verificar que el estudiante terminó todos los módulos
  DECLARE v_modulosAprobados INT DEFAULT 0;
  SELECT COUNT(*) INTO v_modulosAprobados FROM progreso_estudiante
  WHERE idEstudiante = p_idEstudiante AND Estado = 'Aprobado';

  IF v_modulosAprobados < 4 THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = CONCAT('El estudiante solo tiene ', v_modulosAprobados, ' módulo(s) aprobado(s). Debe completar los 4 módulos.');
    SET p_idProyecto = 0;
  ELSE
    INSERT INTO proyecto_final (Tema, LinkEnsayo, LinkVideo, Estado, FechaRegistro, idEstudiante)
    VALUES (p_tema, p_linkEnsayo, p_linkVideo, 'Pendiente', CURDATE(), p_idEstudiante);
    SET p_idProyecto = LAST_INSERT_ID();
    SET p_resultado = 'OK';
    SET p_mensaje = 'Proyecto final registrado correctamente.';
  END IF;
END$$

-- sp_CalificarProyectoFinal: Docente registra las tres notas del proyecto
DROP PROCEDURE IF EXISTS sp_CalificarProyectoFinal$$
CREATE PROCEDURE sp_CalificarProyectoFinal(
  IN p_idProyecto  INT,
  IN p_notaEnsayo  DECIMAL(4,2),
  IN p_notaVideo   DECIMAL(4,2),
  IN p_notaDefensa DECIMAL(4,2),
  IN p_idDocente   INT
)
BEGIN
  DECLARE v_notaFinal DECIMAL(4,2);
  SET v_notaFinal = (p_notaEnsayo + p_notaVideo + p_notaDefensa) / 3;

  UPDATE proyecto_final SET
    NotaEnsayo  = p_notaEnsayo,
    NotaVideo   = p_notaVideo,
    NotaDefensa = p_notaDefensa,
    NotaFinal   = v_notaFinal,
    Estado      = IF(v_notaFinal >= 60, 'Aprobado', 'Reprobado'),
    idDocente   = p_idDocente
  WHERE idProyecto = p_idProyecto;

  SELECT v_notaFinal AS NotaFinal,
         IF(v_notaFinal >= 60, 'Aprobado', 'Reprobado') AS Estado;
END$$

-- sp_ObtenerProyectoFinal: Obtiene el proyecto final de un estudiante
DROP PROCEDURE IF EXISTS sp_ObtenerProyectoFinal$$
CREATE PROCEDURE sp_ObtenerProyectoFinal(IN p_idEstudiante INT)
BEGIN
  SELECT pf.idProyecto, pf.Tema, pf.LinkEnsayo, pf.LinkVideo,
         pf.NotaEnsayo, pf.NotaVideo, pf.NotaDefensa, pf.NotaFinal,
         pf.Estado, pf.FechaRegistro,
         CONCAT(pd.Nombre,' ',pd.ApellidoPaterno) AS NombreDocente
  FROM proyecto_final pf
  LEFT JOIN docente d ON d.idDocente = pf.idDocente
  LEFT JOIN persona pd ON pd.idPersona = d.idPersona
  WHERE pf.idEstudiante = p_idEstudiante;
END$$

-- sp_EmitirCertificado: Emite el certificado de finalización del curso
DROP PROCEDURE IF EXISTS sp_EmitirCertificado$$
CREATE PROCEDURE sp_EmitirCertificado(
  IN  p_idEstudiante INT,
  IN  p_idAdmin      INT,
  OUT p_idCertificado INT,
  OUT p_resultado     VARCHAR(10),
  OUT p_mensaje       VARCHAR(200)
)
BEGIN
  DECLARE v_proyectoAprobado INT DEFAULT 0;
  DECLARE v_codigoCert       VARCHAR(20);

  -- Verificar que el proyecto final esté aprobado
  SELECT COUNT(*) INTO v_proyectoAprobado FROM proyecto_final
  WHERE idEstudiante = p_idEstudiante AND Estado = 'Aprobado';

  IF v_proyectoAprobado = 0 THEN
    SET p_resultado = 'ERROR';
    SET p_mensaje = 'El proyecto final no está aprobado. No se puede emitir certificado.';
    SET p_idCertificado = 0;
  ELSE
    -- Generar código único del certificado
    SET v_codigoCert = CONCAT('ACI-', YEAR(CURDATE()), '-', LPAD(p_idEstudiante, 5, '0'));

    INSERT INTO certificado (FechaEmision, NivelAlcanzado, CodigoCertificado, idEstudiante, idAdmin)
    VALUES (CURDATE(), 'B2', v_codigoCert, p_idEstudiante, p_idAdmin);

    SET p_idCertificado = LAST_INSERT_ID();
    -- Marcar inscripción como Finalizada
    UPDATE inscripcion SET Estado = 'Finalizada' WHERE idEstudiante = p_idEstudiante AND Estado = 'Activa';

    SET p_resultado = 'OK';
    SET p_mensaje = CONCAT('Certificado emitido: ', v_codigoCert);
  END IF;
END$$

-- sp_ListarCertificados: Lista todos los certificados emitidos
DROP PROCEDURE IF EXISTS sp_ListarCertificados$$
CREATE PROCEDURE sp_ListarCertificados()
BEGIN
  SELECT
    cert.idCertificado, cert.FechaEmision, cert.NivelAlcanzado, cert.CodigoCertificado,
    CONCAT(p.Nombre,' ',p.ApellidoPaterno) AS NombreEstudiante,
    p.CI, e.idEstudiante
  FROM certificado cert
  INNER JOIN estudiante e ON e.idEstudiante = cert.idEstudiante
  INNER JOIN persona p    ON p.idPersona    = e.idPersona
  ORDER BY cert.FechaEmision DESC;
END$$

-- sp_ListarAsistenciaEstudiante: Planilla de asistencia completa del estudiante
DROP PROCEDURE IF EXISTS sp_ListarAsistenciaEstudiante$$
CREATE PROCEDURE sp_ListarAsistenciaEstudiante(IN p_idEstudiante INT)
BEGIN
  SELECT
    r.idReserva,
    c.Fecha,
    c.HoraInicio, c.HoraFin,
    c.Modalidad,
    CONCAT(pd.Nombre,' ',pd.ApellidoPaterno) AS NombreDocente,
    m.NombreModulo,
    m.Nivel,
    a.Asistio,
    WEEK(c.Fecha) AS NumeroSemana,
    YEAR(c.Fecha) AS Anio
  FROM reserva r
  INNER JOIN clase c    ON c.idClase   = r.idClase
  INNER JOIN horario h  ON h.idHorario = c.idHorario
  INNER JOIN modulo m   ON m.idModulo  = h.idModulo
  INNER JOIN docente d  ON d.idDocente = c.idDocente
  INNER JOIN persona pd ON pd.idPersona= d.idPersona
  LEFT JOIN  asistencia a ON a.idReserva = r.idReserva
  WHERE r.idEstudiante = p_idEstudiante AND r.Estado = 'Confirmada'
  ORDER BY c.Fecha DESC;
END$$

-- sp_ResumenAsistenciaSemanal: Resumen de horas por semana del estudiante
DROP PROCEDURE IF EXISTS sp_ResumenAsistenciaSemanal$$
CREATE PROCEDURE sp_ResumenAsistenciaSemanal(IN p_idEstudiante INT)
BEGIN
  SELECT
    YEAR(c.Fecha) AS Anio,
    WEEK(c.Fecha) AS Semana,
    DATE_SUB(c.Fecha, INTERVAL WEEKDAY(c.Fecha) DAY) AS InicioSemana,
    COUNT(r.idReserva) AS HorasCursadas,
    CASE WHEN COUNT(r.idReserva) < 5 THEN 'ALERTA' ELSE 'OK' END AS EstadoSemana
  FROM reserva r
  INNER JOIN clase c ON c.idClase = r.idClase
  WHERE r.idEstudiante = p_idEstudiante AND r.Estado = 'Confirmada'
  GROUP BY YEAR(c.Fecha), WEEK(c.Fecha)
  ORDER BY Anio DESC, Semana DESC;
END$$

-- sp_ListarClasesDocente: Lista clases asignadas a un docente
DROP PROCEDURE IF EXISTS sp_ListarClasesDocente$$
CREATE PROCEDURE sp_ListarClasesDocente(IN p_idDocente INT)
BEGIN
  SELECT
    c.idClase, c.Fecha, c.HoraInicio, c.HoraFin,
    c.Modalidad, c.CupoActual, c.CupoMaximo, c.Estado,
    h.Nombre AS NombreHorario,
    m.NombreModulo, m.Nivel
  FROM clase c
  INNER JOIN horario h ON h.idHorario = c.idHorario
  INNER JOIN modulo m  ON m.idModulo  = h.idModulo
  WHERE c.idDocente = p_idDocente
  ORDER BY c.Fecha DESC, c.HoraInicio;
END$$

-- sp_ListarTurnos: Lista los turnos disponibles
DROP PROCEDURE IF EXISTS sp_ListarTurnos$$
CREATE PROCEDURE sp_ListarTurnos()
BEGIN
  SELECT idTurno, NombreTurno, HoraInicio, HoraFin FROM turno ORDER BY HoraInicio;
END$$

DELIMITER ;

-- ============================================================
-- FIN DEL SCRIPT
-- ============================================================
-- Para verificar los procedimientos creados:
-- SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES
-- WHERE ROUTINE_SCHEMA = 'academia_ingles' AND ROUTINE_TYPE = 'PROCEDURE';

-- ============================================================
-- SECCIÓN EXTRA: DATOS DE PRUEBA INICIALES
-- ============================================================

-- 1. Insertar Roles Base
INSERT INTO rol (NombreRol) VALUES ('Administrador'), ('Docente'), ('Estudiante');

-- 2. Insertar Turnos Base
INSERT INTO turno (NombreTurno, HoraInicio, HoraFin) VALUES 
('Mañana', '08:00:00', '12:00:00'),
('Tarde', '14:00:00', '18:00:00'),
('Noche', '18:30:00', '22:00:00');

-- 3. Insertar Módulos del Sistema (A1, A2, B1, B2)
INSERT INTO modulo (NombreModulo, Nivel, DuracionMeses, NumeroLibro, Descripcion) VALUES 
('Módulo Básico', 'A1', 2, 1, 'Introducción al idioma inglés, vocabulario esencial y gramática básica.'),
('Módulo Pre-Intermedio', 'A2', 2, 2, 'Desarrollo de habilidades de conversación básica y tiempos verbales.'),
('Módulo Intermedio', 'B1', 3, 3, 'Gramática intermedia, redacción de ensayos y mayor fluidez.'),
('Módulo Avanzado', 'B2', 3, 4, 'Preparación para el TOEFL/IELTS, lectura avanzada y modismos.');

-- 4. Usuarios de Prueba

-- USUARIO ADMINISTRADOR (Usuario: admin / Clave: admin123)
INSERT INTO persona (Nombre, ApellidoPaterno, ApellidoMaterno, CI, Correo, Telefono, Sexo) VALUES 
('Carlos', 'Admin', 'Sistema', '1000000', 'admin@academia.edu.bo', '77700000', 'M');
SET @idAdmin = LAST_INSERT_ID();
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES 
('admin', SHA2('admin123', 256), @idAdmin);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (LAST_INSERT_ID(), (SELECT idRol FROM rol WHERE NombreRol = 'Administrador'));

-- USUARIO DOCENTE (Usuario: docente / Clave: docente123)
INSERT INTO persona (Nombre, ApellidoPaterno, ApellidoMaterno, CI, Correo, Telefono, Sexo) VALUES 
('Laura', 'Docente', 'Pérez', '2000000', 'laura.perez@academia.edu.bo', '77711111', 'F');
SET @idDocentePersona = LAST_INSERT_ID();
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES 
('docente', SHA2('docente123', 256), @idDocentePersona);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (LAST_INSERT_ID(), (SELECT idRol FROM rol WHERE NombreRol = 'Docente'));
INSERT INTO docente (idPersona) VALUES (@idDocentePersona);
INSERT INTO docente_turno (idDocente, idTurno) VALUES (LAST_INSERT_ID(), 1);

-- USUARIO ESTUDIANTE (Usuario: estudiante / Clave: estudiante123)
INSERT INTO persona (Nombre, ApellidoPaterno, ApellidoMaterno, CI, Correo, Telefono, Sexo) VALUES 
('Juan', 'Estudiante', 'Mamani', '3000000', 'juan.estudiante@mail.com', '77722222', 'M');
SET @idEstudPersona = LAST_INSERT_ID();
INSERT INTO usuario (NombreUsuario, Clave, idPersona) VALUES 
('estudiante', SHA2('estudiante123', 256), @idEstudPersona);
INSERT INTO usuario_rol (idUsuario, idRol) VALUES (LAST_INSERT_ID(), (SELECT idRol FROM rol WHERE NombreRol = 'Estudiante'));
INSERT INTO estudiante (idPersona, FechaInscripcion, EstadoFinanciero) VALUES (@idEstudPersona, CURDATE(), 'Al Día');
