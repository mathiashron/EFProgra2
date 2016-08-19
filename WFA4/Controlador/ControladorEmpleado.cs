using System.Data;

namespace WFA4
{
    public class ControladorEmpleado
    {        
        Modelo mod = new Modelo();        
        EntidadEmpleado entidad = new EntidadEmpleado();
        string sql;
        
        public DataTable leer()
        {
            sql = "SELECT "
                + "id_estudiante,"
                + "NOMBRE,"
                + "APELLIDO,"
                + "direccion,"
                + "edad,"
                 + "id_curso"
                + " FROM "
                + "estudiante";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                 + "id_estudiante,"
                 + "NOMBRE,"
                + "APELLIDO,"
                + "direccion,"
                + "edad,"
                 + "id_curso"
                + " FROM "
                + "estudiante"
                + " WHERE "
                + "id_estudiante = " + id;
            return mod.llenarDT(sql);
        }

        public void insertar(EntidadEmpleado entidad)
        {
            sql = "INSERT INTO estudiante ("+
                "id_estudiante,"+
                 "NOMBRE,"+
                "APELLIDO,"+
                "direccion,"+
                "edad,"+
                 "id_curso"+
                ") VALUES ("+ 
                "'" + entidad.Id_estudiante + "',"
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "',"
                + "'" + entidad.Direccion + "',"
                + "'" + entidad.Edad + "',"
                + "'" +  entidad.Id_curso + "'"
               
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadEmpleado entidad)
        {
            sql = "UPDATE estudiante SET "
                 + "id_estudiante ='" + entidad.Id_estudiante + "',"
                + "NOMBRE ='" + entidad.Nombre + "',"
                + "APELLIDO = '" + entidad.Apellido + "',"
               + "direccion = '" + entidad.Direccion + "',"
                 + "edad = '" + entidad.Edad + "',"
                + "id_curso = '"+ entidad.Id_curso +"'"
                + " WHERE "
                + "id_estudiante = '" + entidad.Id_estudiante + "'";
                mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE from estudiante "
                + "WHERE "
                + "id_estudiante = '" + id + "'";
            mod.ejecutarSQL(sql);
        }
        /// <summary>
        ///  Materia
        /// </summary>
        /// <returns></returns>
        public DataTable leermateria()
        {
            sql = "SELECT "
                + "id_materia,"
                + "NOMBRE,"
                + "id_profesor"
               
                + " FROM "
                + "materia";
            return mod.llenarDT(sql);
        }
        public DataTable buscarmateria(int id)
        {
            sql = "SELECT "
                 + "id_materia,"
                 + "NOMBRE,"
                 + "id_profesor"
                + " FROM "
                + "materia"
                + " WHERE "
                + "id_materia = " + id;
            return mod.llenarDT(sql);
        }
        public void insertarmateria(EntidadEmpleado entidad)
        {
            sql = "INSERT INTO materia ("
               + "id_materia,"
                 + "NOMBRE,"
                 + "id_profesor"
                + ") VALUES ("
                + "'" + entidad.Id_materia + "',"
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Id_profesor + "'"

                + ")";
            mod.ejecutarSQL(sql);
        }
        public void modificarmateria(EntidadEmpleado entidad)
        {
            sql = "UPDATE materia SET "
                 + "id_materia ='" + entidad.Id_materia + "',"
                + "NOMBRE ='" + entidad.Nombre + "',"
                
                + "id_profesor = '" + entidad.Id_profesor +"'"
                + " WHERE "
                + "id_materia = '" + entidad.Id_materia+ "'";
            mod.ejecutarSQL(sql);
        }
        public void eliminarmateria(int id)
        {
            sql = "DELETE from materia "
                + "WHERE "
                + "id_materia =' " + id+"'";
            mod.ejecutarSQL(sql);
        }


        /// <summary>
        ///  profesor
        /// </summary>
        /// <returns></returns>
        public DataTable leerprofe()
        {
            sql = "SELECT "
                + "id_profesor,"
                + "NOMBRE,"
                + "apellido"

                + " FROM "
                + "profesor";
            return mod.llenarDT(sql);
        }
        public DataTable buscarprofe(int id)
        {
            sql = "SELECT "
                 + "id_profesor,"
                 + "NOMBRE,"
                 + "apellido"
                + " FROM "
                + "profesor"
                + " WHERE "
                + "id_profesor = " + id;
            return mod.llenarDT(sql);
        }
        public void insertarprofesor(EntidadEmpleado entidad)
        {
            sql = "INSERT INTO profesor ("
               + "id_profesor,"
                 + "NOMBRE,"
                 + "apellido"
                + ") VALUES ("
                + "'" + entidad.Id_profesor + "',"
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "'"

                + ")";
            mod.ejecutarSQL(sql);
        }
        public void modificarprofe(EntidadEmpleado entidad)
        {
            sql = "UPDATE profesor SET "
                 + "id_profesor ='" + entidad.Id_profesor + "',"
                + "NOMBRE ='" + entidad.Nombre + "',"

                + "apellido = '" + entidad.Apellido + "'"
                + " WHERE "
                + "id_profesor = '" + entidad.Id_profesor+ "'";
            mod.ejecutarSQL(sql);
        }
        public void eliminarprofe(int id)
        {
            sql = "DELETE from profesor "
                + "WHERE "
                + "id_profesor = '" + id + "'";
            mod.ejecutarSQL(sql);
        }
    }
}
