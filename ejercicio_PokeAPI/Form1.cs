using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ejercicio_PokeAPI.Models;

namespace ejercicio_PokeAPI
{
    public partial class Form1 : Form
    {
        ApiRequest api = new ApiRequest();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             CargarDatos();
        }

        public void CargarDatos()
        {
            flowLayoutPanel1.Controls.Clear();

            PokeLista pokemon = new PokeLista();

            pokemon = api.ObtenerLista();

            foreach (var item in pokemon.listaPokemones)
            {
                flowLayoutPanel1.Controls.Add(new PokeVista(item.nombrePokemon, item.GetImage()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
