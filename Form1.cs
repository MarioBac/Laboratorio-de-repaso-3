namespace Laboratorio_de_repaso_3
{
    public partial class Form1 : Form
    {
        List <Propietario> propietarios = new List <Propietario> ();
        List <Propiedad> propiedades = new List <Propiedad> ();
        List<Resumen> resumen = new List<Resumen>();
        public Form1()
        {
            InitializeComponent();
        }
        private void CargarPropietarios()
        {
            FileStream stream = new FileStream("Propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Read() > -1)
            {
                Propietario propietario = new Propietario();
                propietario.dpi = reader.ReadLine();
                propietario.nombre = reader.ReadLine();
                propietario.apellido = reader.ReadLine();

                propietarios.Add(propietario);
            }
        
            reader.Close();
        }

        private void CargarPropiedades()
        {
            FileStream stream = new FileStream("Propiedades.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Read() > -1)
            {
                Propiedad propiedad = new Propiedad();
                propiedad.numeroCasa = reader.ReadLine();
                propiedad.dpiDueno = reader.ReadLine();
                propiedad.cuota = Convert.ToDecimal(reader.ReadLine());
                propiedades.Add(propiedad);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarPropietarios();
            CargarPropietarios();
            for (int i = 0; i < propiedades.Count; i++)
            {
                for (int j = 0; j < propietarios.Count; j++)
                {
                    if (propiedades[i].dpiDueno == propietarios[j].dpi)
                    {
                        Resumen datoTemp = new Resumen();
                        datoTemp.nombre = propietarios[j].nombre;
                        datoTemp.apellido = propietarios[j].apellido;
                        datoTemp.numeroCasa = propiedades[i].numeroCasa;
                        datoTemp.cuota = propiedades[i].cuota;

                        resumen.Add(datoTemp);
                    }
                }
            }
            dataGridView1.DataSource = resumen;
            dataGridView1.Refresh();
        }

    }
}