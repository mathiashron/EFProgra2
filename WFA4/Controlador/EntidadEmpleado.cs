
namespace WFA4
{
    public class EntidadEmpleado
    {
        private int id_estudiante;
        private string nombre;
        private string apellido;
        private string direccion;
        private int edad;
        private int id_curso;
        private int id_materia;
        private int id_profesor;
        

        public int Id_estudiante
        {
            get
            {
                return id_estudiante;
            }
            set 
            {
                id_estudiante = value;
            }            
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;
            }
        }
        public int Id_curso
        {
            get
            {
                return id_curso;
            }
            set
            {
                id_curso = value;
            }
        }
        public int Id_materia
        {
            get
            {
                return id_materia;
            }
            set
            {
                id_materia = value;
            }
        }
        public int Id_profesor
        {
            get
            {
                return id_profesor;
            }
            set
            {
                id_profesor = value;
            }
        }
        public EntidadEmpleado()
        {
            id_estudiante = int.MinValue;
            nombre = string.Empty;
            apellido = string.Empty;
            direccion = string.Empty;
            edad = int.MinValue;
            id_curso = int.MinValue;
            id_materia = int.MinValue;
            id_profesor = int.MinValue;
        }

        

    }

}
