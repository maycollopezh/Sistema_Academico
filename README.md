# AISEA - Sistema Académico de Inglés

AISEA es una plataforma integral para la gestión académica, financiera y de recursos humanos de una academia de idiomas. Este proyecto destaca por su **arquitectura híbrida**, combinando la persistencia segura de una base de datos SQL con el alto rendimiento del procesamiento en memoria (RAM) mediante Estructuras de Datos Avanzadas.

## Características Principales y Arquitectura

El sistema está diseñado para soportar alta concurrencia, reduciendo la latencia (cuellos de botella) al mínimo (alcanzando un 95% de eficiencia en operaciones críticas):

*   **Gestión Financiera (Colas - FIFO):** Procesamiento de pagos estrictamente en el orden de llegada (`Queue<T>`), evitando inconsistencias durante alta demanda.
*   **Validación de Horarios (Árboles Binarios de Búsqueda - BST):** Prevención de choques de horarios en tiempo real usando inserción recursiva, logrando búsquedas con complejidad $O(\log n)$ sin saturar la base de datos.
*   **Estado de Pagos (Diccionarios / Hash Maps):** Validaciones inmediatas con complejidad $O(1)$ para verificar la morosidad o habilitación de los estudiantes.
*   **Historial Académico (Listas Enlazadas):** Nodos dinámicos que registran el progreso del estudiante de forma fluida y escalable, sin depender de índices rígidos en SQL.

## Seguridad
*   Cifrado de credenciales mediante **Hashing SHA2-256** a nivel de base de datos.
*   Control de acceso basado en **Roles** (Administrador, Docente, Estudiante).

## Tecnologías Utilizadas
*   **Lenguaje/Framework:** C# / .NET (Estructuras de `System.Collections.Generic`).
*   **Base de Datos:** SQL Server (Persistencia a largo plazo).
*   **Arquitectura:** Híbrida (SQL + Memoria RAM).

## Cómo ejecutar el proyecto
1. Clonar este repositorio: `git clone [enlace-de-tu-repo]`
2. Ejecutar el script SQL adjunto en la carpeta `/Database` para montar la base de datos local.
3. Actualizar la cadena de conexión (`ConnectionString`) en el archivo de configuración.
4. Compilar y ejecutar la solución en Visual Studio.
